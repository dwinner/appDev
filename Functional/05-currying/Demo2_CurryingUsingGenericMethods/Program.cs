﻿using CustomLibrary;
using static System.Console;

WriteLine("Applying the concept of currying.");
int a = 10, b = 2;
// Common approach
var result = new Sample().AddTwoNumbers(a, b);
//var result1 = new Sample().AddTwoNumbers(a);// Error CS7036
WriteLine($"{a}+{b} is {result}");

// Currying using non-generic method
var total = new Sample().AddTwoNumbers.Curry()(a)(b);
WriteLine($"{a}+{b} is {total}");
//int total2 = new Sample().AddTwoNumbers.Curry()(10.5)(4.5);// Error CS1503
//WriteLine($"{a}+{b} is {total2}");

// Currying using generic method
var total3 = new Sample().AddTwoNumbers.GenericCurry()(a)(b);
WriteLine($"{a}+{b} is {total3}");

var total4 = new Sample().AddTwoNonIntegers.GenericCurry()(10.5)(4.5);
WriteLine($"{a}+{b} is {total4}");


internal class Sample
{
   public Func<double, double, double> AddTwoNonIntegers = (first, second) => first + second;
   public Func<int, int, int> AddTwoNumbers = (first, second) => first + second;
}

namespace CustomLibrary
{
   public static class CurryExtensions
   {
      public static Func<int, Func<int, int>> Curry(this Func<int, int, int> f)
      {
         return x => y => f(x, y);
      }

      public static Func<T, Func<T, T>> GenericCurry<T>(this Func<T, T, T> f)
      {
         return x => y => f(x, y);
      }
   }
}