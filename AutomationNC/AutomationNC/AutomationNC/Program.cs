using Core;
using Core.Models;
using System;
using System.Collections.Generic;

namespace AutomationNC
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string fbAction = args[0];
                DesignService designService = new DesignService();
                List<SlnScript> scripts = designService.GetScripts(fbAction);
                SlnSenarior slnSenarior = new SlnSenarior();
                slnSenarior.Scripts = scripts;
                slnSenarior.Process();
            }
        }
    }
}
