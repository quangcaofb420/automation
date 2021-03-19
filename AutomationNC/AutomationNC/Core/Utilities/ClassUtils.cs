using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Utilities
{
    public class ClassUtils
    {
        public static string[] GetPropertyNames(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            // return ((IEnumerable< PropertyInfo>)properties)
            string[] str = new string[properties.Length];
            for (int i = 0; i < properties.Length; ++i)
            {
                str[i] = properties[i].Name;
            }
            return str;
        }
    }
}
