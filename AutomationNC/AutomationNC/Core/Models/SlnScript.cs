
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

        public String Id { get; set; }


        private SlnScript()
        {
            Id = CommonUtils.UUID();
        }

        public String GetParamType(string paramName)
        {
            ACTION action = GetAction();
            if (action == ACTION.LoopJsonFile)
            {
                String pt = ClassUtils.GetStaticPropperty<String>(typeof(LoopJsonFile), paramName + "_T") ?? "String";
                return pt;
            }
            else if (action == ACTION.LoopApiData)
            {
                String pt = ClassUtils.GetStaticPropperty<String>(typeof(LoopApiData), paramName + "_T") ?? "String";
                return pt;
            }
            return "String";

        }
       
        public ACTION GetAction()
        {
            return Action.ToEnum<ACTION>();
        }

        public void InitParam()
        {
            ACTION action = GetAction();
            SlnAction slnAction = ClassUtils.GetStaticPropperty<SlnAction>(typeof(SlnAction), action.ToDescriptionString());
            if (slnAction != null)
            {
                Param = slnAction.DefaultParam;
            }
        }
        public List<SlnScript> GetChildrenActions()
        {
            ACTION action = GetAction();
            if (action.HasChildrenActions())
            {
                if (Param == null)
                {
                    InitParam();
                }
                List<SlnScript> actions = new List<SlnScript>();

                if (action == ACTION.IfCondition)
                {
                    actions = Param.To<List<SlnScript>>();
                }
                else
                {
                    ParentAction parentAction = Param.To<ParentAction>();
                    if (parentAction == null)
                    {
                        actions = new List<SlnScript>(){
                                SlnScript.Sleep(new Sleep(10))
                            };
                    }
                    else
                    {
                        actions = parentAction.Actions;
                    }
                }
                return actions;
            }
            return new List<SlnScript>();
        }
        
        public static SlnScript OpenWebsite(OpenWebsite param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.OpenWebsite.ToDescriptionString();
            script.Param = param;
            return script;
        } 
        public static SlnScript OpenNewTab(OpenNewTab param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.OpenNewTab.ToDescriptionString();
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
        public static SlnScript Condition(Condition condition)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Condition.ToDescriptionString();
            script.Param = condition;
            return script;
        }
        public static SlnScript LoopJsonFile(LoopJsonFile json)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.LoopJsonFile.ToDescriptionString();
            script.Param = json;
            return script;
        }
       public static SlnScript LoopApiData(LoopApiData api)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.LoopApiData.ToDescriptionString();
            script.Param = api;
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
        public static SlnScript Exit(Exit param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Exit.ToDescriptionString();
            script.Param = param;
            return script;
        }
        public static SlnScript Close(Close param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.Close.ToDescriptionString();
            script.Param = param;
            return script;
        } 
        public static SlnScript CloseTab(CloseTab param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.CloseTab.ToDescriptionString();
            script.Param = param;
            return script;
        }        
        
        public static SlnScript CloseTabByTitle(CloseTabByTitle param)
        {
            SlnScript script = new SlnScript();
            script.Action = ACTION.CloseTabByTitle.ToDescriptionString();
            script.Param = param;
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