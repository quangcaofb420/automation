using Core;
using Core.Models;
using Core.Utilities;

namespace AutomationNC
{
    class Program
    {
        /// <summary>
        /// <para>0. FBAction or Path of Seranior file</para>
        /// <para>1. webDriverFilePath</para>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {

                string fbActionOrPath = args[0];
                bool isSenariorFilePath = fbActionOrPath.Contains("\\") || fbActionOrPath.Contains("/");
                string webDriverFilePath = args[1];
                
                DesignService designService =  DesignService.GetInstance();
                SlnSenarior slnSenarior;
                if (isSenariorFilePath)
                {
                    slnSenarior = designService.GetSenariorByFBAction(fbActionOrPath);
                }
                else
                {
                    string fileFullPath = FileUtils.GetFullPath(fbActionOrPath);
                    slnSenarior = designService.GetSenariorByFile(fbActionOrPath);
                }

                slnSenarior.Process(webDriverFilePath);
            }
        }
    }
}
