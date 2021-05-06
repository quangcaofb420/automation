using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class Condition : ParentAction
    {
        public String Expression { get; set; }
        public Condition(String expression, List<SlnScript> actions)
        {
            Expression = expression;
            Actions = actions;
        }
    }
}
