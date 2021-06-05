﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests
{
   public class PluralizationDesignTimeService : IDesignTimeServices, IPluralizer
   {
      public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
      {
         serviceCollection.AddSingleton<IPluralizer>(this);
      }

      public string Pluralize(string identifier) => identifier;

      public string Singularize(string identifier) => identifier;
   }
}