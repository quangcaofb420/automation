
namespace Core.Utilities
{
    public class SeleniumUtils
    {
        public static string GetWebDriverExecutePath()
        {
            return GetWorkingFolderPath();
        }

        public static string GetWorkingFolderPath()
        {
            return @"D:\LONG\automation";
        }
    }
}
