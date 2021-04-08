using System.Diagnostics;

namespace Core.Utilities
{
    class ProcessorUtil
    {
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
