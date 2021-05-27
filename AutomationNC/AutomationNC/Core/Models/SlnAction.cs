using Core.ActionParam;
using Core.Common;
using Core.Utilities;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class SlnAction
    {
        public static readonly SlnAction OpenWebsite = new SlnAction() { Name = ACTION.OpenWebsite, RequiredElement = false, ParamType = typeof(OpenWebsite), DefaultParam = new OpenWebsite("", "https://www.facebook.com/") };
        public static readonly SlnAction OpenNewTab = new SlnAction() { Name = ACTION.OpenNewTab, RequiredElement = false, ParamType = typeof(OpenNewTab), DefaultParam = new OpenNewTab("") };
        public static readonly SlnAction Input = new SlnAction() { Name = ACTION.Input, RequiredElement = true, ParamType = typeof(Input), DefaultParam = new Input("") };
        public static readonly SlnAction Click = new SlnAction() { Name = ACTION.Click, RequiredElement = true, ParamType = typeof(Click), DefaultParam = new Click() };
        public static readonly SlnAction GetLabel = new SlnAction() { Name = ACTION.GetLabel, RequiredElement = true, ParamType = typeof(GetLabel), DefaultParam = new GetLabel("", "") };
        public static readonly SlnAction GetTextValue = new SlnAction() { Name = ACTION.GetTextValue, RequiredElement = true, ParamType = typeof(GetTextValue), DefaultParam = new GetTextValue("", "") };
        public static readonly SlnAction IfCondition = new SlnAction()
        {
            Name = ACTION.IfCondition,
            RequiredElement = false,
            ParamType = typeof(IfCondition),
            DefaultParam = new List<SlnScript>() {
                            SlnScript.Condition(
                                new Condition("true",
                                new List<SlnScript>(){
                                        SlnScript.Sleep(new Sleep(10))
                                    }
                                )
                            )
                        }
        };
        public static readonly SlnAction Condition = new SlnAction() { Name = ACTION.Condition, RequiredElement = false, ParamType = typeof(Condition) };
        public static readonly SlnAction Exit = new SlnAction() { Name = ACTION.Exit, RequiredElement = false, ParamType = typeof(Exit), DefaultParam = new Exit() };
        public static readonly SlnAction Close = new SlnAction() { Name = ACTION.Close, RequiredElement = false, ParamType = typeof(Close), DefaultParam = new Close() };
        public static readonly SlnAction CloseTab = new SlnAction() { Name = ACTION.CloseTab, RequiredElement = false, ParamType = typeof(CloseTab), DefaultParam = new CloseTab() };
        public static readonly SlnAction CloseTabByTitle = new SlnAction() { Name = ACTION.CloseTabByTitle, RequiredElement = false, ParamType = typeof(CloseTabByTitle), DefaultParam = new CloseTabByTitle("") };
        public static readonly SlnAction Sleep = new SlnAction() { Name = ACTION.Sleep, RequiredElement = false, ParamType = typeof(Sleep), DefaultParam = new Sleep(10) };
        public static readonly SlnAction LoopJsonFile = new SlnAction()
        {
            Name = ACTION.LoopJsonFile,
            RequiredElement = false,
            ParamType = typeof(LoopJsonFile),
            DefaultParam = new LoopJsonFile("", "", THREAD_MODE.None.ToString() , new List<SlnScript>(){
                                        SlnScript.Sleep(new Sleep(10))
                                    }
                                )
        };

        public static readonly SlnAction LoopApiData = new SlnAction()
        {
            Name = ACTION.LoopApiData,
            RequiredElement = false,
            ParamType = typeof(LoopApiData),
            DefaultParam = new LoopApiData("https://reqres.in/api/users", "data", "{{employee}}", THREAD_MODE.None.ToString() , new List<SlnScript>(){
                                        SlnScript.Sleep(new Sleep(10))
                                    }
                                )
        };

        public ACTION Name { get; set; }
        public bool RequiredElement { get; set; }

        public Type _paramType;
        public Type ParamType
        {
            get { return _paramType; }
            set
            {
                this._paramType = value;
                this._params = ClassUtils.GetPropertyNames(this._paramType);
            }
        }

        private string[] _params = new string[] { };
        public string[] Params { get { return _params; } set { _params = value; } }

        public object DefaultParam { get; set; }
        public SlnAction()
        {
        }
    }
}
