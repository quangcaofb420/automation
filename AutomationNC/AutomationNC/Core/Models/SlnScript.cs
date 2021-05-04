
using Core.ActionParam;
using Core.Common;
using Core.Utilities;
using System;

namespace Core.Models
{
    public class SlnScript
    {
        public String Action { get; set; }
        public String Control { get; set; }
        public object Param { get; set; }

        private string _id;
        public SlnScript()
        {
            this._id = CommonUtils.UUID();
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
        public static SlnScript IfCondition(IfCondition ifCondition)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.IF_CONDITION.ToDescriptionString();
            script.Param = ifCondition.Conditions;
            return script;
        } 
        public static SlnScript LoopJsonFile(LoopJsonFile json)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.LOOP_JSON_FILE.ToDescriptionString();
            script.Param = json;
            return script;
        } 
        public static SlnScript Condition(Condition condition)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.CONDITION.ToDescriptionString();
            script.Param = condition;
            return script;
        } 
         public static SlnScript GetLabel(String control, GetLabel param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.GET_LABEL.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        } 
        public static SlnScript GetTextValue(String control, GetTextValue param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.GET_TEXT_VALUE.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        } 

        public static SlnScript Input(String control, Input param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.INPUT.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        }
        public static SlnScript Click(String control, Click param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.CLICK.ToDescriptionString();
            script.Control = control;
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