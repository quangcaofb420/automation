using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class FBAction
    {
        public String Action { get; set; }
        public String HandleTyle { get; set; }
        public FBAction(string actionName, String handleType)
        {
            Action = actionName;
            HandleTyle = handleType;
        }
    }
}
