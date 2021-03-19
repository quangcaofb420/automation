
using System;
using System.Collections.Generic;
using Core.ActionParam;
using Core.Common;
using Core.Utilities;

namespace Core.Models
{
    public class SlnSenarior
    {
        private List<SlnScript> _scripts = new List<SlnScript>();
        private SlnSeleniumWebDriver _webDriver;
        private static SlnSenarior _instance;
        private Dictionary<string, object> _variables;
        public static SlnSenarior GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SlnSenarior();
            }
            return _instance;
        }
        private SlnSenarior()
        {
            _webDriver = new SlnSeleniumWebDriver();
            _variables = new Dictionary<string, object>();
        }

        public void Process()
        {
            _scripts = new List<SlnScript>() {
                 SlnScript.OpenWebsite(new OpenWebsite(){ Url = "https://www.facebook.com/"}),
                 //SlnScript.Input(new Input(){Control = "", Text = "" }),
                 SlnScript.If(new IfCondition(){ Expression = () => { return true; }, Actions = () => { return new SlnScript []{ }; } }),
                 SlnScript.Exit()
            };

            try
            {
                ProcessScripts(_scripts.ToArray());
            }
            catch (Exception ex)
            {
                HandleExit();
            }
        }

        private void ProcessScripts(SlnScript[] scripts)
        {
            foreach (SlnScript script in scripts)
            {
                ProcessScript(script);
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
            _webDriver.OpenWebsite(url);
        }
        private void HandleInput(SlnScript script)
        {
            string text = ExpressionUtils.GetExpressionValue(((Input)script.Param).Text);
            _webDriver.Input(((Input)script.Param).Control, text);
        } 
        private void HandleClick(SlnScript script)
        {
            _webDriver.Click(((Input)script.Param).Control);
        }
        private void HandleIfCondition(SlnScript script)
        {
            IfCondition[] conditions = script.Param as IfCondition[];
            foreach (IfCondition condition in conditions)
            {
                if (condition.Expression() == true)
                {
                    SlnScript[] scripts = condition.Actions();
                    ProcessScripts(scripts);
                    break;
                }
            }

        }
        private void HandleExit()
        {
            _webDriver.Exit();
        }
    }
}
