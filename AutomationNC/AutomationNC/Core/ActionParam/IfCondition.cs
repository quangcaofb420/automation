using Core.Models;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class IfCondition
    {        
        private List<SlnScript> _conditions;

        public List<SlnScript> Conditions { get { return _conditions == null ? new List<SlnScript>() : _conditions; } set { this._conditions = value; } }
        public IfCondition(List<SlnScript> conditions)
        {
            _conditions = conditions;
        }
    }
}
