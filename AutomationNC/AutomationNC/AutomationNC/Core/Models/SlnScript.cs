using AutomationNC.Core.ActionParam;
using AutomationNC.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationNC.Core.Models
{
    class SlnScript
    {
        public SlnAction Action { get; set; }
        public SlnControl Control { get; set; }
        public object Param { get; set; }

        public static SlnScript OpenWebsite(OpenWebsite param)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.OpenWebsite;
            script.Control = null;
            script.Param = param;
            return script;
        }
        public static SlnScript Exit()
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.Exit;
            script.Control = null;
            script.Param = null;
            return script;
        }

    }
}