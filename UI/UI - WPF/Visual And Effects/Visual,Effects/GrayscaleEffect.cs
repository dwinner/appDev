﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Drawing
{
   public class GrayscaleEffect : ShaderEffect
   {
      public static readonly DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0 /* assigned to sampler register S0 */);

      public GrayscaleEffect()
      {
         var pixelShaderUri = new Uri("Grayscale_Compiled.ps", UriKind.Relative);

         // Load the information from the .ps file.
         PixelShader = new PixelShader { UriSource = pixelShaderUri };

         UpdateShaderValue(InputProperty);
      }

      public Brush Input
      {
         get { return (Brush)GetValue(InputProperty); }
         set { SetValue(InputProperty, value); }
      }
   }
}