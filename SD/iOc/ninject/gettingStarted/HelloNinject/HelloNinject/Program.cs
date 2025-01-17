﻿using System;
using Ninject;

namespace HelloNinject
{
   internal static class Program
   {
      private static void Main()
      {
         using (var kernel = new StandardKernel())
         {
            var service = kernel.Get<SalutationService>();
            service.SayHello();
         }
      }
   }
   
   internal class SalutationService
   {
      public void SayHello() => Console.WriteLine("Hello Ninject!");
   }
}