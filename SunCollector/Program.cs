// Business logic code based on:
// TheInsaneHacker: https://fearlessrevolution.com/viewtopic.php?f=4&t=10171
// STN: https://fearlessrevolution.com/viewtopic.php?t=3916
// Thank you all

using System;
using System.Threading.Tasks;

namespace SunCollector
{
    internal class Program
    {
        #region Method
        static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Initial process
            await Work(true);

            while (true)
            {
                var readKeyValue = Console.ReadKey();

                if (ConsoleKey.Spacebar == readKeyValue.Key) await Work();
            }
        }

        private static async Task Work(bool initial = false)
        {
            BusinessLogic obj = new();

            Console.Clear();
            Print.Start();

            var result = await obj.Initial(initial);

            if (result.isSuccess)
                Print.Show(result.isEnable);
            else
                await obj.Reload();
        }
        #endregion
    }
}