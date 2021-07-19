﻿using System;

namespace _08_RelationUsingAnnotations
{
   internal static class Program
   {
      private static void Main()
      {
         CreateDatabase();
         AddBooks();
         DeleteDatabase();
      }

      private static void DeleteDatabase()
      {
         Console.Write("Delete the database? ");

         var input = Console.ReadLine();
         if (input?.ToLower() == "y")
         {
            using var context = new BooksContext();
            context.Database.EnsureDeleted();
         }
      }

      private static void CreateDatabase()
      {
         using var context = new BooksContext();
         var created = context.Database.EnsureCreated();
         Console.WriteLine($"database created: {created}");
      }

      private static void AddBooks()
      {
         Console.WriteLine(nameof(AddBooks));

         using var context = new BooksContext();
         var author = new User
         {
            Name = "Christian Nagel"
         };
         var reviewer = new User
         {
            Name = "Istvan Novak"
         };
         var editor = new User
         {
            Name = "Charlotte Kughen"
         };
         var b1 = new Book
         {
            Title = "Professional C# 7 and .NET Core 2.0",
            ProjectEditor = editor,
            Reviewer = reviewer,
            Author = author
         };

         var c1 = new Chapter
         {
            Title = ".NET Applications and Tools",
            Number = 1
         };
         var c2 = new Chapter
         {
            Title = "Core C#",
            Number = 2
         };
         var c3 = new Chapter
         {
            Title = "Entity Framework Core",
            Number = 28
         };

         b1.Chapters.AddRange(new[] {c1, c2, c3});
         context.Books.Add(b1);
         context.Users.AddRange(author, editor, reviewer);
         context.Chapters.AddRange(c1, c2, c3);

         var records = context.SaveChanges();
         Console.WriteLine($"{records} records added");

         Console.WriteLine();
      }
   }
}