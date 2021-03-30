using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ActionParam
{
    public class Condition
    {
        public string Expression { get; set; }
        private List<SlnScript> _actions;

        public List<SlnScript> Actions { get { return _actions == null ? new List<SlnScript>() : _actions; } set { this._actions = value; } }
        public Condition(string expression, List<SlnScript> actions)
        {
            Expression = expression;
            _actions = actions;
        }
    }
}
