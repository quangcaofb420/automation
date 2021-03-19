
using Core.ActionParam;
using System;

namespace Core.Models
{
    public class SlnScript
    {
        public SlnAction Action { get; set; }
        public SlnControl Control { get; set; }
        public object Param { get; set; }

        public static SlnScript OpenWebsite(OpenWebsite param)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.OpenWebsite;
            script.Param = param;
            return script;
        }
        public static SlnScript Exit()
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.Exit;
            return script;
        }
    }
}