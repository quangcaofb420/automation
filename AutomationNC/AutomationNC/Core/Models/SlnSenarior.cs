
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private string _webDriverFilePath = "";
        private List<String> _ignoredIds;
        public List<SlnScript> Scripts { get { return _scripts; } set { this._scripts = value; } }

        public string FbAction { private set; get; }

        public SlnSenarior()
        { }

        public SlnSenarior(string fbAction, List<SlnScript> scripts): this()
        {
            FbAction = fbAction;
            _scripts = scripts;
            _scripts = scripts;
            _variables = new Dictionary<string, object>();
            _designService = DesignService.GetInstance();
            _ignoredIds = new List<string>();
        }
        public SlnSenarior(string fbAction, List<SlnScript> scripts, List<String> ignoredIds): this(fbAction, scripts)
        {
            _ignoredIds = ignoredIds;
        }

        public void Process(string webDriverFilePath)
        {
            _webDriverFilePath = webDriverFilePath;
            _webDriver = new SlnSeleniumWebDriver(_webDriverFilePath);
            new Thread(() =>
            {
                try
                {
                    ProcessScripts(_scripts);
                    HandleExit();
                }
                catch (Exception ex)
                {
                    HandleExit();
                }

            }).Start();
            
           
           
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
                case ACTION.OpenNewTab:
                    HandleOpenNewTab(script);
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
                case ACTION.LoopApiData:
                    HandleLoopApiData(script);
                    break;
                case ACTION.RedirectUrl:
                    break;
                case ACTION.Exit:
                    HandleExit();
                    break; 
                case ACTION.Close:
                    HandleClose();
                    break;
                case ACTION.CloseTab:
                    HandleCloseTab();
                    break; 
                case ACTION.CloseTabByTitle:
                    HandleCloseTabByTitle(script);
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
        private void HandleOpenNewTab(SlnScript script)
        {
            OpenNewTab param = script.Param.To<OpenNewTab>();
            string url = GetExpressionValue(param.Url);
            _webDriver.OpenNewTab(url);
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
        private void HandleCloseTabByTitle(SlnScript script)
        {
            CloseTabByTitle param = script.Param.To<CloseTabByTitle>();
            string title = GetVariableValue(param.Title.ToString());
            _webDriver.CloseTabByTitle(title);
        }

        private void HandleLoopApiData(SlnScript script)
        {
            LoopApiData param = script.Param.To<LoopApiData>();
            string api = GetExpressionValue(param.Api);
            string variable = param.ToVariable;
            string pathToPropperty = param.PathToPropperty;
            THREAD_MODE mode = param.Mode.ToEnum<THREAD_MODE>();
            Dictionary<string, object>[] objs = HttpApiUtils.GetArray<Dictionary<string, object>>(api, pathToPropperty);
            HandlLoopData(script, objs, mode, variable, param.Actions);
        }

        private void HandleLoopJsonFile(SlnScript script)
        {
            LoopJsonFile param = script.Param.To<LoopJsonFile>();
            string path = GetExpressionValue(param.Path);
            string variable = param.ToVariable;
            THREAD_MODE mode = param.Mode.ToEnum<THREAD_MODE>();
            Dictionary<string, object>[] objs = _designService.GetObjectFromJsonFile<Dictionary<string, object>[]>(path);
            HandlLoopData(script, objs, mode, variable, param.Actions);
        }

        private void HandlLoopData(SlnScript self, Dictionary<string, object>[] objs, THREAD_MODE mode, string variable, List<SlnScript> actions)
        {
            if (mode == THREAD_MODE.None)
            {
                foreach (Dictionary<string, object> obj in objs)
                {
                    SetVariable(variable, obj);
                    ProcessScripts(actions);
                    RemoveVariable(variable);
                }
            }
            else if (mode == THREAD_MODE.Multi)
            {
                for (int i = 0; i < objs.Length; i++)
                {
                    string idForIgnore = buildIgnoreId(self, i + "");
                    bool canRun = _ignoredIds.Contains(idForIgnore) == false;
                    if (canRun)
                    {
                        Dictionary<string, object> obj = objs[i];
                        _ignoredIds.Add(idForIgnore);
                        new Thread(() =>
                        {
                            Thread.CurrentThread.IsBackground = true;
                            /* run your code here */
                            SlnSenarior senarior = new SlnSenarior(FbAction, Scripts, _ignoredIds);
                            senarior.Process(_webDriverFilePath);

                        }).Start();

                        SetVariable(variable, obj);
                        ProcessScripts(actions);
                        RemoveVariable(variable);

                        break;
                    }
                }
            }
        }

        private string buildIgnoreId(SlnScript script, string extra)
        {
            return script.Id + extra;
        }

        private void HandleExit()
        {
            _webDriver.Exit();
        }
        private void HandleClose()
        {
            _webDriver.Close();
        }
        private void HandleCloseTab()
        {
            _webDriver.CloseTab();
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
        private void RemoveVariable(string variable)
        {
            if (_variables.ContainsKey(variable))
            {
                _variables.Remove(variable);
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
                try
                {
                    value = _variables["{{" + v + "}}"];
                }
                catch (Exception ex)
                {
                    value = variable;
                }
            }
            return value.ToString();
        }

        private string GetExpressionValue(string expr)
        {
            while (expr.Contains("{{") && expr.Contains("}}"))
            {
                int openVariable = expr.IndexOf("{{");
                int closeVariable = expr.IndexOf("}}");
                string variable = expr.Substring(openVariable + 2, closeVariable - 2);
                string value = GetVariableValue(variable);
                string leftStr = "";
                if (openVariable > 0)
                {
                    leftStr = expr.Substring(0, openVariable - 1);
                }
                string middleStr = value;
                string rightStr = expr.Substring(closeVariable + 2, expr.Length - closeVariable - 2);
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
/***
 * public List<SlnSenarior> ParseSenarior()
        {
            List<SlnSenarior> senariors = new List<SlnSenarior>();
            SlnSenarior senarior = new SlnSenarior(FbAction, new List<SlnScript>());
            do
            {
                senarior = new SlnSenarior(FbAction, new List<SlnScript>());
                for (int i = 0; i < _scripts.Count; i++)
                {
                    SlnScript script = _scripts[i];
                    List<SlnScript> parseers = script.ParseScript();
                    senarior.Scripts.AddRange(parseers);
                }
                senariors.Add(senarior);
            } while (senarior.HasMultiThreadAction());
            

            return senariors.Where(p => !p.HasMultiThreadAction()).ToList();
        }

        private bool HasMultiThreadAction()
        {
            for (int i = 0; i < _scripts.Count; i++)
            {
                SlnScript script = _scripts[i];
                if (script.HasMultiThreadAction())
                {
                    return true;
                }
            }
            return false;
        }
 */