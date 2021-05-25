
using Core.Common;
using Core.Models;
using Core.Utilities;
using System;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class LoopJsonFile: ParentAction
    {
        public String Path { get; set; }
        public String ToVariable { get; set; }
        public String Mode { get; set; }

        public static readonly String Mode_T = "["+ string.Join(",", ExtensionUtils.ToList<THREAD_MODE>()) +"]";

        public LoopJsonFile(String path, String toVariable, String mode, List<SlnScript> actions) : base()
        {
            Path = path;
            ToVariable = toVariable;
            Mode = mode;
            Actions = actions;
        }
    }
}
