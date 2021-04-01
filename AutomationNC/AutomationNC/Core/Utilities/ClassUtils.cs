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

        public static object Constructor(Type type, object[] args)
        {
            Type[] types = args.Select(p => p.GetType()).ToArray();
            ConstructorInfo ctor = type.GetConstructor(types);
            object instanceArg = ctor.Invoke(args);
            return instanceArg;
        }

        public static object CallStaticFunction(Type type, string staticFunctionName, object[] args)
        {
            MethodInfo? methodInfo = type.GetMethod(staticFunctionName, BindingFlags.Public | BindingFlags.Static);
            if (methodInfo == null)
            {
                return null;
            }
            object? res = methodInfo.Invoke(null, args);

            return res ?? null;
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
