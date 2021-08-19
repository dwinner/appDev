﻿using System;
using System.DirectoryServices;
using System.Runtime.InteropServices;

namespace DirectoryServicesSamples
{
   internal static class Program
   {
      private static void DirectoryEntry()
      {
         try
         {
            using (var de = new DirectoryEntry())
            {
               de.Path = "LDAP://magellan/CN=Christian Nagel, " +
                         "OU=thinktecture, DC=cninnovation, DC=local";

               Console.WriteLine("Name: {0}", de.Name);
               Console.WriteLine("GUID: {0}", de.Guid);
               Console.WriteLine("Type: {0}", de.SchemaClassName);
               Console.WriteLine();

               Console.WriteLine("Properties: ");
               var properties = de.Properties;
               foreach (string name in properties.PropertyNames)
               foreach (var o in properties[name])
                  Console.WriteLine("{0}: {1}", name, o);
            }
         }
         catch (COMException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      private static void RootDse()
      {
         try
         {
            using (var de = new DirectoryEntry())
            {
               de.Path = "LDAP://magellan/rootDSE";
               de.Username = @"cninnovation\christian";
               de.Password = "Pa$$w0rd";

               var props = de.Properties;
               foreach (string prop in props.PropertyNames)
               {
                  var values = props[prop];
                  foreach (string val in values)
                  {
                     Console.Write("{0}: ", prop);
                     Console.WriteLine(val);
                  }
               }
            }
         }
         catch (COMException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      private static void Children()
      {
         using (var de = new DirectoryEntry())
         {
            de.Path = "LDAP://magellan/OU=thinktecture, " +
                      "DC=cninnovation, DC=local";

            de.Children.SchemaFilter.Add("user");
            Console.WriteLine("Children of " + de.Name);
            foreach (DirectoryEntry obj in de.Children) Console.WriteLine(obj.Name);
         }
      }

      private static void AddObject()
      {
         var de = new DirectoryEntry
         {
            Path = "LDAP://magellan/CN=Users, DC=cninnovation, DC=local"
         };

         var users = de.Children;

         var user = users.Add("CN=John Doe", "user");
         user.Properties["company"].Add("Some Company");
         user.Properties["department"].Add("Sales");
         user.Properties["employeeID"].Add("4711");
         user.Properties["samAccountName"].Add("JDoe");
         user.Properties["userPrincipalName"].Add("JDoe@explorer.local");
         user.Properties["givenName"].Add("John");
         user.Properties["sn"].Add("Doe");
         user.Properties["userPassword"].Add("someSecret");

         user.CommitChanges();
      }

      private static void Search()
      {
         using (var de = new DirectoryEntry("LDAP://magellan/OU=thinktecture, DC=cninnovation, DC=local"))
         using (var searcher = new DirectorySearcher())
         {
            searcher.SearchRoot = de;
            searcher.Filter = "(&(objectClass=user)(description=Auth*))";
            searcher.SearchScope = SearchScope.Subtree;

            searcher.PropertiesToLoad.Add("name");
            searcher.PropertiesToLoad.Add("description");
            searcher.PropertiesToLoad.Add("givenName");
            searcher.PropertiesToLoad.Add("wWWHomePage");

            searcher.Sort = new SortOption("givenName", SortDirection.Ascending);

            var results = searcher.FindAll();

            foreach (SearchResult result in results)
            {
               var props = result.Properties;
               foreach (string propName in props.PropertyNames)
               {
                  Console.Write("{0}: ", propName);
                  Console.WriteLine(props[propName][0]);
               }

               Console.WriteLine();
            }
         }
      }

      private static void Main()
      {
         RootDse();
         DirectoryEntry();
         Children();
         AddObject();
         Search();
      }
   }
}