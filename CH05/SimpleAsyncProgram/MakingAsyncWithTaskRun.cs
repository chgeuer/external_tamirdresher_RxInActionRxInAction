using Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsyncProgram
{
    internal class MakingAsyncWithTaskRun
    {
        public static async Task AsyncMethodCaller()
        {
            Console.WriteLine();
            Demo.DisplayHeader("Using Task.Run(...) to create async code");

            bool isSame = await MyAsyncMethod(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Caller thread is the same as executing thread: {0}", isSame);//this will print 'false'
        }

        private static async Task<bool> MyAsyncMethod(int callingThreadId)
        {
            return await Task.Run(() => Thread.CurrentThread.ManagedThreadId == callingThreadId);
        }

    }
}