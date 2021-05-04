
using Core.Common;
using Core.Models;
using Core.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Core
{
    public class DesignService
    {
        private static DesignService _instance = null;
        private DesignService()
        { }

        public SlnControl GetControlByName(string fbAction, string controlName)
        {
            List<SlnControl> controls = GetMappingControls(fbAction);
            SlnControl control = controls.FirstOrDefault<SlnControl>(p => p.Name == controlName);
            return control;

        }

        public static DesignService GetInstance()
        {
            if (DesignService._instance == null) 
            {
                DesignService._instance = new DesignService();
            }
            return DesignService._instance;
        }
        public static string GetFile(string fbAction, FILE_ACTION name)
        {
            string file = SeleniumUtils.GetWorkingFolderPath() + @"/" + fbAction  + "_" + name + ".json";
            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                }

            }
            return file;
        }

        public List<SlnControl> GetMappingControls(string fbAction)
        {
            return GetList<SlnControl>(fbAction, FILE_ACTION.CONTROLS);
        }
     
        public SlnSenarior GetSenarior(string fbActionName)
        {
            SlnSenarior senarior =GetObject<SlnSenarior>(fbActionName, FILE_ACTION.SENARIOR);
            return senarior;
        }
        
        public List<FBAction> GetFBActions()
        {
            return GetList<FBAction>(null, FILE_ACTION.FB_ACTIONS);
        }

        private List<T> GetList<T>(string fbAction, FILE_ACTION name)
        {
            string file = GetFile( fbAction, name);
            var jsonStr = File.ReadAllText(file);
            List<T> controls = JsonConvert.DeserializeObject<List<T>>(jsonStr);
            if (controls == null)
            {
                controls = new List<T>();
            }
            return controls;
        }
        private T GetObject<T>(string fbAction, FILE_ACTION name)
        {
            string file = GetFile( fbAction, name);
            var jsonStr = File.ReadAllText(file);
            T t = JsonConvert.DeserializeObject<T>(jsonStr);
            return t;
        }

        public void SaveFBActions(List<FBAction> actions)
        {
            string jsonStr = JsonConvert.SerializeObject(actions);
            File.WriteAllText(GetFile(null, FILE_ACTION.FB_ACTIONS), jsonStr);
        }

        public void SaveMappingControls(string fBAction, List<SlnControl> mappingControls)
        {
            string jsonStr = JsonConvert.SerializeObject(mappingControls);
            File.WriteAllText(GetFile(fBAction, FILE_ACTION.CONTROLS), jsonStr);
        }

        public void SaveSenarior(string fBAction, SlnSenarior senarior)
        {
            string jsonStr = JsonConvert.SerializeObject(senarior);
            File.WriteAllText(GetFile(fBAction, FILE_ACTION.SENARIOR), jsonStr);
        }

        public List<FBAction> RemoveFBAction(string fBAction)
        {
            List<FBAction> actions = GetFBActions();
            actions = actions.Where(act => act.Action != fBAction).ToList();
            SaveFBActions(actions);

            string script = GetFile(fBAction, FILE_ACTION.SENARIOR);
            if (File.Exists(script))
            {
                File.Delete(script);
            }
            string mappingControl = GetFile(fBAction, FILE_ACTION.CONTROLS);
            if (File.Exists(mappingControl))
            {
                File.Delete(mappingControl);
            }

            return actions;
        }
    }
}
