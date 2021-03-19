
using Core;
using Core.Models;
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
            LoadMappingControls();
            LoadSenarior();
        }

        private void LoadMappingControls()
        {
            mappingControls =  service.GetMappingControls();
            var source = new BindingSource();
            source.DataSource = mappingControls;
            this.dgvMappingControls.DataSource = source;
        }
        private void LoadSenarior()
        {
            senarior = service.GetSenarior();
            var source = new BindingSource();
            source.DataSource = senarior.Scripts;
            this.dgvSenarior.DataSource = source;


        }

        private void btnSaveMappingControl_Click(object sender, EventArgs e)
        {
            List<SlnControl> controls = (dgvMappingControls.DataSource as BindingSource).DataSource as List<SlnControl>;
            service.SaveMappingControls(controls);
        }
    }
}
