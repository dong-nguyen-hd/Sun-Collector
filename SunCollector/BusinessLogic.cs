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

        public byte[] _initial = new byte[10];
        private bool[] _enable = new bool[10];
        private string[] _address = new string[10];
        #endregion

        #region Method
        public async Task Initial()
        {
            await SunCollector();
            await PlaceAnywhere();
            await BypassSunLimit();
            await ConstantPrice();
            await ShootBackwards();
            await InstantRecharge();
            await ReverseSun();
            await HealGroundDamage();
            await CooldownCobCannon();
            await ReverseCoins();
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
                // To enable: "0F 84"
                // To disable: "0F 85"
                string writeValue = _enable[1] ? "0F 85" : "0F 84";
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

                _address[2] = scanResults.FirstOrDefault().ToString("X"); // Assume is 41E6F5
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

        #region 3-R: Constant Price in Endless Mode
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

                _address[3] = scanResults.FirstOrDefault().ToString("X"); // Assume is 420925
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

            Print.Show(_enable[3], "4) Constant Price in Endless Mode", ConsoleKey.R.ToString(), 3);
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

                _address[4] = scanResults.FirstOrDefault().ToString("X"); // Assume is 47229B
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
                    scanResults = await _memLib.AoBScan("FF 47 48 8B 47 24");
                }

                _address[5] = scanResults.FirstOrDefault().ToString("X"); // Assume is 491E4C
            }

            if (_initial[5] != 0)
            {
                // To enable: "FF 47 48"
                // To disable: "FF 47 24"
                string writeValue = _enable[5] ? "FF 47 24" : "FF 47 48";
                _memLib.WriteMemory(_address[5], "bytes", writeValue);

                _enable[5] = !_enable[5]; // Switch state
            }

            _initial[5] = 1; // Turn off initial menu

            Print.Show(_enable[5], "6) Instant recharge", ConsoleKey.Y.ToString(), 5);
        }
        #endregion

        #region 6-U: Reverse Sun
        public async Task ReverseSun()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[6]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("2B F3 89 B7 78 55 00 00");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[6] = true;
                    scanResults = await _memLib.AoBScan("01 DE 89 B7 78 55 00 00");
                }

                _address[6] = scanResults.FirstOrDefault().ToString("X"); // Assume is 41E844
            }

            if (_initial[6] != 0)
            {
                // To enable: "01 DE"
                // To disable: "2B F3"
                string writeValue = _enable[6] ? "2B F3" : "01 DE";
                _memLib.WriteMemory(_address[6], "bytes", writeValue);

                _enable[6] = !_enable[6]; // Switch state
            }

            _initial[6] = 1; // Turn off initial menu

            Print.Show(_enable[6], "7) Reverse Sun", ConsoleKey.U.ToString(), 6);
        }
        #endregion

        #region 7-I: Heal Ground Damage
        public async Task HealGroundDamage()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[7]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("75 05 E8 2C FD 02 00");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[7] = true;
                    scanResults = await _memLib.AoBScan("90 90 E8 2C FD 02 00");
                }

                _address[7] = scanResults.FirstOrDefault().ToString("X"); // Assume is 42057D
            }

            if (_initial[7] != 0)
            {
                // To enable: "90 90"
                // To disable: "75 05"
                string writeValue = _enable[7] ? "75 05" : "90 90";
                _memLib.WriteMemory(_address[7], "bytes", writeValue);

                _enable[7] = !_enable[7]; // Switch state
            }

            _initial[7] = 1; // Turn off initial menu

            Print.Show(_enable[7], "8) Heal Ground Damage", ConsoleKey.I.ToString(), 7);
        }
        #endregion

        #region 8-O: Cooldown for Cob Cannon
        public async Task CooldownCobCannon()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[8]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("0F 85 92 01 00 00 D9");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[8] = true;
                    scanResults = await _memLib.AoBScan("90 90 90 90 90 90 D9");
                }

                _address[8] = scanResults.FirstOrDefault().ToString("X"); // Assume is 464A0A
            }

            if (_initial[8] != 0)
            {
                // To enable: "90 90 90 90 90 90"
                // To disable: "0F 85 92 01 00 00"
                string writeValue = _enable[8] ? "0F 85 92 01 00 00" : "90 90 90 90 90 90";
                _memLib.WriteMemory(_address[8], "bytes", writeValue);

                _enable[8] = !_enable[8]; // Switch state
            }

            _initial[8] = 1; // Turn off initial menu

            Print.Show(_enable[8], "9) Cooldown for Cob Cannon", ConsoleKey.O.ToString(), 8);
        }
        #endregion

        #region 9-P: Reverse Coins
        public async Task ReverseCoins()
        {
            // Open the process and check if it was successful before the AoB scan
            if (!CheckConnect()) await Reload();

            if (string.IsNullOrEmpty(_address[9]))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("29 41 50 8B 41 50");

                if (!scanResults.GetEnumerator().MoveNext())
                {
                    _enable[9] = true;
                    scanResults = await _memLib.AoBScan("01 41 50 8B 41 50");
                }

                _address[9] = scanResults.FirstOrDefault().ToString("X"); // Assume is 4976AA
            }

            if (_initial[9] != 0)
            {
                // To enable: "01 41 50"
                // To disable: "29 41 50"
                string writeValue = _enable[9] ? "29 41 50" : "01 41 50";
                _memLib.WriteMemory(_address[9], "bytes", writeValue);

                _enable[9] = !_enable[9]; // Switch state
            }

            _initial[9] = 1; // Turn off initial menu

            Print.Show(_enable[9], "10) Reverse Coins", ConsoleKey.P.ToString(), 9);
        }
        #endregion

        #region Regular work
        private async Task Reload(int milliSeconds = 1500)
        {
            int count = _initial.Length;
            int index;
            for (index = 0; index < count; index++)
            {
                if (_initial[index] == 0)
                {
                    index = index == 0 ? 0 : index + 1;
                    Print.Error("game is not found or open!\n(You must rename file is: PlantsVsZombies or popcapgame1)", index);
                    break;
                }
            }

            bool isSuccess = true;

            while (isSuccess)
            {
                isSuccess = !CheckConnect();
                await Task.Delay(milliSeconds);
            }

            Array.Clear(_address);
            Print.RemoveError(index);
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
