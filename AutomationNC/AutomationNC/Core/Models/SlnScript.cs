
using Core.ActionParam;
using Core.Common;
using Core.Utilities;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class SlnScript
    {
        public String Action { get; set; }
        public String Control { get; set; }
        public object Param { get; set; }

        public Boolean CanModified { get; private set; }

        private string _id;

        private SlnScript()
        {
            this._id = CommonUtils.UUID();
            CanModified = true;
        }

        public ACTION GetAction()
        {
            return this.Action.ToEnum<ACTION>();
        }

        public void InitParam()
        {
            ACTION action = Action.ToEnum<ACTION>();

            switch (action)
            {
                case ACTION.OpenWebsite:
                    Param = new OpenWebsite("", "");
                    break;
                case ACTION.Input:
                    Param = new Input("");
                    break;
                case ACTION.Click:
                    Param = new Click();
                    break;
                case ACTION.IfCondition:
                    Param = new List<SlnScript>() {
                            SlnScript.Condition(
                                new Condition("true",
                                new List<SlnScript>(){
                                        SlnScript.Sleep(new Sleep(10))
                                    }
                                )
                            )
                        };
                    break;
                case ACTION.Condition:
                    break;
                case ACTION.GetLabel:
                    Param = new GetLabel("","");
                    break;
                case ACTION.GetTextValue:
                    Param = new GetTextValue("", "");
                    break;
                case ACTION.RedirectUrl:
                    break;
                case ACTION.Exit:
                    break;
                case ACTION.Sleep:
                    Param = new Sleep(10);
                    break;
                case ACTION.LoopJsonFile:
                    Param = new LoopJsonFile("", new List<SlnScript>(){
                                        SlnScript.Sleep(new Sleep(10))
                                    }
                                );
                    break;
            }

        }
        public List<SlnScript> GetChildrenActions()
        {

            if (GetAction().HasChildrenActions())
            {
                if (Param == null)
                {
                    InitParam();
                }
                
                List<SlnScript> actions = Param as List<SlnScript>;
                if (actions == null || actions.Count == 0)
                {
                    ACTION action = Action.ToEnum<ACTION>();
                    if (action == ACTION.IfCondition)
                    {
                        actions = new List<SlnScript>() {
                            SlnScript.Condition(
                                new Condition("true",
                                new List<SlnScript>(){
                                        SlnScript.Sleep(new Sleep(10))
                                    }
                                )
                            )
                        };
                    }
                    else
                    {
                        actions = new List<SlnScript>(){
                            SlnScript.Sleep(new Sleep(10))
                        };
                    }
                }
                return actions;
            }
            return new List<SlnScript>();
        }
        
        public string GetId()
        {
            return this._id;
        }
        public static SlnScript OpenWebsite(OpenWebsite param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.OpenWebsite.ToDescriptionString();
            script.Param = param;
            return script;
        }
        public static SlnScript IfCondition(IfCondition ifCondition)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.IfCondition.ToDescriptionString();
            script.Param = ifCondition.Actions;
            return script;
        }
        public static SlnScript LoopJsonFile(LoopJsonFile json)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.LoopJsonFile.ToDescriptionString();
            script.Param = json;
            return script;
        }
        public static SlnScript Condition(Condition condition)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Condition.ToDescriptionString();
            script.Param = condition;
            script.CanModified = false;
            return script;
        }
        public static SlnScript GetLabel(String control, GetLabel param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.GetLabel.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        }
        public static SlnScript GetTextValue(String control, GetTextValue param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.GetTextValue.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        }

        public static SlnScript Input(String control, Input param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Input.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        }
        public static SlnScript Click(String control, Click param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Click.ToDescriptionString();
            script.Control = control;
            script.Param = param;
            return script;
        }
        public static SlnScript Exit()
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Exit.ToDescriptionString();
            return script;
        }
        public static SlnScript Sleep(Sleep param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Sleep.ToDescriptionString();
            script.Param = param;
            return script;
        }
    }
}