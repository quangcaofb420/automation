using Core;
using Core.ActionParam;
using Core.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptDesigner.CútomControl
{
    public partial class UCSenarior : UserControl
    {
        private DesignService _service;
        private SlnSenarior _senarior;
        private FBAction _fbAction;
        public UCSenarior()
        {
            _service = new DesignService();
            InitializeComponent();
        }

        public void SetSenarior(FBAction fbAction, SlnSenarior senarior)
        {
            _senarior = senarior;
            _fbAction = fbAction;

            if (_senarior == null || _senarior.Scripts == null || _senarior.Scripts.Count == 0)
            {
                _senarior = new SlnSenarior();
                _senarior.Scripts = new List<SlnScript>() { SlnScript.OpenWebsite(new OpenWebsite("", "https://www.facebook.com/")) };
            }
            GenerateScripts();
        }

        private void GenerateScripts()
        {
            tblScript.Controls.Clear();
            tblScript.RowCount = 0;
            tblScript.RowStyles.Clear();

            tblScript.RowCount = 0;

            for (int i = 0; i < _senarior.Scripts.Count; i++)
            {
                SlnScript script = _senarior.Scripts[i];
                this.GenerateScriptItem(script, i);
            }
        }
        private void GenerateScriptItem(SlnScript script, int index)
        {
            List<SlnControl> mappingControls = GetMappingControls();
            UCScriptItem item = new UCScriptItem(tblScript, script, 0, mappingControls, GetMappingControls);
            tblScript.RowCount += 1;
            tblScript.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblScript.Controls.Add(item, 0, index);
        }
   
        public List<SlnScript> GetScripts()
        {
            List<SlnScript> scripts = new List<SlnScript>();
            int rowCouunt = tblScript.RowCount;
            for (int i = 0; i < tblScript.Controls.Count; i++)
            {
                UCScriptItem uCScript = tblScript.Controls[i] as UCScriptItem;
                if (uCScript != null)
                {
                    SlnScript script = uCScript.GetScript();
                    scripts.Add(script);
                }
            }
            return scripts;
        }

        private List<SlnControl> GetMappingControls()
        {
            List<SlnControl> mappingControls = _service.GetMappingControls(_fbAction);
            return mappingControls;
        }
    }
}
