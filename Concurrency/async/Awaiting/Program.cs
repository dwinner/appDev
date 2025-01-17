﻿DisplayPrimesCount();
Console.ReadLine();

return;

async void DisplayPrimesCount()
{
   var result = await GetPrimesCountAsync(2, 1_000_000)
      .ConfigureAwait(false);
   Console.WriteLine(result);
}

Task<int> GetPrimesCountAsync(int start, int count)
{
   return Task.Run(() =>
      ParallelEnumerable.Range(start, count).Count(n =>
         Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
}