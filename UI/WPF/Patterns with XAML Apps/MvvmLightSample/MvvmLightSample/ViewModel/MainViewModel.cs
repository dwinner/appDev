﻿using GalaSoft.MvvmLight;
using MvvmLightSample.Model;

namespace MvvmLightSample.ViewModel
{
   /// <summary>
   ///    This class contains properties that the main View can data bind to.
   ///    <para>
   ///       See http://www.mvvmlight.net
   ///    </para>
   /// </summary>
   public class MainViewModel : ViewModelBase
   {
      /// <summary>
      ///    The <see cref="WelcomeTitle" /> property's name.
      /// </summary>
      public const string WelcomeTitlePropertyName = "WelcomeTitle";

      private readonly IDataService _dataService;

      private string _welcomeTitle = string.Empty;

      /// <summary>
      ///    Initializes a new instance of the MainViewModel class.
      /// </summary>
      public MainViewModel(IDataService dataService)
      {
         _dataService = dataService;
         _dataService.GetData(
            (item, error) =>
            {
               if (error != null)
               {
                  // Report error here
                  return;
               }

               WelcomeTitle = item.Title;
            });
      }

      /// <summary>
      ///    Gets the WelcomeTitle property.
      ///    Changes to that property's value raise the PropertyChanged event.
      /// </summary>
      public string WelcomeTitle
      {
         get => _welcomeTitle;
         set => Set(ref _welcomeTitle, value);
      }

      ////public override void Cleanup()
      ////{
      ////    // Clean up if needed

      ////    base.Cleanup();
      ////}
   }
}