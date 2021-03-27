using Core.Common;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class CommonUtils
    {
        public static async Task Sleep(int second)
        {
            await Task.Delay(2000); // Wait 2 seconds without blocking
        }
    }
}
