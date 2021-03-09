using AutomationNC.Core.ActionParam;
using AutomationNC.Core.Common;
using AutomationNC.Core.Models;
using AutomationNC.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationNC.Core
{
    class SlcSenarior
    {
        private List<SlnScript> scripts = new List<SlnScript>();
        private SlnSeleniumWebDriver webDriver;
        private static SlcSenarior instance;
        private Dictionary<string, object> variables;
        public static SlcSenarior GetInstance()
        {
            if (instance == null)
            {
                instance = new SlcSenarior();
            }
            return instance;
        }
        private SlcSenarior()
        {
            webDriver = new SlnSeleniumWebDriver();
            variables = new Dictionary<string, object>();
        }

        public void Process()
        {
            this.scripts = new List<SlnScript>() {
                 SlnScript.OpenWebsite(new OpenWebsite(){ Url = "https://www.facebook.com/"}),
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
            string url = ExpressionUtils.GetExpressionValue( ((OpenWebsite)script.Param).Url);
            webDriver.OpenWebsite(url);
        }
        private void HandleExit()
        {
            webDriver.Exit();
        }
        

    }
}
