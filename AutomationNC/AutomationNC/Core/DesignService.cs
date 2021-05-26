
using Core.Common;
using Core.Models;
using Core.Utilities;
using Newtonsoft.Json;
using System;
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

        private static string GetFBActionFile()
        {
            return FileUtils.GetFile(FileUtils.GetSettingFolder(), "FBAction.json");
        }
        public static string GetDataFile(string fbAction, FILE_ACTION name)
        {
            string path = FileUtils.GetDataFolder() + @"/" + fbAction ;
            return FileUtils.GetFile(path, name + ".json");
        }

       
        public static string GetContentFile(string path)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    fs.Close();
                }

            }
            return File.ReadAllText(path);
        }

        public List<SlnControl> GetMappingControls(string fbAction)
        {
            return GetDataList<SlnControl>(fbAction, FILE_ACTION.CONTROLS);
        }
     
        public SlnSenarior GetSenariorByFBAction(string fbActionName)
        {
            string file = GetDataFile(fbActionName, FILE_ACTION.SENARIOR);
            SlnSenarior senarior = GetSenariorByFile(file);
            return senarior;
        }

        public SlnSenarior GetSenariorByFile(string file)
        {
            SlnSenarior senarior = GetDataObject<SlnSenarior>(file);
            return senarior;
        }

        public List<FBAction> GetFBActions()
        {
            string file = GetFBActionFile();
            return GetList<FBAction>(file);
        }

        public void SaveFBActions(List<FBAction> actions)
        {
            string jsonStr = JsonConvert.SerializeObject(actions);
            File.WriteAllText(GetFBActionFile(), jsonStr);
        }

        private List<T> GetDataList<T>(string fbAction, FILE_ACTION name)
        {
            string file = GetDataFile( fbAction, name);
            return GetList<T>(file);
        }
        private List<T> GetList<T>(string path)
        {
            var jsonStr = File.ReadAllText(path);
            List<T> controls = JsonConvert.DeserializeObject<List<T>>(jsonStr);
            if (controls == null)
            {
                controls = new List<T>();
            }
            return controls;
        }
        private T GetDataObject<T>(string file)
        {
            var jsonStr = File.ReadAllText(file);
            T t = JsonConvert.DeserializeObject<T>(jsonStr);
            return t;
        }

        public void SaveMappingControls(string fBAction, List<SlnControl> mappingControls)
        {
            string jsonStr = JsonConvert.SerializeObject(mappingControls);
            File.WriteAllText(GetDataFile(fBAction, FILE_ACTION.CONTROLS), jsonStr);
        }

        public void SaveSenarior(string fBAction, SlnSenarior senarior)
        {
            string jsonStr = JsonConvert.SerializeObject(senarior);
            File.WriteAllText(GetDataFile(fBAction, FILE_ACTION.SENARIOR), jsonStr);
        }

        public List<FBAction> RemoveFBAction(string fBAction)
        {
            List<FBAction> actions = GetFBActions();
            actions = actions.Where(act => act.Action != fBAction).ToList();
            SaveFBActions(actions);

            string script = GetDataFile(fBAction, FILE_ACTION.SENARIOR);
            if (File.Exists(script))
            {
                File.Delete(script);
            }
            string mappingControl = GetDataFile(fBAction, FILE_ACTION.CONTROLS);
            if (File.Exists(mappingControl))
            {
                File.Delete(mappingControl);
            }

            return actions;
        }

        public T GetObjectFromJsonFile<T>(string path)
        {
            string jsonStr = GetContentFile(path);
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
      
    }
}
