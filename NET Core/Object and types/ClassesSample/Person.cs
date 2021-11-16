public class Person
{
   public Person(string firstName, string lastName)
   {
      FirstName = firstName;
      LastName = lastName;
   }

   public string FirstName { get; }

   public string LastName { get; }

   public string FullName => $"{FirstName} {LastName}";

   public int Age { get; set; }

   public void Deconstruct(out string firstName, out string lastName, out int age)
   {
      firstName = FirstName;
      lastName = LastName;
      age = Age;
   }
}