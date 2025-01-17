﻿using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace TranslationByMarkupExtension
{
   /// <summary>
   ///    The Translate Markup extension returns a binding to a TranslationData
   ///    that provides a translated resource of the specified key
   /// </summary>
   public class TranslateExtension : MarkupExtension
   {
      #region Private Members

      #endregion

      #region Construction

      /// <summary>
      ///    Initializes a new instance of the <see cref="TranslateExtension" /> class.
      /// </summary>
      /// <param name="key">The key.</param>
      public TranslateExtension(string key)
      {
         Key = key;
      }

      #endregion

      [ConstructorArgument("key")]
      public string Key { get; set; }

      /// <summary>
      ///    See <see cref="MarkupExtension.ProvideValue" />
      /// </summary>
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
         var binding = new Binding("Value")
         {
            Source = new TranslationData(Key)
         };

         return binding.ProvideValue(serviceProvider);
      }
   }
}