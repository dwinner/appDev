﻿using System;
using BooksLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BooksContextFactory : IDesignTimeDbContextFactory<BooksContext>
{
   public BooksContext CreateDbContext(string[] args)
   {
      if (args.Length < 1)
      {
         Console.WriteLine("please supply a connection string");
         Environment.Exit(-1);
         return null!;
      }

      string connectionString = args[0];
      DbContextOptionsBuilder<BooksContext> optionsBuilder = new();
      optionsBuilder.UseSqlServer(connectionString);
      return new BooksContext(optionsBuilder.Options);
   }
}