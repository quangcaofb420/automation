using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class JSONUtils
    {
        public static T GetObjectFromJsonString<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            { }
            return default(T);
        }

        public static List<T> ToList<T>(object param)
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

        public static T To<T>(object param)
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
            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            { }
            return default(T);
        }
    }
}
