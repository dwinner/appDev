using RxHelpers;

namespace SimpleAsyncProgram;

internal class MakingAsyncWithTaskRun
{
   public static async Task AsyncMethodCaller()
   {
      Console.WriteLine();
      Demo.DisplayHeader("Using Task.Run(...) to create async code");

      var isSame = await MyAsyncMethod(Environment.CurrentManagedThreadId);
      Console.WriteLine("Caller thread is the same as executing thread: {0}", isSame); //this will print 'false'
   }

   private static async Task<bool> MyAsyncMethod(int callingThreadId)
   {
      return await Task.Run(() => Environment.CurrentManagedThreadId == callingThreadId);
   }
}