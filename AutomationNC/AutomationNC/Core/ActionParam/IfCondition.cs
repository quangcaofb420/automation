using Core.Models;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class IfCondition: ParentAction
    {        
        public IfCondition(List<SlnScript> conditions)
        {
            Actions = conditions;
        }
    }
}
