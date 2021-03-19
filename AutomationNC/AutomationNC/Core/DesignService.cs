
using Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Core
{
    public class DesignService
    {
        public static string GetMappingControlJsonFilePath()
        {
            string file = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/MappingControls.json";
            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                }
                    
            }
            return file;
        }
        public static string GetSenariorJsonFilePath()
        {
            string file = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/Senarior.json";
            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                }

            }
            return file;
        }
        public List<SlnControl> GetMappingControls()
        {
            var jsonStr = File.ReadAllText(GetMappingControlJsonFilePath());
            List<SlnControl> controls = JsonConvert.DeserializeObject<List<SlnControl>>(jsonStr);
            if (controls == null)
            {
                controls = new List<SlnControl>();
            }
            return controls;

        }

        public SlnSenarior GetSenarior()
        {
            var jsonStr = File.ReadAllText(GetSenariorJsonFilePath());
            SlnSenarior senarior = JsonConvert.DeserializeObject<SlnSenarior>(jsonStr);
            if (senarior == null)
            {
                senarior = SlnSenarior.GetInstance();
            }
            return senarior;
        }


        public void SaveMappingControls(List<SlnControl> mappingControls)
        {
            string jsonStr = JsonConvert.SerializeObject(mappingControls);
            File.WriteAllText(GetMappingControlJsonFilePath(), jsonStr);

        }
    }
}
