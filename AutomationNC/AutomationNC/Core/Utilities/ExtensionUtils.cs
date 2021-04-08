﻿using Core.Common;
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
        public static string ToDescriptionString(this ACTION val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        public static List<T> ToList<T>(this object param)
        {
            try
            {
                string str = JsonConvert.SerializeObject(param);
                return JsonConvert.DeserializeObject<List<T>>(str);
            }
            catch (Exception ex)
            { }
            return null;
        }
        public static T To<T>(this object param)
        {
            //try
            //{
            //    T t = (T)param;
            //    if (t != null)
            //    {
            //        return t;
            //    }
            //}
            //catch (Exception ex) { }
            string str = JsonConvert.SerializeObject(param);
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static T ToEnum<T>(this string param)
        {
            T t = (T)Enum.Parse(typeof(T), param);
            return t;
        }
    }
}
