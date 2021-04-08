using ControlUtils;
using Core;
using Core.Common;
using Core.Models;
using Core.Utilities;
using ManagerAppNC.Core.Services;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManagerAppNC
{
    partial class Main : Form
    {

        private readonly IFBAdsService _fbAdsService;
        private DesignService _designService;
        public Main(IFBAdsService service)
        {
            _fbAdsService = service;
            _designService = new DesignService();
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            LoadFBActions();
        }

        private void LoadFBActions()
        {
            List<FBAction> actions = _designService.GetFBActions();
            BindingSource binding = new BindingSource();
            binding.DataSource = actions;
            dgvFBAction.DataSource = binding;
        }

        private void RunFBAction(FBAction action)
        {
            FB_ACTION_HANDLE handle = action.HandleTyle.ToEnum<FB_ACTION_HANDLE>();
            switch (handle)
            {
                case FB_ACTION_HANDLE.SIMPLE:
                    RunScriptInSimpleMode(action);
                    break;
                case FB_ACTION_HANDLE.LOOP_FB_ACC:
                    break;
                case FB_ACTION_HANDLE.MIXED_LOOP_FB_ACC:
                    break;
                case FB_ACTION_HANDLE.WATCH_VIDEO_STREAM:
                    break;
               
            }
        }

        private void RunScriptInSimpleMode(FBAction action)
        {
            SlnSenarior senarior = _designService.GetSenarior(action.Action);
            if (senarior != null)
            {
                senarior.Process();
            }
        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            FBAction action = dgvFBAction.SelectedData<FBAction>();
            if (action != null)
            {
                RunFBAction(action);
            }
        }

        private void btnRunAll_Click(object sender, System.EventArgs e)
        {

        }
    }
}
