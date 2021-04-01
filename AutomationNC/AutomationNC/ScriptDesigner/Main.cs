
using Core;
using Core.ActionParam;
using Core.Common;
using Core.Models;
using ScriptDesigner.Common;
using ScriptDesigner.CútomControl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptDesigner
{
    public partial class Main : Form
    {
        private List<SlnControl> _mappingControls = new List<SlnControl>();
        private DesignService service;
        private SlnSenarior _senarior;
        public Main()
        {
            service = new DesignService();
            _senarior =SlnSenarior.GetInstance();
            InitializeComponent();
        }

        private List<SlnControl> GetMappingControls()
        {
           List<SlnControl> mappingControls = service.GetMappingControls(GetFBActionType());
            return mappingControls;
        }

        private void LoadMappingControls()
        {
            _mappingControls = GetMappingControls() ;
            var source = new BindingSource();
            source.DataSource = _mappingControls;
            this.dgvMappingControls.DataSource = source;
        }
        private void LoadSenarior()
        {
            //senarior = service.GetSenarior(GetFBActionType());
            _senarior.Scripts = new List<SlnScript>() {
                SlnScript.OpenWebsite(new OpenWebsite("","https://www.facebook.com/")),
                SlnScript.IfCondition(
                    new IfCondition(
                        new List<Condition>(){
                            new Condition("a == 10",   
                                new List<SlnScript> {
                                    SlnScript.Input("",new Input( "inside if 1")),
                                    SlnScript.Input("",new Input( "inside if 2"))
                                }
                            ),
                            new Condition("a == 10",
                                new List<SlnScript> {
                                    SlnScript.Input(null,new Input( "inside if 1")),
                                    SlnScript.Input(null,new Input("inside if 2"))
                                }
                            )
                        }
                    )
                ),
                SlnScript.Sleep(new Sleep(5)),
                SlnScript.Input("txtUser",new Input( "{{a}}"))

            };

            this.GenerateSenarior();
        }

        private void btnSaveMappingControl_Click(object sender, EventArgs e)
        {
            List<SlnControl> controls = (dgvMappingControls.DataSource as BindingSource).DataSource as List<SlnControl>;
            service.SaveMappingControls(GetFBActionType(), controls);
        }

        private FB_ACTION_TYPE GetFBActionType()
        {
            int index = cbbFBActionType.SelectedIndex;
            return FB_ACTION_TYPE.AUTO_CREATE_POST_LIKE;
        }

        private void GenerateSenarior()
        {
            this.GenerateScripts();           
        }
        private void GenerateScripts()
        {
            tblScript.Controls.Clear();
            tblScript.RowCount = 0;
            tblScript.RowStyles.Clear();   //now you have zero rowstyles

            this.tblScript.RowCount = 0;

      

            for (int i = 0; i < _senarior.Scripts.Count; i ++)
            {
                SlnScript script = _senarior.Scripts[i];
                this.GenerateScriptItem(script, i);
            }
        }
         private void GenerateScriptItem(SlnScript script, int index)
        {
            //this.lvSenarior.Items.Add(new ListViewItem())
            UCScriptItem item = new UCScriptItem(tblScript, script, 0, _mappingControls, GetMappingControls);
            this.tblScript.RowCount += 1;
            this.tblScript.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblScript.Controls.Add(item, 0, index);
            //this.lvSenarior.Controls.Add(item);

        }
        private bool ContainScript(SlnScript main, SlnScript item)
        {
            if (main.GetId() == item.GetId())
            {
                return true;
            }
            //if (main.Action.Name == ACTION.IF_CONDITION)
            //{
                
            //}
            return false;
        }

        private void cbbFBActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMappingControls();
            LoadSenarior();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //this.LoadSenarior();
        }

        private void btnSaveSenarior_Click(object sender, EventArgs e)
        {
           Control controk =  tblScript.GetControlFromPosition(0, 1);
            var a = 10;
        }
    }
}
