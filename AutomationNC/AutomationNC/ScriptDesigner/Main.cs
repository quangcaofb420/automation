
using Core;
using Core.ActionParam;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptDesigner
{
    public partial class Main : Form
    {
        private List<SlnControl> _mappingControls = new List<SlnControl>();
        private DesignService _service;
        private SlnSenarior _senarior;
        private FBAction _fbAction = null;
        public Main()
        {
            _service = new DesignService();
            _senarior = new SlnSenarior();
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadFBAction();
        }
        private void LoadDataFBAction()
        {
            LoadMappingControls();
            LoadSenarior();
        }

        private void LoadFBAction()
        {
            List<FBAction> fBActions = GetFBActions();
            
            dgvFBActions.AutoGenerateColumns = true;

            BindingSource source = new BindingSource();
            source.DataSource = fBActions;
            dgvFBActions.DataSource = source;
            dgvFBActions.Refresh();
        }
        private List<FBAction> GetFBActions()
        {
            List<FBAction> fBActions = _service.GetFBActions();
            return fBActions;
        }

        private List<SlnControl> GetMappingControls()
        {
            List<SlnControl> mappingControls = _service.GetMappingControls(_fbAction);
            return mappingControls;
        }
         private List<SlnScript> GetScripts()
        {
            List<SlnScript> scripts = _service.GetScripts(_fbAction);
            return scripts;
        }

        private void LoadMappingControls()
        {
            this.dgvMappingControls.DataSource = null;
            _mappingControls = GetMappingControls() ;
            var source = new BindingSource();
            source.DataSource = _mappingControls;
            this.dgvMappingControls.DataSource = source;
        }
        private void LoadSenarior()
        {
            _senarior.Scripts = GetScripts();
            ucSenarior.SetSenarior(_fbAction, _senarior);
        }

        private void btnSaveMappingControl_Click(object sender, EventArgs e)
        {
            List<SlnControl> controls = (dgvMappingControls.DataSource as BindingSource).DataSource as List<SlnControl>;
            _service.SaveMappingControls(_fbAction, controls);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSenarior_Click(object sender, EventArgs e)
        {
            List<SlnScript> scripts = ucSenarior.GetScripts();
            _service.SaveScripts(_fbAction, scripts);
        }

        private void btnSaveFBActions_Click(object sender, EventArgs e)
        {
            List<FBAction> controls = (dgvFBActions.DataSource as BindingSource).DataSource as List<FBAction>;
            SaveFBActions(controls);
        }

        private void btnLoadDBAction_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvFBActions.SelectedRows;
            if (selectedRows.Count > 0)
            {
                FBAction fBAction = selectedRows[0].DataBoundItem as FBAction;
                _fbAction = fBAction; 
                LoadDataFBAction();
            }
        }

        private void btnAddFBAction_Click(object sender, EventArgs e)
        {
            string action = txtActionName.Text;
            if (action == "")
            {
                return;
            }
            txtActionName.Text = "";
            List<FBAction> actions = (dgvFBActions.DataSource as BindingSource).DataSource as List<FBAction>;
            FBAction act = new FBAction();
            act.Action = action;
            actions.Add(act);
            SaveFBActions(actions);
            LoadFBAction();
        }
        private void SaveFBActions(List<FBAction> actions)
        {
            _service.SaveFBActions(actions);
        }

        private void btnEunSenarior_Click(object sender, EventArgs e)
        {
            _senarior.Scripts = ucSenarior.GetScripts();
            _senarior.Process();
        }
    }
}
