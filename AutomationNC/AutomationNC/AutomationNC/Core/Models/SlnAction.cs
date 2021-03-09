using AutomationNC.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationNC.Core.Models
{
    class SlnAction
    {
        public static readonly SlnAction OpenWebsite = new SlnAction() { Name = ACTION.OPEN_WEBSITE, RequiredElement = false, Params = new string[] { "Browser", "Url"} };
        public static readonly SlnAction Exit = new SlnAction() { Name = ACTION.EXIT, RequiredElement = false};

        public ACTION Name { get; set; }
        public bool RequiredElement { get; set; }
        public string[] Params { get; set; }
        public SlnAction()
        { 
        }
    }
}
