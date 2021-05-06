using Core.Common;
using Core.Models;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ScriptUtils
    {
        public static SlnAction GetDefinedAction(ACTION action)
        {
            string description = action.ToDescriptionString();
            SlnAction definedAction = ClassUtils.GetStaticPropperty<Core.Models.SlnAction>(typeof(Core.Models.SlnAction), description);
            return definedAction;
        }

        public static ACTION GetActionByDescription(string description)
        {
            foreach (ACTION action in (ACTION[])Enum.GetValues(typeof(ACTION)))
            {
                if (action.ToDescriptionString() == description)
                {
                    return action;
                }
            }
            return ACTION.Sleep;
        }
    }
}
