﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using geolocation_plugin.Interfaces;
using geolocation_plugin.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace geolocation_plugin.iOS.Services
{
   public class GeoLocation : IGeolocation, INotifyPropertyChanged
   {
      private Position _location;

      public Position Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      public GeoData GetLocationData()
      {
         var loc = new GeoData
         {
            Latitude = Location.Latitude,
            Longitude = Location.Longitude,
            Altitude = Location.Latitude,
            Heading = Location.Heading,
            Speed = Location.Speed
         };
         return loc;
      }

      public bool IsListening() => CrossGeolocator.Current.IsListening;

      public void StartListening()
      {
         var delayInSeconds = TimeSpan.FromSeconds(3);
         CrossGeolocator.Current.StartListeningAsync(delayInSeconds, 10, true);
         if (CrossGeolocator.Current.IsListening)
         {
            CrossGeolocator.Current.GetPositionAsync(delayInSeconds).ContinueWith(t =>
            {
               if (t.IsCompleted)
               {
                  Location = t.Result;
               }
            });
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
   }
}