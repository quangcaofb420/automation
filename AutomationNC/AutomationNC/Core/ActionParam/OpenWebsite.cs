
using System;

namespace Core.ActionParam
{
    public class OpenWebsite
    {
        public String Browser { get; set; }
        public String Url { get; set; }

        public OpenWebsite(String browser, String url)
        {
            Browser = browser;
            Url = url;
        }
    }
}
