using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace Core.Utilities
{
    public class HttpApiUtils
    {
        public static T[] GetArray<T>(string api, string pathToPropperty)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(api).Result;
            T[] objs = null;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                if (pathToPropperty == "")
                {
                    objs = JSONUtils.GetObjectFromJsonString<T[]>(data);
                }
                else
                {
                    dynamic obj = JSONUtils.GetObjectFromJsonString<ExpandoObject>(data);
                    string[] paths = pathToPropperty.Split("/");
                    foreach (string path in paths)
                    {
                        if (path != "")
                        {
                            obj = ((IDictionary<string, object>)obj)[path];
                        }
                    }
                    objs = ((System.Collections.IList)obj).ToList<T>().ToArray();
                }
            }
            if (objs == null)
            {
                objs = new T[] { };
            }
            return objs;
        }

    }
}
