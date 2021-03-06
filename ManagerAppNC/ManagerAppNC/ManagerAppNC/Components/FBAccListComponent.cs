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
        private IFBAdsService fbAdsService;
        private List<FBAcc> fbAccs = new List<FBAcc>();

        public FBAccListComponent(IFBAdsService service)
        {
            this.fbAdsService = service;
            InitializeComponent();
        }

        private void FBAccListComponent_Load(object sender, EventArgs e)
        {
            this.LoadFBAccList();
        }

        private async void LoadFBAccList()
        {
            this.fbAccs = await this.fbAdsService.GetFBAccList();
            this.RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            var source = new BindingSource();
            source.DataSource = this.fbAccs;
            this.dgvFBAcc.DataSource = source;

            //dgvFBAcc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        public object GetFBAccs()
        {
            return this.fbAccs;
        }
    }
}
