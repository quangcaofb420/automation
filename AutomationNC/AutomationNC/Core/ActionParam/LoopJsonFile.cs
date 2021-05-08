
using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class LoopJsonFile: ParentAction
    {
        public String Path { get; set; }
        public String ToVariable { get; set; }

       public LoopJsonFile(String path,String toVariable,  List<SlnScript> actions): base()
        {
            Path = path;
            ToVariable = toVariable;
            Actions = actions;
        }
    }
}
