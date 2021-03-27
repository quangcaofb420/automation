
using Core;
using Core.ActionParam;
using Core.Common;
using Core.Models;
using ScriptDesigner.CútomControl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptDesigner
{
    public partial class Main : Form
    {
        private List<SlnControl> mappingControls = new List<SlnControl>();
        private SlnSenarior senarior;
        private DesignService service;
        public Main()
        {
            service = new DesignService();
            InitializeComponent();
        }

        private void LoadMappingControls()
        {
            mappingControls = service.GetMappingControls(GetFBActionType());
            var source = new BindingSource();
            source.DataSource = mappingControls;
            this.dgvMappingControls.DataSource = source;
        }
        private void LoadSenarior()
        {
            senarior = service.GetSenarior(GetFBActionType());
            this.GenerateSenarior(senarior);
        }

        private void btnSaveMappingControl_Click(object sender, EventArgs e)
        {
            List<SlnControl> controls = (dgvMappingControls.DataSource as BindingSource).DataSource as List<SlnControl>;
            service.SaveMappingControls(GetFBActionType(), controls);
        }

        private FB_ACTION_TYPE GetFBActionType()
        {
            int index = cbbFBActionType.SelectedIndex;
            return FB_ACTION_TYPE.AUTO_CREATE_POST_LIKE;
        }

        private void GenerateSenarior(SlnSenarior senarior)
        {
            this.GenerateScripts(senarior.Scripts);           
        }
        private void GenerateScripts(List<SlnScript> scripts)
        {
            this.lvSenarior.Items.Clear();
            UCScriptItem item = new UCScriptItem(SlnScript.Sleep(new Sleep(5)), 0, 0);
            this.lvSenarior.Controls.Add(item);
            for (int i = 0; i < scripts.Count; i ++)
            {
                SlnScript script = scripts[i];
                this.GenerateScriptItem(script, i);
            }
        }
         private void GenerateScriptItem(SlnScript script, int index)
        {
            //this.lvSenarior.Items.Add(new ListViewItem())
            UCScriptItem item = new UCScriptItem(script, index, 0);
            this.lvSenarior.Controls.Add(item);

        }

        private void cbbFBActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMappingControls();
            LoadSenarior();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.LoadSenarior();
        }
    }
}
