﻿using System;

namespace ObjectsCloning.CloneHelpers // Note: Клонирование, ориентированное на аспекты
{
   public sealed class Dimension : ICloneable
   {
      public Dimension(long width, long height)
      {
         Width = width;
         Height = height;
      }

      public long Width { get; set; }

      public long Height { get; set; }

      [CloneStyle(CloneStyle.Deep)]
      public object Clone() => MemberwiseClone();
   }
}