
using Core.Common;
using Core.Models;
using Core.Utilities;
using System;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class LoopApiData : ParentAction
    {
        public String Api { get; set; }
        public String PathToPropperty { get; set; }
        public String ToVariable { get; set; }
        public String Mode { get; set; }

        public static readonly String Mode_T = "[" + string.Join(",", ExtensionUtils.ToList<THREAD_MODE>()) + "]";

        public LoopApiData(String api, String pathToPropperty, String toVariable, String mode, List<SlnScript> actions) : base()
        {
            Api = api;
            PathToPropperty = pathToPropperty;
            ToVariable = toVariable;
            Mode = mode;
            Actions = actions;
        }
    }
}
