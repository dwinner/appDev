﻿using System;

namespace Variance
{
   public class RectangeCollection : IIndex<Rectangle>
   {
      private static RectangeCollection _collection;

      private readonly Rectangle[] _data =
      {
         new Rectangle {Height = 2, Width = 5},
         new Rectangle {Height = 3, Width = 7},
         new Rectangle {Height = 4.5, Width = 2.9}
      };

      public static RectangeCollection Rectangles =>
         _collection ?? (_collection = new RectangeCollection());

      public Rectangle this[int index]
      {
         get
         {
            if (index < 0 || index > _data.Length)
            {
               throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _data[index];
         }
      }

      public int Count => _data.Length;
   }
}