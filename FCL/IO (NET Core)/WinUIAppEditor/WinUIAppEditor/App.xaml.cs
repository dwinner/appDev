﻿using Microsoft.UI.Xaml;

namespace WinUIAppEditor
{
   public partial class App
   {
      private Window? _window;

      public App()
      {
         InitializeComponent();
      }

      protected override void OnLaunched(LaunchActivatedEventArgs args)
      {
         _window = new MainWindow();
         _window.Activate();
      }
   }
}