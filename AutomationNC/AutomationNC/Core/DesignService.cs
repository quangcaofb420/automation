
using Core.Common;
using Core.Models;
using Core.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Core
{
    public class DesignService
    {
        public static string GetMappingControlJsonFilePath(FB_ACTION_TYPE type)
        {
            string file = SeleniumUtils.GetWorkingFolderPath() + @"/MappingControls_" + type + ".json";
            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                }
                    
            }
            return file;
        }
        public static string GetSenariorJsonFilePath(FB_ACTION_TYPE type)
        {
            string file = SeleniumUtils.GetWorkingFolderPath() + @"/Senarior_"+ type + ".json";
            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                }

            }
            return file;
        }
        public List<SlnControl> GetMappingControls(FB_ACTION_TYPE type)
        {
            var jsonStr = File.ReadAllText(GetMappingControlJsonFilePath(type));
            List<SlnControl> controls = JsonConvert.DeserializeObject<List<SlnControl>>(jsonStr);
            if (controls == null)
            {
                controls = new List<SlnControl>();
            }
            return controls;

        }

        public SlnSenarior GetSenarior(FB_ACTION_TYPE type)
        {
            var jsonStr = File.ReadAllText(GetSenariorJsonFilePath(type));
            SlnSenarior senarior = JsonConvert.DeserializeObject<SlnSenarior>(jsonStr);
            if (senarior == null)
            {
                senarior = SlnSenarior.GetInstance();
            }
            return senarior;
        }


        public void SaveMappingControls(FB_ACTION_TYPE type, List<SlnControl> mappingControls)
        {
            string jsonStr = JsonConvert.SerializeObject(mappingControls);
            File.WriteAllText(GetMappingControlJsonFilePath(type), jsonStr);

        }
    }
}
