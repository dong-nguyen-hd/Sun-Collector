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
            Console.Title = "Sun Collector";
            BusinessLogic obj = new();
            Print.Start();
            await obj.Initial();

            while (true)
            {
                var readKeyValue = Console.ReadKey();

                switch (readKeyValue.Key)
                {
                    case ConsoleKey.Q:
                        await obj.SunCollector();
                        break;
                    case ConsoleKey.W:
                        await obj.PlaceAnywhere();
                        break;
                    case ConsoleKey.E:
                        await obj.BypassSunLimit();
                        break;
                    case ConsoleKey.R:
                        await obj.ConstantPrice();
                        break;
                    case ConsoleKey.T:
                        await obj.ShootBackwards();
                        break;
                    case ConsoleKey.Y:
                        await obj.InstantRecharge();
                        break;
                    case ConsoleKey.U:
                        await obj.ReverseSun();
                        break;
                    case ConsoleKey.I:
                        await obj.HealGroundDamage();
                        break;
                    case ConsoleKey.O:
                        await obj.CooldownCobCannon();
                        break;
                    case ConsoleKey.P:
                        await obj.ReverseCoins();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}