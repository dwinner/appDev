﻿/**
 * Исполняемая сборка для загрузки в другом домене приложения
 */

using System;

namespace AssemblyA
{
   class Program
   {
      static void Main()
      {
         Console.WriteLine("Main in domain {0} called", AppDomain.CurrentDomain.FriendlyName);
      }
   }

   public class Demo
   {
      public Demo(int val1, int val2)
      {
         Console.WriteLine("Constructor with the values {0}, {1} in domain {2} called", val1, val2,
            AppDomain.CurrentDomain.FriendlyName);
      }
   }
}
