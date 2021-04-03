
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
      

        public static string GetFile(FBAction fbAction, FILE_ACTION name)
        {
            string file = SeleniumUtils.GetWorkingFolderPath() + @"/" + (fbAction != null ? fbAction.Action : "") + "_" + name + ".json";
            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                }

            }
            return file;
        }

        public List<SlnControl> GetMappingControls(FBAction fbAction)
        {
            return GetList<SlnControl>(fbAction, FILE_ACTION.CONTROLS);
        }
        public List<SlnScript> GetScripts(FBAction fbAction)
        {
            return GetList<SlnScript>(fbAction, FILE_ACTION.SCRIPTS);
        }
          public List<SlnScript> GetScripts(string fbAction)
        {
            return GetList<SlnScript>(new FBAction(fbAction), FILE_ACTION.SCRIPTS);
        }
        
        public List<FBAction> GetFBActions()
        {
            return GetList<FBAction>(null, FILE_ACTION.FB_ACTIONS);
        }

        private List<T> GetList<T>(FBAction fbAction, FILE_ACTION name)
        {
            string file = GetFile(fbAction, name);
            var jsonStr = File.ReadAllText(file);
            List<T> controls = JsonConvert.DeserializeObject<List<T>>(jsonStr);
            if (controls == null)
            {
                controls = new List<T>();
            }
            return controls;
        }

        public void SaveFBActions(List<FBAction> actions)
        {
            string jsonStr = JsonConvert.SerializeObject(actions);
            File.WriteAllText(GetFile(null, FILE_ACTION.FB_ACTIONS), jsonStr);
        }

        public void SaveMappingControls(FBAction fBAction, List<SlnControl> mappingControls)
        {
            string jsonStr = JsonConvert.SerializeObject(mappingControls);
            File.WriteAllText(GetFile(fBAction, FILE_ACTION.CONTROLS), jsonStr);
        }
        public void SaveScripts(FBAction fBAction, List<SlnScript> scripts)
        {
            string jsonStr = JsonConvert.SerializeObject(scripts);
            File.WriteAllText(GetFile(fBAction, FILE_ACTION.SCRIPTS), jsonStr);
        }
    }
}
