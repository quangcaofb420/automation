
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
        public static SlnScript If(params IfCondition[] coditions)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.IfCondition;
            script.Param = coditions;
            return script;
        } 
         public static SlnScript GetLabel(GetLabel param)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.GetLabel;
            script.Param = param;
            return script;
        } 
        public static SlnScript GetTextValue(GetTextValue param)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.GetTextValue;
            script.Param = param;
            return script;
        } 

        public static SlnScript Input(Input param)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.Input;
            script.Param = param;
            return script;
        }
        public static SlnScript Click(Click param)
        {
            SlnScript script = new SlnScript();
            script.Action = SlnAction.Click;
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