using Core.ActionParam;
using Core.Common;
using Core.Utilities;
using System;

namespace Core.Models
{
    public class SlnAction
    {
        public static readonly SlnAction OpenWebsite = new SlnAction() { Name = ACTION.OPEN_WEBSITE, RequiredElement = false, ParamType = typeof(OpenWebsite) };
        public static readonly SlnAction Exit = new SlnAction() { Name = ACTION.EXIT, RequiredElement = false };

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
