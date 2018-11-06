﻿using System;
using Newtonsoft.Json;

namespace SatelliteMovingApp.Code
{
   [JsonObject(MemberSerialization.OptIn)]
   public sealed class Satellite : IEquatable<Satellite>
   {
      private const long DefaultRoundingTime = 0;
      private const float DefaultDistance = .0F;

      public Satellite()
         : this(DefaultRoundingTime, DefaultDistance)
      {
      }

      public Satellite(long currentTime, float currentDistance)
      {
         RoundingTime = currentTime;
         Distance = currentDistance;
         Angle = RandomAngle();
      }

      [JsonProperty]
      public long RoundingTime { get; }

      [JsonProperty]
      public float Distance { get; }

      [JsonProperty]
      public float Angle { get; }

      public bool Equals(Satellite other) => !ReferenceEquals(null, other) &&
                                             (ReferenceEquals(this, other) || RoundingTime == other.RoundingTime &&
                                              Distance.Equals(other.Distance) &&
                                              Angle.Equals(other.Angle));

      private static float RandomAngle() => (float) (2 * Math.PI * new Random().NextDouble());

      public override bool Equals(object obj) => !ReferenceEquals(null, obj) &&
                                                 (ReferenceEquals(this, obj) ||
                                                  obj is Satellite other && Equals(other));

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = RoundingTime.GetHashCode();
            hashCode = (hashCode * 397) ^ Distance.GetHashCode();
            hashCode = (hashCode * 397) ^ Angle.GetHashCode();
            return hashCode;
         }
      }

      public static bool operator ==(Satellite left, Satellite right) => Equals(left, right);

      public static bool operator !=(Satellite left, Satellite right) => !Equals(left, right);
   }
}