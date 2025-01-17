﻿using Stateless;
using static System.Console;

namespace LightSwitchStateless;

internal static class Program
{
   private static void Main()
   {
      // false = off, true = on

      var light = new StateMachine<bool, Trigger>(false);

      light.Configure(false) // if the light is off...
         .Permit(Trigger.On, true) // we can turn it on
         .OnEntry(transition => { WriteLine(transition.IsReentry ? "Light is already off!" : "Switching light off"); })
         .PermitReentry(Trigger.Off);
      // .Ignore(Trigger.Off) // but if it's already off we do nothing

      // same for when the light is on
      light.Configure(true)
         .Permit(Trigger.Off, false)
         .OnEntry(() => WriteLine("Turning light off"))
         .Ignore(Trigger.On);

      light.Fire(Trigger.On); // Turning light on
      light.Fire(Trigger.Off); // Turning light off
      light.Fire(Trigger.Off); // Light is already off!
   }
}