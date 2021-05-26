using Core.Common;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Utilities
{
    public static class ExtensionUtils
    {
        public static string[] ToList<T>() {
            return Enum.GetNames(typeof(T));
        }
        public static string ToDescriptionString<T>(this T val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        public static bool CanChange(this ACTION val)
        {
            return val != ACTION.Condition;
        }
        public static bool HasChildrenActions(this ACTION val)
        {
            return val == ACTION.IfCondition
                || val == ACTION.Condition
                || val == ACTION.LoopJsonFile
                || val == ACTION.LoopApiData
                ;
        }
        public static List<T> ToList<T>(this object param)
        {
            return JSONUtils.ToList<T>(param);
        }

        public static T To<T>(this object param)
        {
            return JSONUtils.To<T>(param);
        }

        public static T ToEnum<T>(this string param)
        {
            T t = (T)Enum.Parse(typeof(T), param);
            return t;
        }
    }
}
