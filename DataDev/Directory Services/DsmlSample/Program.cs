﻿using System;
using System.DirectoryServices.Protocols;
using System.Net;

namespace DsmlSample
{
   internal static class Program
   {
      private static void Main()
      {
         var uri = new Uri("http://dsmlserver/dsml");
         var identifier = new DsmlDirectoryIdentifier(uri);

         var credentials = new NetworkCredential
         {
            UserName = "cnagel",
            Password = "password",
            Domain = "explorer"
         };

         var dsmlConnection = new DsmlSoapHttpConnection(identifier, credentials);

         //string distinguishedName = null;
         const string ldapFilter = "(objectClass=user)";
         //string[] attributesToReturn = null;

         var searchRequest = new SearchRequest(null, ldapFilter, SearchScope.Subtree, null/*return all attributes*/);
         var searchResponse = (SearchResponse) dsmlConnection.SendRequest(searchRequest);

         Console.WriteLine("\r\nSearch matched {0} entries:", searchResponse.Entries.Count);
         foreach (SearchResultEntry entry in searchResponse.Entries)
         {
            Console.WriteLine(entry.DistinguishedName);

            // retrieve a specific attribute
            var attribute = entry.Attributes["ou"];
            Console.WriteLine("{0} = {1}", attribute.Name, attribute[0]);

            // retrieve all attributes
            foreach (DirectoryAttribute attr in entry.Attributes.Values)
            {
               Console.Write("{0}=", attr.Name);

               // retrieve all values for the attribute
               // the type of the value can be one of string, byte[] or Uri
               foreach (var value in attr) Console.Write("{0} ", value);
               Console.WriteLine();
            }
         }
      }
   }
}