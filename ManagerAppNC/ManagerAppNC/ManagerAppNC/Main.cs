using ManagerAppNC.Core.Services;
using System.IO;
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

            ProcessorUtil.RunVBScript(Directory.GetCurrentDirectory(), "run.vbs");
        }

    }
}
