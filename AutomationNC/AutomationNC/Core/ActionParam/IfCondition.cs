using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.ActionParam
{
    public class IfCondition
    {        
        private List<Condition> _conditions;

        public List<Condition> Conditions { get { return _conditions == null ? new List<Condition>() : _conditions; } set { this._conditions = value; } }
        public IfCondition(List<Condition> conditions)
        {
            _conditions = conditions;
        }
    }
}
