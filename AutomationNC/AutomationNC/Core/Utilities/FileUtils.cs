using Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities
{
    public class FileUtils
    {
        public static string CopyFolder(string fromFolder, string toFolder)
        {
            var source = new DirectoryInfo(fromFolder);
            var target = new DirectoryInfo(toFolder);
            Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyFolder(diSourceSubDir.FullName, nextTargetSubDir.FullName);
            }
            return toFolder;
        }
        public static string CopyFile(string fromFile, string toFile)
        {
            File.Copy(fromFile, toFile);
            return toFile;
        }

        public static string GetFile(string folder, string file)
        {
            string path = folder + "/" + file;
            return GetFile(path);
        }

        public static string GetFolder(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            string folder = fi.Directory.FullName;
            return folder;
        }
        public static string GetFile(string filePath)
        {
            string folder = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(folder);
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    fs.Close();
                }
            }
            return filePath;
        }
        public static string WriteTextFile(string filePath, string content)
        {
            string file = GetFile(filePath);
            File.WriteAllText(file, content);
            return file;
        }
        public static string CreateFolder(string path, bool deleteIfExits)
        {
            if (Directory.Exists(path) && deleteIfExits == true)
            {
                Directory.Delete(path, true);
            }
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;

        }
        public static string GetWorkingFolder()
        {
            return @"C:\QuangCaoFB420";
        }

        public static string GetDataFolder()
        {
            return GetWorkingFolder() + @"\Data" ;
        }  
        public static string GetSettingFolder()
        {
            return GetWorkingFolder() + @"\Setting" ;
        }
        public static string GetMSEdgeDriver()
        {
            return GetSettingFolder() + @"\" + FILE.MSEdgeDriverExe.ToDescriptionString();
        }
    }
}
