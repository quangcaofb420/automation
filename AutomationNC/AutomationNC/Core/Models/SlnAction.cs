using Core.ActionParam;
using Core.Common;
using Core.Utilities;
using System;

namespace Core.Models
{
    public class SlnAction
    {
        public static readonly SlnAction OpenWebsite = new SlnAction() { Name = ACTION.OPEN_WEBSITE, RequiredElement = false, ParamType = typeof(OpenWebsite) };
        public static readonly SlnAction Input = new SlnAction() { Name = ACTION.INPUT, RequiredElement = true, ParamType = typeof(Input) };
        public static readonly SlnAction Click = new SlnAction() { Name = ACTION.CLICK, RequiredElement = true, ParamType = typeof(Click) };
        public static readonly SlnAction GetLabel = new SlnAction() { Name = ACTION.GET_LABEL, RequiredElement = true, ParamType = typeof(GetLabel) };
        public static readonly SlnAction GetTextValue = new SlnAction() { Name = ACTION.GET_TEXT_VALUE, RequiredElement = true, ParamType = typeof(GetTextValue) };
        public static readonly SlnAction IfCondition = new SlnAction() { Name = ACTION.IF_CONDITION, RequiredElement = false, ParamType = typeof(IfCondition[]) };
        public static readonly SlnAction Exit = new SlnAction() { Name = ACTION.EXIT, RequiredElement = false };
        public static readonly SlnAction Sleep = new SlnAction() { Name = ACTION.SLEEP, RequiredElement = false, ParamType = typeof(Sleep) };

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
        public SlnAction()
        {
        }
    }
}
