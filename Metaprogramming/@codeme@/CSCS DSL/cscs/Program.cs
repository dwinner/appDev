﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsCsLang
{
   public class Program
   {
      private static readonly string EXT = "cscs";
      private static bool s_PrintingCompleted;

      private static void Main(string[] args)
      {
         Console.OutputEncoding = Encoding.UTF8;

         Console.CancelKeyPress += delegate
         {
            Console.WriteLine();
            Console.WriteLine("Goodbye! ¡Adiós! Ciao! Adieu! Adeus! Tschüss! Пока! 再见 さようなら הֱיה שלום وداعا");
         };

         ClearLine();

         // Subscribe to the printing events from the interpreter.
         // A printing event will be triggered after each successful statement
         // execution. On error an exception will be thrown.
         Interpreter.Instance.GetOutput += Print;

         ProcessScript("include(\"scripts/functions.cscs\");");
         string script = null;
         //script = GetFileContents("/Users/vk/Documents/github/cscscpp/bin/Debug/scripts/temp.cscs");

         if (args.Length >= 3)
         {
            Translation.TranslateScript(args);
            return;
         }
         if (args.Length > 0)
            if (args[0].EndsWith(EXT))
            {
               var filename = args[0];
               Console.WriteLine("Reading script from " + filename);
               script = GetFileContents(filename);
            }
            else script = args[0];

         if (!string.IsNullOrWhiteSpace(script))
         {
            ProcessScript(script);
            return;
         }

         RunLoop();
      }

      private static void SplitByLast(string str, string sep, ref string a, ref string b)
      {
         var it = str.LastIndexOfAny(sep.ToCharArray());
         a = it == -1 ? "" : str.Substring(0, it + 1);
         b = it == -1 ? str : str.Substring(it + 1);
      }

      private static string CompleteTab(string script, string init, ref int tabFileIndex,
         ref string start, ref string baseStr, ref string startsWith)
      {
         if (tabFileIndex > 0 && !script.Equals(init)) tabFileIndex = 0;
         if (tabFileIndex == 0 || script.EndsWith(Path.DirectorySeparatorChar.ToString()))
         {
            // The user pressed tab the first time or pressed it on a directory
            var path = "";
            SplitByLast(script, " ", ref start, ref path);
            SplitByLast(path, "/\\", ref baseStr, ref startsWith);
         }

         tabFileIndex++;
         var result = Utils.GetFileEntry(baseStr, tabFileIndex, startsWith);
         result = result.Length == 0 ? startsWith : result;
         return start + baseStr + result;
      }

      private static void RunLoop()
      {
         var commands = new List<string>();
         var sb = new StringBuilder();
         var cmdPtr = 0;
         var tabFileIndex = 0;
         var arrowMode = false;
         string start = "", baseCmd = "", startsWith = "", init = "", script;
         var previous = "";

         while (true)
         {
            sb.Clear();

            var nextCmd = NEXT_CMD.NONE;
            script = previous + GetConsoleLine(ref nextCmd, init).Trim();

            if (script.EndsWith(Constants.ContinueLine.ToString()))
            {
               previous = script.Remove(script.Length - 1);
               init = "";
               continue;
            }

            if (nextCmd == NEXT_CMD.PREV || nextCmd == NEXT_CMD.NEXT)
            {
               if (arrowMode || nextCmd == NEXT_CMD.NEXT) cmdPtr += (int) nextCmd;
               cmdPtr = cmdPtr < 0 || commands.Count == 0 ? cmdPtr + commands.Count : cmdPtr % commands.Count;
               init = commands.Count == 0 ? script : commands[cmdPtr];
               arrowMode = true;
               continue;
            }
            if (nextCmd == NEXT_CMD.TAB)
            {
               init = CompleteTab(script, init, ref tabFileIndex,
                  ref start, ref baseCmd, ref startsWith);
               continue;
            }

            init = "";
            previous = "";
            tabFileIndex = 0;
            arrowMode = false;

            if (string.IsNullOrWhiteSpace(script)) continue;

            if (commands.Count == 0 || !commands[commands.Count - 1].Equals(script)) commands.Add(script);
            if (!script.EndsWith(Constants.EndStatement.ToString())) script += Constants.EndStatement;

            ProcessScript(script);
            cmdPtr = commands.Count - 1;
         }
      }

      private static string GetConsoleLine(ref NEXT_CMD cmd, string init = "",
         bool enhancedMode = true)
      {
         //string line = init;
         var sb = new StringBuilder(init);
         var delta = init.Length - 1;
         var prompt = GetPrompt();
         Console.Write(prompt);
         Console.Write(init);

         if (!enhancedMode) return Console.ReadLine();

         while (true)
         {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.UpArrow)
            {
               cmd = NEXT_CMD.PREV;
               ClearLine(prompt, sb.ToString());
               return sb.ToString();
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
               cmd = NEXT_CMD.NEXT;
               ClearLine(prompt, sb.ToString());
               return sb.ToString();
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
               delta = Math.Max(-1, Math.Min(++delta, sb.Length - 1));
               SetCursor(prompt, sb.ToString(), delta + 1);
               continue;
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
               delta = Math.Max(-1, Math.Min(--delta, sb.Length - 1));
               SetCursor(prompt, sb.ToString(), delta + 1);
               continue;
            }
            if (key.Key == ConsoleKey.Tab)
            {
               cmd = NEXT_CMD.TAB;
               ClearLine(prompt, sb.ToString());
               return sb.ToString();
            }
            if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
            {
               if (sb.Length > 0)
               {
                  delta = key.Key == ConsoleKey.Backspace ? Math.Max(-1, Math.Min(--delta, sb.Length - 2)) : delta;
                  if (delta < sb.Length - 1) sb.Remove(delta + 1, 1);
                  SetCursor(prompt, sb.ToString(), Math.Max(0, delta + 1));
               }
               continue;
            }
            if (key.Key == ConsoleKey.Enter)
            {
               Console.WriteLine();
               return sb.ToString();
            }
            if (key.KeyChar == Constants.Empty) continue;

            ++delta;
            Console.Write(key.KeyChar);
            if (delta < sb.Length)
            {
               delta = Math.Max(0, Math.Min(delta, sb.Length - 1));
               sb.Insert(delta, key.KeyChar.ToString());
            }
            else sb.Append(key.KeyChar);
            SetCursor(prompt, sb.ToString(), delta + 1);
         }
      }

      private static void ProcessScript(string script)
      {
         s_PrintingCompleted = false;
         string errorMsg = null;
         Variable result = null;

         try
         {
            result = Interpreter.Instance.Process(script);
         }
         catch (Exception exc)
         {
            errorMsg = exc.Message;
            ParserFunction.InvalidateStacksAfterLevel(0);
         }

         if (!s_PrintingCompleted)
         {
            var output = Interpreter.Instance.Output;
            if (!string.IsNullOrWhiteSpace(output)) Console.WriteLine(output);
            else if (result != null)
            {
               output = result.AsString(false, false);
               if (!string.IsNullOrWhiteSpace(output)) Console.WriteLine(output);
            }
         }

         if (!string.IsNullOrWhiteSpace(errorMsg))
         {
            Utils.PrintColor(errorMsg + Environment.NewLine, ConsoleColor.Red);
            errorMsg = string.Empty;
         }
      }

      private static string GetPrompt()
      {
         const int MAX_SIZE = 30;
         var path = Directory.GetCurrentDirectory();
         if (path.Length > MAX_SIZE) path = "..." + path.Substring(path.Length - MAX_SIZE);

         return string.Format("{0}>>", path);
      }

      private static void ClearLine(string part1 = "", string part2 = "")
      {
         var spaces = new string(' ', part1.Length + part2.Length + 1);
         Console.Write("\r{0}\r", spaces);
      }

      private static void SetCursor(string prompt, string line, int pos)
      {
         ClearLine(prompt, line);
         Console.Write("{0}{1}\r{2}{3}",
            prompt, line, prompt, line.Substring(0, pos));
      }

      private static string GetFileContents(string filename)
      {
         try
         {
            var readText = Utils.GetFileLines(filename);
            return string.Join("\n", readText);
         }
         catch (ArgumentException exc)
         {
            Console.WriteLine(exc.Message);
            Environment.Exit(1);
            return "";
         }
      }

      private static void Print(object sender, OutputAvailableEventArgs e)
      {
         Console.Write(e.Output);
         s_PrintingCompleted = true;
      }

      private enum NEXT_CMD
      {
         NONE = 0,
         PREV = -1,
         NEXT = 1,
         TAB = 2
      }
   }
}