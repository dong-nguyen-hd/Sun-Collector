using Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunCollector
{
    internal class BusinessLogic
    {
        #region Property
        private Mem _memLib = new Mem();
        private static string _address = string.Empty;
        #endregion

        #region Method
        public async Task<(bool isSuccess, bool isEnable)> Initial(bool initial = false)
        {
            // Open the process and check if it was successful before the AoB scan
            if (!_memLib.OpenProcess("PlantsVsZombies"))
            {
                _address = string.Empty;
                Print.Error("game is not found or open!\n(You must rename file is: PlantsVsZombies)");
                return (false, false);
            }

            if (string.IsNullOrEmpty(_address))
            {
                IEnumerable<long> scanResults = await _memLib.AoBScan("75 ?? 8B ?? E8 ?? ?? ?? ?? EB ?? 8B ?? E8 ?? ?? ?? ?? 83");

                _address = scanResults.GetEnumerator().MoveNext() ? scanResults.FirstOrDefault().ToString("X") : "4342F2"; // Assume is 4342F2
            }

            var tempEnable = Switch(initial);
            _memLib.CloseProcess();

            return (true, tempEnable);
        }

        private bool Switch(bool initial = false)
        {
            var valueAddress = _memLib.ReadByte(_address); // Assume is 117

            if (initial) return !valueAddress.Equals(117);

            string writeValue = valueAddress.Equals(117) ? "EB" : "75";

            // To enable, change value 75 -> EB
            // To disable, change value EB -> 75
            _memLib.WriteMemory(_address, "byte", writeValue);

            return writeValue.Equals("EB");
        }

        public async Task Reload(int milliSeconds = 1000)
        {
            bool isSuccess = true;

            while (isSuccess)
            {
                isSuccess = !_memLib.OpenProcess("PlantsVsZombies");
                await Task.Delay(milliSeconds);
            }

            _memLib.CloseProcess();
            Print.Show(false);
        }
        #endregion
    }
}
