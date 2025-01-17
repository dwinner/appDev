﻿using Xamarin.Forms;

namespace PaperBoy.Effects
{
   public static class CustomFontEffect
   {
      public static readonly BindableProperty FontFileNameProperty = BindableProperty.Create("FontFileName",
         typeof(string), typeof(CustomFontEffect), "", propertyChanged: OnFileChanged);

      public static string GetFontFileName(BindableObject view) => (string) view.GetValue(FontFileNameProperty);

      public static void SetFontFileName(BindableObject view, string value)
      {
         view.SetValue(FontFileNameProperty, value);
      }

      private static void OnFileChanged(BindableObject bindable, object oldvalue, object newvalue)
      {
         var view = bindable as View;
         if (view == null)
         {
            return;
         }

         view.Effects.Add(new FontEffect());
      }

      private class FontEffect : RoutingEffect
      {
         public FontEffect() : base("Xamarin.FontEffect")
         {
         }
      }
   }
}