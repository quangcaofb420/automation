using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.ActionParam
{
    public class IfCondition
    {
        public Func<bool> Expression;
        public Func<SlnScript[]> Actions;
    }
}
