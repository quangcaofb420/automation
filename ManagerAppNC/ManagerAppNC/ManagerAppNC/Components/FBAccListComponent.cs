using ManagerAppNC.Core.Services;
using ManagerAppNC.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ManagerAppNC.Components
{
    public partial class FBAccListComponent : UserControl
    {
        private IFBAdsService service;
        private List<FBAcc> fbAccs = new List<FBAcc>();
      
        public FBAccListComponent()
        {
            InitializeComponent();
        }

        private void FBAccListComponent_Load(object sender, EventArgs e)
        {
            this.LoadFBAccList();
        }

        private async void LoadFBAccList() {
           // this.fbAccs = await this.service.GetFBAccList();
            this.RefreshDataGridView();
        }

        private void RefreshDataGridView() 
        {
            var source = new BindingSource();
            source.DataSource = this.fbAccs;
            this.dgvFBAcc.DataSource = source;
            this.dgvFBAcc.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        public object GetFBAccs()
        {
            return this.fbAccs;
        }
    }
}
