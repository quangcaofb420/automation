using ControlUtils;
using Core;
using Core.Common;
using Core.Models;
using Core.Utilities;
using ManagerAppNC.Core.Services;
using System;
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
            _designService =  DesignService.GetInstance();
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
            }
        }

        private void RunScriptInSimpleMode(FBAction action)
        {
            GenerateFBActionRunningSimpleMode(action);
        }

        private string GenerateFBActionRunningSimpleMode(FBAction action)
        {
            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string name = milliseconds + "_" + new Random().Next();
            string actionName = action.Action;
            string path = @"C:\xXx\FBAction_" + actionName + "_" + milliseconds;
            string workingPath = FileUtils.GetWorkingFolder();
            FileUtils.CreateFolder(path, true);
            
            string batchFile = ProcessorUtil.CreateBatchFile(path + @"\run.bat", @".\AutomationNC.exe", true, actionName, path);
            FileUtils.CopyFile(workingPath + @"\AutomationNC.exe", path + @"\AutomationNC.exe");
            FileUtils.CopyFile(workingPath + @"\AutomationNC.dll", path + @"\AutomationNC.dll");
            FileUtils.CopyFile(workingPath + @"\AutomationNC.pdb", path + @"\AutomationNC.pdb");
            FileUtils.CopyFile(FileUtils.GetMSEdgeDriver(), path + @"\" + FILE.MSEdgeDriverExe.ToDescriptionString());
            ProcessorUtil.runBatchFile(batchFile);
            return path;
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
