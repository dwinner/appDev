﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Denis
 * Дата: 03.01.2013
 * Время: 8:14
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections;

namespace CustomEnumerator
{
   class Program
   {
      public static void Main(string[] args)
      {
         Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
         Garage carLot = new Garage();

         // Hand over each car in the collection?
         foreach (Car c in carLot)
         {
             Console.WriteLine("{0} is going {1} MPH",
                c.PetName,
                c.CurrentSpeed);
         }

         Console.WriteLine();

         // Manually work with IEnumerator.
         IEnumerator i = carLot.GetEnumerator();
         i.MoveNext();
         Car myCar = (Car)i.Current;
         Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);

         Console.ReadLine();
         
         Console.Write("Press any key to continue . . . ");
         Console.ReadKey(true);
      }
   }
}