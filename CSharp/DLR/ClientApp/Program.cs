﻿using System;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

const string calculatorTypeName = "CalculatorLib.Calculator";

if (args.Length != 1)
{
   ShowUsage();
   return;
}

UsingReflection(args[0]);
UsingReflectionWithDynamic(args[0]);
return;

void ShowUsage()
{
   Console.WriteLine($"Usage: {Assembly.GetExecutingAssembly().GetName().Name} path");
   Console.WriteLine();
   Console.WriteLine("Copy CalculatorLib.dll to an addin directory");
   Console.WriteLine("and pass the absolute path of the library when starting the application");
}

void UsingReflectionWithDynamic(string addinPath)
{
   double x = 3;
   double y = 4;
   dynamic calc = GetCalculator(addinPath) ?? throw new InvalidOperationException("GetCalculator returned null");
   double result = calc.Add(x, y);
   Console.WriteLine($"the result of {x} and {y} is {result}");

   try
   {
      result = calc.Multiply(x, y); // no such method
      Console.WriteLine(result);
   }
   catch (RuntimeBinderException ex)
   {
      Console.WriteLine(ex);
   }
}

void UsingReflection(string addinPath)
{
   double x = 3;
   double y = 4;
   object calc = GetCalculator(addinPath) ?? throw new InvalidOperationException("GetCalculator returned null");

   var result = calc.GetType().GetMethod("Add")
                   ?.Invoke(calc, new object[] { x, y })
                ?? throw new InvalidOperationException("Add method not found");
   Console.WriteLine($"the result of {x} and {y} is {result}");
}

object? GetCalculator(string addinPath)
{
   Assembly assembly = Assembly.LoadFile(addinPath);
   return assembly.CreateInstance(calculatorTypeName);
}