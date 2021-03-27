using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Utilities
{
    public static class ExtensionUtils
    {
        public static string ToDescriptionString(this ACTION val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
