
using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.ActionParam
{
    public class LoopJsonFile
    {
        public String Path { get; set; }

        private List<SlnScript> _actions;

        public List<SlnScript> Actions { get { return _actions == null ? new List<SlnScript>() : _actions; } set { this._actions = value; } }
        public LoopJsonFile(string path, List<SlnScript> actions)
        {
            Path = path;
            _actions = actions;
        }
    }
}
