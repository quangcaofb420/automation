using Core;
using Core.Models;
namespace AutomationNC
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string fbAction = args[0];
                DesignService designService =  DesignService.GetInstance();

                SlnSenarior slnSenarior = designService.GetSenarior(fbAction);
                slnSenarior.Process(args[1]);
            }
        }
    }
}
