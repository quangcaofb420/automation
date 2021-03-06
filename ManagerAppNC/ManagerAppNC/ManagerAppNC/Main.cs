using ManagerAppNC.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerAppNC
{
     partial class Main : Form
    {
        
        private readonly IFBAdsService fbAdsService;
        
        public Main(IFBAdsService service)
        {
            // this.service = service;
            
            this.fbAdsService = service;
            InitializeComponent();
        }

    }
}
