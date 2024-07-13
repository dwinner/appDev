namespace Fundamentals;

public static class TypeConversion
{
   public static object Convert(Type type, object value)
   {
      var val = new object();
      if (type.IsGuid())
      {
         if (value.GetType().IsGuid())
         {
            val = value;
         }
         else if (value.GetType().IsString())
         {
            val = Guid.Parse(value.ToString()!);
         }
         else
         {
            val = value.GetType() == typeof(byte[]) 
               ? new Guid((value as byte[])!) 
               : (object)Guid.Empty;
         }
      }
      else if (type.IsString())
      {
         val = value;
      }
      else if (type.IsDate())
      {
         val = value;
      }
      else if (type.IsDateOnly())
      {
         if (value is DateOnly)
         {
            val = value;
         }
         else if (DateOnly.TryParse(value.ToString(), out var dateOnlyValue))
         {
            val = dateOnlyValue;
         }
         else
         {
            val = default(DateOnly);
         }
      }
      else if (type.IsTimeOnly())
      {
         if (value is TimeOnly)
         {
            val = value;
         }
         else if (TimeOnly.TryParse(value.ToString(), out var timeOnlyValue))
         {
            val = timeOnlyValue;
         }
         else
         {
            val = default(TimeOnly);
         }
      }
      else if (type.IsDateTimeOffset())
      {
         if (value is DateTimeOffset)
         {
            val = value;
         }
         else if (DateTimeOffset.TryParse(value.ToString(), out var dateTimeOffsetValue))
         {
            val = dateTimeOffsetValue;
         }
         else
         {
            val = default(DateTimeOffset);
         }
      }
      else if (type.IsAPrimitiveType())
      {
         val = value;
      }

      if (val is not null && val.GetType() != type && !IsGuidFromString(type, val))
      {
         val = System.Convert.ChangeType(val, type, null);
      }

      return val!;
   }

   private static bool IsGuidFromString(Type genericArgumentType, object value) =>
      genericArgumentType == typeof(Guid) && value is string;
}