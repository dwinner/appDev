namespace AOP.Todo;

public class TodoService : ITodoService
{
   public void Add(string item)
   {
      Console.WriteLine($"Adding '{item}' to the todo list");
   }
}