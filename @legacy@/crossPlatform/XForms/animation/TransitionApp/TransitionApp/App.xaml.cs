﻿using Plugin.SharedTransitions;
using Prism;
using Prism.Ioc;
using TransitionApp.ViewModels;
using TransitionApp.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TransitionApp
{
   [AutoRegisterForNavigation]
   public partial class App
   {
      /* 
        * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
        * This imposes a limitation in which the App class must have a default constructor. 
        * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
        */
      public App() : this(null)
      {
      }

      public App(IPlatformInitializer initializer) : base(initializer)
      {
      }

      protected override void OnInitialized()
      {
         InitializeComponent();

         NavigationService.NavigateAsync($"{nameof(SharedTransitionNavigationPage)}/{nameof(MainPage)}");
      }

      protected override void RegisterTypes(IContainerRegistry containerRegistry)
      {
         containerRegistry.RegisterForNavigation<SharedTransitionNavigationPage>();
         containerRegistry.RegisterForNavigation<DynamicSampleTo2, DynamicSampleToViewModel>();
      }
   }
}