
using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class LoopJsonFile: ParentAction
    {
        public String Path { get; set; }

       public LoopJsonFile(string path, List<SlnScript> actions): base()
        {
            Path = path;
            Actions = actions;
        }
    }
}
