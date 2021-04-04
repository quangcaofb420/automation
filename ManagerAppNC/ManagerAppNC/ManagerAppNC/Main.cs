using Core;
using Core.Models;
using ManagerAppNC.Core.Services;
using System.Collections.Generic;
using System.IO;
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

    }
}
