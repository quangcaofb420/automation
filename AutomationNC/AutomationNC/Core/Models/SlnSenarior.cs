
using System;
using System.Collections.Generic;
using Core.ActionParam;
using Core.Common;
using Core.Utilities;

namespace Core.Models
{
    public class SlnSenarior
    {
        private List<SlnScript> scripts = new List<SlnScript>();
        private SlnSeleniumWebDriver webDriver;
        private static SlnSenarior instance;
        private Dictionary<string, object> variables;
        public static SlnSenarior GetInstance()
        {
            if (instance == null)
            {
                instance = new SlnSenarior();
            }
            return instance;
        }
        private SlnSenarior()
        {
            webDriver = new SlnSeleniumWebDriver();
            variables = new Dictionary<string, object>();
        }

        public void Process()
        {
            this.scripts = new List<SlnScript>() {
                 SlnScript.OpenWebsite(new OpenWebsite(){ Url = "https://www.facebook.com/"}),
                 //SlnScript.Input(new Input(){Control = "", Text = "" }),
                 SlnScript.If(new IfCondition(){ Expression = () => { return true; }, Action = () => { } }),
                 SlnScript.Exit()
            };

            try
            {
                foreach (SlnScript script in this.scripts)
                {
                    ProcessScript(script);
                }
            }
            catch (Exception ex)
            {
                HandleExit();
            }
        }

        private void ProcessScript(SlnScript script)
        {
            ACTION action = script.Action.Name;
            switch (action)
            {
                case ACTION.OPEN_WEBSITE:
                    HandleOpenWebsite(script);
                    break;
                case ACTION.INPUT:
                    HandleInput(script);
                    break;
                case ACTION.CLICK:
                    HandleClick(script);
                    break;
                case ACTION.IF_CONDITION:
                    HandleIfCondition(script);
                    break;
                case ACTION.REDIRECT_URL:
                    break;
                case ACTION.EXIT:
                    HandleExit();
                    break;
                default:
                    break;
            }
        }
        private void HandleOpenWebsite(SlnScript script)
        {
            string url = ExpressionUtils.GetExpressionValue(((OpenWebsite)script.Param).Url);
            webDriver.OpenWebsite(url);
        }
        private void HandleInput(SlnScript script)
        {
            string text = ExpressionUtils.GetExpressionValue(((Input)script.Param).Text);
            webDriver.Input(((Input)script.Param).Control, text);
        } 
        private void HandleClick(SlnScript script)
        {
            webDriver.Click(((Input)script.Param).Control);
        }
        private void HandleIfCondition(SlnScript script)
        {
            IfCondition[] conditions = script.Param as IfCondition[];
            foreach (IfCondition condition in conditions)
            {
                if (condition.Expression() == true)
                {
                    
                }
            }

        }
        private void HandleExit()
        {
            webDriver.Exit();
        }
    }
}
