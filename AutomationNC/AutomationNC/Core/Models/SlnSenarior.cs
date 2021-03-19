
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
        // private SlnSeleniumWebDriver webDriver;
        private Dictionary<string, object> variables;

        public List<SlnScript> Scripts 
        {
            get
            {
                return _scripts;
            }
            set
            {
                _scripts = value;
                    
            }
        }

        public SlnSenarior()
        {
            // webDriver = new SlnSeleniumWebDriver();
            variables = new Dictionary<string, object>();
        }

        public void Process()
        {
            //this.Script = new List<SlnScript>() {
            //     SlnScript.OpenWebsite(new OpenWebsite(){ Url = "https://www.facebook.com/"}),
            //     SlnScript.Exit()
            //};

            try
            {
                foreach (SlnScript script in this.Scripts)
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
            // webDriver.OpenWebsite(url);
        }
        private void HandleExit()
        {
            // webDriver.Exit();
        }
        

    }
}
