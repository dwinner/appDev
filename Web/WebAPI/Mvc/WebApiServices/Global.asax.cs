﻿using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApiServices
{
   public class Global : HttpApplication
   {
      void Application_Start(object sender, EventArgs e)
      {
         // Код, выполняемый при запуске приложения
         AreaRegistration.RegisterAllAreas();
         GlobalConfiguration.Configure(WebApiConfig.Register);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
      }
   }
}