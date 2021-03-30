
using Core.ActionParam;
using Core.Common;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class SlnScript
    {
        public string Action { get; set; }
        public string Control { get; set; }
        public object Param { get; set; }

        private string _id;
        public SlnScript()
        {
            this._id = System.Guid.NewGuid().ToString();
        }

        public string GetId()
        {
            return this._id;
        }
        public static SlnScript OpenWebsite(OpenWebsite param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.OPEN_WEBSITE.ToDescriptionString();
            script.Param = param;
            return script;
        } 
        public static SlnScript If(IfCondition ifCondition)
        {
            List<SlnScript> scripts = ifCondition.Conditions.Select(i =>  SlnScript.Condition(i)).ToList();
            SlnScript script = new SlnScript();
            script.Action = ACTION.IF_CONDITION.ToDescriptionString();
            script.Param = scripts;
            return script;
        } 
        public static SlnScript Condition(Condition condition)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.CONDITION.ToDescriptionString();
            script.Param = condition;
            return script;
        } 
         public static SlnScript GetLabel(GetLabel param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.GET_LABEL.ToDescriptionString();
            script.Param = param;
            return script;
        } 
        public static SlnScript GetTextValue(GetTextValue param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.GET_TEXT_VALUE.ToDescriptionString();
            script.Param = param;
            return script;
        } 

        public static SlnScript Input(Input param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.INPUT.ToDescriptionString();
            script.Param = param;
            return script;
        }
        public static SlnScript Click(Click param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.CLICK.ToDescriptionString();
            script.Param = param;
            return script;
        }
        public static SlnScript Exit()
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.EXIT.ToDescriptionString();
            return script;
        } 
        public static SlnScript Sleep(Sleep param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.SLEEP.ToDescriptionString();
            script.Param = param;
            return script;
        }
    }
}