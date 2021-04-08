
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
        private Dictionary<string, object> _variables;

        public List<SlnScript> Scripts { get { return _scripts; } set { this._scripts = value; } }
       
        public SlnSenarior(List<SlnScript> scripts)
        {
            _scripts = scripts;
            _variables = new Dictionary<string, object>();
        }

        public void Process()
        {
            _webDriver = new SlnSeleniumWebDriver();
            
            try
            {
                ProcessScripts(_scripts);
                HandleExit();
            }
            catch (Exception)
            {
                HandleExit();
            }
           
        }

        private void ProcessScripts(List<SlnScript> scripts)
        {
            foreach (SlnScript script in scripts)
            {
                ProcessScript(script);
            }
        }

        private void ProcessScript(SlnScript script)
        {
            
            ACTION action = ScriptUtils.GetActionByDescription(script.Action);
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
                case ACTION.GET_LABEL:
                    HandleGetLabel(script);
                    break;
                case ACTION.GET_TEXT_VALUE:
                    HandleGetTextValue(script);
                    break;
                case ACTION.SLEEP:
                    HandleSleep(script);
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
            OpenWebsite param = script.Param.To<OpenWebsite>();
            string url = GetExpressionValue(param.Url);
            _webDriver.OpenWebsite(url);
        }
        private void HandleInput(SlnScript script)
        {
            Input param = script.Param.To<Input>();
            
            string text = GetExpressionValue(param.Text);
            _webDriver.Input(script.Control, text);
        }
        private void HandleClick(SlnScript script)
        {
            Click param = script.Param.To<Click>();
            _webDriver.Click(script.Control);
        }
        private void HandleIfCondition(SlnScript script)
        {
            List<SlnScript> conditions = script.Param.ToList<SlnScript>();
            for (int i = 0; i < conditions.Count; i++)
            {
                SlnScript con = conditions[i];
                Condition condition = con.Param.To<Condition>(); 

                if (i == conditions.Count - 1 && (condition.Expression == null || condition.Expression == "") )
                {
                    List<SlnScript> scripts = condition.Actions;
                    ProcessScripts(scripts);
                }
                else if ((Boolean)ExpressionUtils.Evaluate(condition.Expression) == true)
                {
                    List<SlnScript> scripts = condition.Actions;
                    ProcessScripts(scripts);
                    break;
                }
            }
        }
        private async void HandleGetLabel(SlnScript script)
        {
            GetLabel param = script.Param.To<GetLabel>();
            string variable = param.ToVariable;
            string withExpression = param.WithExpression;
            string label = await _webDriver.GetLabel(script.Control);
            SetVariable(variable, label);
            if (withExpression != "")
            {
                string exprValue = GetExpressionValue(withExpression);
                SetVariable(variable, exprValue);
            }
        }
        private async void HandleGetTextValue(SlnScript script)
        {
            GetTextValue param = script.Param.To<GetTextValue>();
            string variable = param.ToVariable;
            string withExpression = param.WithExpression;
            string value = await _webDriver.GetTextValue(script.Control);
            SetVariable(variable, value);
            if (withExpression != "")
            {
                string exprValue = GetExpressionValue(withExpression);
                SetVariable(variable, exprValue);
            }
        }
        private void HandleSleep(SlnScript script)
        {
            Sleep param = script.Param.To<Sleep>();
            _webDriver.Sleep(param.Second);
        }
        private void HandleExit()
        {
            _webDriver.Exit();
        }

        private void SetVariable(string variable, object value)
        {
            if (_variables.ContainsKey(variable))
            {
                _variables[variable] = value;
            }
            else
            {
                _variables.Add(variable, value);
            }
        }

        private string GetVariableValue(string variable)
        {
            object value = null;
            string v = variable.Replace("{{", "").Replace("}}", "");
            bool hasDot = v.Contains(".");
            if (hasDot)
            {
                Dictionary<string, object> structure = new Dictionary<string, object>(_variables);
                string[] vs = v.Split(".");
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    object item = structure["{{" + vs[i] + "}}"];
                    if (item == null)
                    {
                        item = structure[vs[i]];
                    }

                    if (i < vs.Length - 1)
                    {
                        if (item == null)
                        {
                            break;
                        }

                        structure = item as Dictionary<string, object>;
                    }
                    else
                    {
                        value = item;
                    }
                }
            }
            else
            {
                value = _variables["{{" + v + "}}"];
            }
            return (string)value;
        }

        private string GetExpressionValue(string expr)
        {
            while (expr.Contains("{{") && expr.Contains("}}"))
            {
                int openVariable = expr.IndexOf("{{");
                int closeVariable = expr.IndexOf("}}");
                string variable = expr.Substring(openVariable, openVariable + 2);
                string value = GetVariableValue(variable);
                string leftStr = "";
                if (openVariable > 0)
                {
                    leftStr = expr.Substring(0, openVariable - 1);
                }
                string middleStr = value;
                string rightStr = expr.Substring(closeVariable + 2, expr.Length - (closeVariable + 1));
                expr = leftStr + middleStr + rightStr;
            }
            if (!expr.Contains("\""))
            {
                expr = "\"" + expr + "\"";
            }

            object result = ExpressionUtils.Evaluate(expr);
            return (string)result;
        }
    }
}
