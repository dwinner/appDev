﻿namespace OCP_Sample;

public class ProductFilter
{
   // let's suppose we don't want ad-hoc queries on products
   public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
   {
      return products.Where(p => p.Color == color);
   }

   public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
   {
      return products.Where(p => p.Size == size);
   }

   public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color) =>
      products.Where(p => p.Size == size && p.Color == color); // state space explosion
   // 3 criteria = 7 methods

   // OCP = open for extension but closed for modification
}