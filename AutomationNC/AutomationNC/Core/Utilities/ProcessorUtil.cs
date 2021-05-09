using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Core.Utilities
{
    public class ProcessorUtil
    {

        public static string CreateBatchFile(string title, string filePath, string exeFileName, params string[] param)
        {
            string arg = "";
            foreach (string pr in param)
            {
                arg += " \"" + pr + "\"";
            }
            //string command = exePath + arg;
            string command = "START \"" + title + "\"" + " /B " + "\"" + exeFileName + "\"" + arg;
            FileUtils.WriteTextFile(filePath, command);
            return filePath;
        }

        public static void runBatchFile(string batchFilePath)
        {
            
            string workingDirectory  = FileUtils.GetFolder(batchFilePath);
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = batchFilePath;
            proc.StartInfo.WorkingDirectory = workingDirectory;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            proc.Start();
        }
        public static void RunVBScript(string workingDirectory,string fileName)
        {
            //System.Diagnostics.Process.Start(filePath);

            Process scriptProc = new Process();
            scriptProc.StartInfo.FileName = @"cscript";
            //scriptProc.StartInfo.WorkingDirectory = @"C:\Users\Dragon\WORKING\QuangCaoFB420\Automation\"; //<---very important 
            //scriptProc.StartInfo.Arguments = "//B //Nologo run.vbs";

            scriptProc.StartInfo.WorkingDirectory = workingDirectory; //<---very important 
            scriptProc.StartInfo.Arguments = "//B //Nologo " + fileName;
            scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //prevent console window from popping up
            scriptProc.Start();
            scriptProc.WaitForExit(); // <-- Optional if you want program running until your script exit
            scriptProc.Close();
        }
    }
}
