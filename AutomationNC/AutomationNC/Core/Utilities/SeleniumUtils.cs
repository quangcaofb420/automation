
namespace Core.Utilities
{
    public class SeleniumUtils
    {
        public static string GetWebDriverExecutePath()
        {
            return FolderUtils.GetWorkingFolder();
        }
    }

}
