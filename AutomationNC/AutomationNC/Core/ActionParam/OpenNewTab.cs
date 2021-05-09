using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ActionParam
{
    public class OpenNewTab
    {
        public String Url { get; set; }

        public OpenNewTab(String url)
        {
            Url = url;
        }
    }
}
