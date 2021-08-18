﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using Events;

namespace PageEvents
{
   public partial class Default : Page
   {
      protected void Page_PreInit(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "PreInit");
      }

      protected void Page_Init(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "Init");
      }

      protected void Page_InitComplete(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "InitComplete");
         /* NOTE: Самое раннее безопасное место для установки обработчиков событий для элементов управления
         Counter.Count +=
            (sender, eventArgs) =>
               EventCollection.Add(EventSource.Page, string.Format("Control - Counter: {0}", eventArgs.Counter));*/
      }

      protected void Page_PreLoad(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "PreLoad");
      }

      protected void Page_Load(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "Load");
      }

      protected void Page_LoadComplete(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "LoadComplete");
      }

      protected void Page_PreRender(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "PreRender");
      }

      protected void Page_PreRenderComplete(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "PreRenderComplete");
      }

      protected void Page_SaveStateComplete(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "SaveStateComplete");
      }

      protected override void Render(HtmlTextWriter writer)
      {
         EventCollection.Add(EventSource.Page, "Render");
         base.Render(writer);
      }

      protected void Page_Unload(object src, EventArgs args)
      {
         EventCollection.Add(EventSource.Page, "Unload");
      }

      public IEnumerable<EventDescription> GetEvents()
      {
         return EventCollection.Events;
      }

      protected void HandleEvent(object src, ViewCounterEventArgs args)
      {
         EventCollection.Add(EventSource.Page, string.Format("Control - Counter: {0}", args.Counter));
      }
   }
}