
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        private DesignService _designService;
        public List<SlnScript> Scripts { get { return _scripts; } set { this._scripts = value; } }

        public string FbAction { private set; get; }       
        public SlnSenarior(string fbAction, List<SlnScript> scripts)
        {
            FbAction = fbAction;
            _scripts = scripts;
            _scripts = scripts;
            _variables = new Dictionary<string, object>();
            _designService = DesignService.GetInstance();
        }

        public void Process(string webDriverFilePath)
        {
            _webDriver = new SlnSeleniumWebDriver(webDriverFilePath);
            
            try
            {
                ProcessScripts(_scripts);
                HandleExit();
            }
            catch (Exception ex)
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
                case ACTION.OpenWebsite:
                    HandleOpenWebsite(script);
                    break;
                case ACTION.Input:
                    HandleInput(script);
                    break;
                case ACTION.Click:
                    HandleClick(script);
                    break;
                case ACTION.IfCondition:
                    HandleIfCondition(script);
                    break;
                case ACTION.GetLabel:
                    HandleGetLabel(script);
                    break;
                case ACTION.GetTextValue:
                    HandleGetTextValue(script);
                    break;
                case ACTION.Sleep:
                    HandleSleep(script);
                    break;
                case ACTION.LoopJsonFile:
                    HandleLoopJsonFile(script);
                    break;
                case ACTION.RedirectUrl:
                    break;
                case ACTION.Exit:
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
            SlnControl control = GetControl(script.Control);
            _webDriver.Input(control.XPath, text);
        }
        private void HandleClick(SlnScript script)
        {
            SlnControl control = GetControl(script.Control);
            _webDriver.Click(control.XPath);
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
            SlnControl control = GetControl(script.Control);
            string label = await _webDriver.GetLabel(control.XPath);
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
            SlnControl control = GetControl(script.Control);
            string value = await _webDriver.GetTextValue(control.XPath);
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
            string secondText = GetVariableValue(param.Second.ToString());
            int second = int.Parse(secondText);
            _webDriver.Sleep(second);
        }
         private void HandleLoopJsonFile(SlnScript script)
        {
            LoopJsonFile param = script.Param.To<LoopJsonFile>();
            string path = param.Path;
            string variable = param.ToVariable;

            Dictionary<string, object> obj = _designService.GetObjectFromJsonFile<Dictionary<string, object>>(path);
            SetVariable(variable, obj);

            List<SlnScript> actions = param.Actions;
            ProcessScripts(actions);
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
                for (int i = 0; i < vs.Length; i++)
                {
                    string key = vs[i];
                    if (i < vs.Length - 1)
                    {
                        object item = structure["{{" + key + "}}"];
                        if (item == null)
                        {
                            break;
                        }
                        structure = item as Dictionary<string, object>;
                    }
                    else
                    {
                        value = structure[key];
                    }

                }
            }
            else
            {
                value = _variables["{{" + v + "}}"];
            }
            return value.ToString();
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

        private SlnControl GetControl(string controlName)
        {
            SlnControl control = _designService.GetControlByName(FbAction, controlName);
            return control;
        }
    }
}
