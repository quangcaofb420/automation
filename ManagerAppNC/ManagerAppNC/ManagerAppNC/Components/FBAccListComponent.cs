using ManagerAppNC.Core.Services;
using ManagerAppNC.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ManagerAppNC.Components
{
    partial class FBAccListComponent : UserControl
    {
        private IFBAdsService _fbAdsService;
        private List<FBAcc> _fbAccs = new List<FBAcc>();

        public FBAccListComponent(IFBAdsService service)
        {
            _fbAdsService = service;
            InitializeComponent();
        }  
        public FBAccListComponent()
        {
            InitializeComponent();
        }

        private void FBAccListComponent_Load(object sender, EventArgs e)
        {
            this.LoadFBAccList();
        }

        private async void LoadFBAccList()
        {
            if (_fbAdsService != null)
            {
                _fbAccs = await _fbAdsService.GetFBAccList();
                this.RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            var source = new BindingSource();
            source.DataSource = _fbAccs;
            this.dgvFBAcc.DataSource = source;

        }

        public List<FBAcc> GetFBAccs()
        {
            return _fbAccs;
        }
    }
}
