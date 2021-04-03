using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class FBAction
    {
        public String Action { get; set; }

        public FBAction(string actionName)
        {
            Action = actionName;
        }
    }
}
