
using ControlUtils;
using Core;
using Core.Common;
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
            _service =  DesignService.GetInstance();
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadFBActionHandleType();
            LoadFBAction();
        }
        private void LoadDataFBAction()
        {
            LoadMappingControls();
            LoadSenarior();
        }
        private void LoadFBActionHandleType()
        {
            cbbFBActionHandleTYpe.DataSource = Enum.GetValues(typeof(FB_ACTION_HANDLE));

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
            List<SlnControl> mappingControls = _service.GetMappingControls(_fbAction.Action);
            return mappingControls;
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
            _senarior = _service.GetSenariorByFBAction(_fbAction.Action);
            if (_senarior == null) 
            {
                _senarior = new SlnSenarior(_fbAction.Action, new List<SlnScript>());
            }
            ucSenarior.SetSenarior(_fbAction, _senarior);
        }

        private void btnSaveMappingControl_Click(object sender, EventArgs e)
        {
            if (dgvMappingControls.DataSource != null)
            {
                List<SlnControl> controls = (dgvMappingControls.DataSource as BindingSource).DataSource as List<SlnControl>;
                _service.SaveMappingControls(_fbAction.Action, controls);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSenarior_Click(object sender, EventArgs e)
        {
            List<SlnScript> scripts = ucSenarior.GetScripts();
            _senarior.Scripts = scripts;
            _service.SaveSenarior(_fbAction.Action, _senarior);
        }

        private void btnSaveFBActions_Click(object sender, EventArgs e)
        {
            List<FBAction> controls = (dgvFBActions.DataSource as BindingSource).DataSource as List<FBAction>;
            SaveFBActions(controls);
        }

        private void btnLoadDBAction_Click(object sender, EventArgs e)
        {
            FBAction action = dgvFBActions.SelectedData<FBAction>();
            if (action != null)
            {
                _fbAction = action;
                LoadDataFBAction();
            }
        }

        private void btnAddFBAction_Click(object sender, EventArgs e)
        {
            string action = txtActionName.Text;
            string handleType = cbbFBActionHandleTYpe.SelectedItem.ToString();
            if (action == "")
            {
                return;
            }
            txtActionName.Text = "";
            List<FBAction> actions = (dgvFBActions.DataSource as BindingSource).DataSource as List<FBAction>;
            FBAction act = new FBAction(action, handleType);
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
            List<SlnScript> scripts = ucSenarior.GetScripts();
            SlnSenarior temp = new SlnSenarior(_fbAction.Action, scripts);
            temp.Process("");
        }

        private void btnDeleteFBAction_Click(object sender, EventArgs e)
        {
            FBAction action = dgvFBActions.SelectedData<FBAction>();
            if (action != null) 
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete  \"" + action.Action + "\"", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _service.RemoveFBAction(action.Action);
                    LoadFBAction();
                }
            }
        }
    }
}
