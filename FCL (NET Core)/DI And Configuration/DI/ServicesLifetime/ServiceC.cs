﻿using System;
using Microsoft.Extensions.Options;

public class ConfigurationC
{
   public string? Mode { get; set; }
}

public sealed class ServiceC : IServiceC, IDisposable
{
   private readonly string? _mode;
   private readonly int _n;
   private bool _isDisposed;

   public ServiceC(INumberService numberService, IOptions<ConfigurationC> options)
   {
      _mode = options.Value.Mode;
      _n = numberService.GetNumber();
      Console.WriteLine($"ctor {nameof(ServiceC)}, {_n}");
   }

   public void Dispose()
   {
      Console.WriteLine($"disposing {nameof(ServiceC)}, {_n}");
      _isDisposed = true;
   }

   public void C()
   {
      if (_isDisposed)
      {
         throw new ObjectDisposedException("ServiceC");
      }

      Console.WriteLine($"{nameof(C)}, {_n}, mode: {_mode}");
   }
}