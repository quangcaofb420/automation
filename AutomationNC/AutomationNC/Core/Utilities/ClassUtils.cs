using System;
using System.Collections.Generic;
using System.Linq;
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

        public static T GetStaticPropperty<T>(Type type, string staticProppertyName)
        {
            try
            {
                FieldInfo propertyInfo = type.GetFields(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(f => f.Name == staticProppertyName);
                if (propertyInfo != null)
                {
                    object value = propertyInfo.GetValue(null);
                    // Cast the value to the desired type
                    T typedValue = (T)value;
                    return typedValue;
                }              
            }
            catch (Exception ex)
            { 
            }
            return default(T);
        } 
        public static object? GetProppertyValue(object obj, string proppertyName)
        {
            try
            {
                PropertyInfo? pi = obj.GetType().GetProperty(proppertyName);
                if (pi != null)
                {
                    object value = pi.GetValue(obj, null);
                    return value;
                }
            }
            catch (Exception ex)
            { 
            }
            return null;
        }
    }
}
