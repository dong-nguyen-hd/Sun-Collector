using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunCollector
{
    internal class BusinessLogic
    {
        #region Property
        private Mem _memLib = new Mem();
        private static string[] _nameProcess = { "PlantsVsZombies", "popcapgame1" };

        private static byte[] _initial = new byte[25];
        private static bool[] _enable = new bool[25];
        private static string[] _address = new string[25];
        #endregion

        #region Method
        public async Task Initial()
        {
            Array.Clear(_initial);
            Console.Clear();
            await SunCollector();
            await PlaceAnywhere();
            await BypassSunLimit();
            await ConstantPrice();
            await ShootBackwards();
            await InstantRecharge();
        }

        #region 0-Q: Auto Collect Sun and Coins
        public async Task SunCollector()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[0]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("75 ?? 8B ?? E8 ?? ?? ?? ?? EB ?? 8B ?? E8 ?? ?? ?? ?? 83");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[0] = true;
                    scanResults = await _memLib.AoBScan("EB ?? 8B ?? E8 ?? ?? ?? ?? EB ?? 8B ?? E8 ?? ?? ?? ?? 83");
                }

                _address[0] = scanResults.FirstOrDefault().ToString("X"); // Assume is 4342F2
            }

            if (_initial[0] != 0)
            {
                // To enable, change value 75 -> EB
                // To disable, change value EB -> 75
                string writeValue = _enable[0] ? "75" : "EB";
                _memLib.WriteMemory(_address[0], "byte", writeValue);

                _enable[0] = !_enable[0]; // Switch state
            }

            _initial[0] = 1; // Turn off initial menu

            Print.Show(_enable[0], "1) Auto Collect Sun and Coins", ConsoleKey.Q.ToString(), 0);
        }
        #endregion

        #region 1-W: Place Anywhere
        public async Task PlaceAnywhere()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[1]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("0F 85 A9 04 00 00");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[1] = true;
                    scanResults = await _memLib.AoBScan("0F 84 A9 04 00 00");
                }

                 _address[1] = scanResults.FirstOrDefault().ToString("X"); // Assume is 4109C9
            }

            if (_initial[1] != 0)
            {
                // To enable: "0F 84 A9 04 00 00"
                // To disable: "0F 85 A9 04 00 00"
                string writeValue = _enable[1] ? "0F 85 A9 04 00 00" : "0F 84 A9 04 00 00";
                _memLib.WriteMemory(_address[1], "bytes", writeValue);

                _enable[1] = !_enable[1]; // Switch state
            }

            _initial[1] = 1; // Turn off initial menu

            Print.Show(_enable[1], "2) Place Anywhere", ConsoleKey.W.ToString(), 1);
        }
        #endregion

        #region 2-E: Bypass Sun Limit
        public async Task BypassSunLimit()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[2]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("7E ?? C7 80 ?? ?? ?? ?? ?? ?? ?? ?? 81");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[2] = true;
                    scanResults = await _memLib.AoBScan("EB ?? C7 80 ?? ?? ?? ?? ?? ?? ?? ?? 81");
                }

                _address[2] = scanResults.FirstOrDefault().ToString("X"); // Assume is 494445
            }

            if (_initial[2] != 0)
            {
                // To enable: "EB"
                // To disable: "7E"
                string writeValue = _enable[2] ? "7E" : "EB";
                _memLib.WriteMemory(_address[2], "byte", writeValue);

                _enable[2] = !_enable[2]; // Switch state
            }

            _initial[2] = 2; // Turn off initial menu

            Print.Show(_enable[2], "3) Bypass Sun Limit", ConsoleKey.E.ToString(), 2);
        }
        #endregion

        #region 3-R: Plants Don't get more Expensive in Endless Mode
        public async Task ConstantPrice()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[3]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("77 0C 8B D7 E8 B2 F4 FE FF");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[3] = true;
                    scanResults = await _memLib.AoBScan("77 0C 8B D7 E8 B2 F4 FE FF");
                }

                _address[3] = scanResults.FirstOrDefault().ToString("X"); // Assume is 
            }

            if (_initial[3] != 0)
            {
                // To enable: "EB 0C"
                // To disable: "77 0C"
                string writeValue = _enable[3] ? "77 0C 8B D7 E8 B2 F4 FE FF" : "EB 0C 8B D7 E8 B2 F4 FE FF";
                _memLib.WriteMemory(_address[3], "bytes", writeValue);

                _enable[3] = !_enable[3]; // Switch state
            }

            _initial[3] = 1; // Turn off initial menu

            Print.Show(_enable[3], "4) Plants Don't get more Expensive in Endless Mode", ConsoleKey.R.ToString(), 3);
        }
        #endregion

        #region 4-T: Plants shoot backwards
        public async Task ShootBackwards()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[4]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("75 20 83 7D 60 3C");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[4] = true;
                    scanResults = await _memLib.AoBScan("75 20 83 7D 60 3C");
                }

                _address[4] = scanResults.FirstOrDefault().ToString("X"); // Assume is 
            }

            if (_initial[4] != 0)
            {
                // To enable: "90 90"
                // To disable: "75 20"
                string writeValue = _enable[4] ? "75 20" : "90 90";
                _memLib.WriteMemory(_address[4], "bytes", writeValue);

                _enable[4] = !_enable[4]; // Switch state
            }

            _initial[4] = 1; // Turn off initial menu

            Print.Show(_enable[4], "5) Plants shoot backwards", ConsoleKey.T.ToString(), 4);
        }
        #endregion

        #region 5-Y: Instant recharge
        public async Task InstantRecharge()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[5]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("FF 47 24 8B 47 24");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[5] = true;
                    scanResults = await _memLib.AoBScan("FF 47 00 02 00 00");
                }

                _address[5] = scanResults.FirstOrDefault().ToString("X"); // Assume is 491E4C
            }

            if (_initial[5] != 0)
            {
                // To enable: "90 90"
                // To disable: "75 20"
                string writeValue = _enable[5] ? "FF 47 24" : "FF 47 00 02 00 00";
                _memLib.WriteMemory(_address[5], "bytes", writeValue);
                //if (!_enable[5])
                //{
                //    _memLib.WriteMemory("0041E846", "byte", "90");
                //    _memLib.WriteMemory("0041E847", "byte", "90");
                //    _memLib.WriteMemory("0041E848", "byte", "90");
                //    _memLib.WriteMemory("0041E849", "byte", "90");
                //    _memLib.WriteMemory("0041E84A", "byte", "90");
                //    _memLib.WriteMemory("0041E84B", "byte", "90");
                //}

                _enable[5] = !_enable[5]; // Switch state
            }

            _initial[5] = 1; // Turn off initial menu

            Print.Show(_enable[5], "6) Instant recharge (fix)", ConsoleKey.Y.ToString(), 5);
        }
        #endregion

        #region Regular work
        private async Task Reload(int milliSeconds = 1500)
        {
            Print.Error("game is not found or open!\n(You must rename file is: PlantsVsZombies or popcapgame1)");
            bool isSuccess = true;

            while (isSuccess)
            {
                isSuccess = !CheckConnect();
                await Task.Delay(milliSeconds);
            }

            await Initial();
        }

        private bool CheckConnect()
        {
            int count = _nameProcess.Length;
            for (int i = 0; i < count; i++)
                if (_memLib.OpenProcess(_nameProcess[i])) return true;

            return false;
        }
        #endregion

        #endregion
    }
}
