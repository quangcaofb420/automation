using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class FolderUtils
    {
        public static string GetWorkingFolder()
        {
            return @"C:\QuangCaoFB420";
        }

        public static string GetDataFolder()
        {
            return GetWorkingFolder() + @"\Data" ;
        }  
        public static string GetSettingFolder()
        {
            return GetWorkingFolder() + @"\Setting" ;
        }
    }
}
