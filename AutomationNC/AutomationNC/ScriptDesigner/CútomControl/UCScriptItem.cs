using Core.Models;
using Core.Utilities;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Core.ActionParam;
using System.Collections.Generic;
using Core.Common;
using System.Reflection;

namespace ScriptDesigner.CútomControl
{
    public partial class UCScriptItem : UserControl
    {
        private SlnScript _script;
        private int _levelIndex;
        private string Id { get; set; }
        public TableLayoutPanel ParentObj { get; set; }
        private List<SlnControl> _mappingControls;
        private Func<List<SlnControl>> _getMappingControlsFunc;
        public UCScriptItem(TableLayoutPanel parent, SlnScript script, int levelIndex, List<SlnControl> mappingControls, Func<List<SlnControl>> getMappingControlsFunc)
        {
            this.Id = "UCScriptItem_" + script.GetId() + "_" + CommonUtils.UUID();
            this.ParentObj = parent;
            this._script = script;
            this._levelIndex = levelIndex;
            this._mappingControls = mappingControls;
            this._getMappingControlsFunc = getMappingControlsFunc;
            
            InitializeComponent();
            this.cbbControl.DataSource = _mappingControls.Select(c => c.Name).ToList();
            this.cbbControl.SelectedIndex = -1;
            InitUI();
            int indent = 40;
            //this.panelMain.BackColor =  Color.FromArgb(180, 217, 255) ;
            this.panelMain.Location = new Point(this.Location.X + (_levelIndex * indent), this.Location.Y);
            this.panelMain.Width = this.panelMain.Width - (_levelIndex * indent);
            //this.Dock = DockStyle.Fill;
            //this.Height = 50;
            LoadScript();
        }

        private void InitUI()
        {
            cbbAction.SelectedIndexChanged -= new EventHandler(cbbAction_SelectedIndexChanged);
            cbbAction.DataSource = Enum.GetValues(typeof(Core.Common.ACTION));
            cbbAction.SelectedIndex = -1;
            cbbAction.SelectedIndexChanged += new EventHandler(cbbAction_SelectedIndexChanged);
        }

        private void LoadScript()
        {
            ACTION action = ScriptUtils.GetActionByDescription(_script.Action);
            this.cbbAction.SelectedItem = action;
        }

        private void cbbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
            InitData();
        }
        private void InitData()
        {
          
        }

        private ACTION GetSelectedAction()
        {
            Core.Common.ACTION action = (Core.Common.ACTION)this.cbbAction.SelectedItem;
            return action;
        }
        private void UpdateUI()
        {
            RemoveAllControls();
            Core.Common.ACTION action = GetSelectedAction() ;
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            if (definedAction == null)
            {
                return;
            }
            bool isIfCondition = action == Core.Common.ACTION.IF_CONDITION;
            CreateContextMenuAction(action);
            //this.btnAction.Visible = !isIfCondition;
            if (action == Core.Common.ACTION.IF_CONDITION)
            {
                GenerateIfCondition();
            }
            else
            {
                GenerateNormalAction();
            }

        }

       

        private void GenerateIfCondition()
        {
 
            this.cbbControl.Visible = false;
            this.AutoSize = true;
            this.panelMain.AutoSize = true;

            TableLayoutPanel tbl = CreateTableIfCondition();

            tbl.RowStyles.Clear();   //now you have zero rowstyles
            tbl.RowCount = 0;

            List<SlnScript> conditions = _script.Param as List<SlnScript>;
            if (conditions == null || conditions.Count == 0)
            {
                conditions = new List<SlnScript>() { 
                    SlnScript.Condition(new Condition("true", new List<SlnScript>(){ SlnScript.Sleep(new Sleep(10))}))
                };

            }
            for (int i = 0; i < conditions.Count; i++)
            {
                SlnScript condition = conditions[i];
                UCScriptItem conditionItem = new UCScriptItem(tbl, condition,  _levelIndex + 1, _mappingControls, _getMappingControlsFunc);
                tbl.RowCount += 1;
                tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl.Controls.Add(conditionItem, 0, tbl.RowCount - 1);

                TableLayoutPanel tblActionss = CreateTableIfCondition();

                tblActionss.Location = new Point(0, 40);

                tblActionss.RowStyles.Clear();   //now you have zero rowstyles
                tblActionss.RowCount = 0;
                Condition con = condition.Param as Condition;
                List<SlnScript> scripts = con.Actions;
                for (int j = 0; j < scripts.Count; j++)
                {
                    SlnScript script = scripts[j];
                    UCScriptItem item = new UCScriptItem(tblActionss, script,  _levelIndex + 2, _mappingControls, _getMappingControlsFunc);
                    tblActionss.RowCount += 1;
                    tblActionss.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tblActionss.Controls.Add(item, 0, j + 1);
                }

                tbl.RowCount += 1;
                tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl.Controls.Add(tblActionss, 0, tbl.RowCount - 1);
            }
            this.panelMain.Controls.Add(tbl);


            this.panelMain.Refresh();
            this.Refresh();
        }

        private void GenerateNormalAction()
        {
            Core.Common.ACTION action = (Core.Common.ACTION)this.cbbAction.SelectedItem;
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            bool requiredElement = definedAction.RequiredElement;
            bool isCondition = action == Core.Common.ACTION.CONDITION;
            this.cbbAction.Enabled = !isCondition;
            this.cbbControl.Visible = requiredElement;
            if (requiredElement)
            {
                object control = ClassUtils.GetProppertyValue(_script.Param, "Control");
                if (control != null)
                {
                    cbbControl.SelectedItem = control.ToString();
                }
            }
            Type paramType = definedAction.ParamType;
            if (paramType != null)
            {
                string[] prs = ClassUtils.GetPropertyNames(paramType).Where(pr => requiredElement == false || pr != "Control").Where(pr => !isCondition || pr != "Actions").ToArray();
                int x = this.cbbAction.Location.X + this.cbbAction.Width + (requiredElement ? this.cbbControl.Width : 0) + 10;
                foreach (string pr in prs)
                {
                    x += GenerateLabelParam(pr, x);

                    string defaultValue = (ClassUtils.GetProppertyValue(_script.Param, pr) ?? "").ToString();
                    x += GenerateTextboxParam(pr, x, defaultValue);
                    x += 10;
                }
            }
        }

        public SlnScript GetScript()
        {
            ACTION action = GetSelectedAction();
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            Type paramType = definedAction.ParamType;
            String selectedControl = "";
            bool requiredElement = definedAction.RequiredElement;
            if (action == ACTION.IF_CONDITION || action == ACTION.CONDITION)
            {
                return _script;
            }
            if (requiredElement)
            {
                selectedControl = cbbControl.SelectedItem.ToString();
            }

            string[] prs = ClassUtils.GetPropertyNames(paramType).Where(pr => requiredElement == false || pr != "Control").ToArray();
            List<string> args = new List<string>();
           
            for (int i = 0; i < prs.Length; i++)
            {
                string pr = prs[i];
                Control[] controls = this.panelMain.Controls.Find("txt" + pr, false);
                if (controls != null && controls.Length > 0)
                {
                    TextBox textBox = (TextBox)controls[0];
                    string value = textBox.Text;
                    args.Add(value);
                }
            }
            object instanceArg = ClassUtils.Constructor(paramType, args.ToArray());

            object res = ClassUtils.CallStaticFunction(typeof(SlnScript), paramType.Name, requiredElement ? new[] {selectedControl, instanceArg } : new[] { instanceArg });

            return _script;
           
        }

        private void txtParam_TextChanged(object sender, EventArgs e)
        {
            //TextBox textbox = (TextBox)sender;
            //Size size = TextRenderer.MeasureText(textbox.Text, textbox.Font);
            //textbox.Width = size.Width < 50 ? 50 : (size.Width > 300 ? 300 : size.Width);
        }

       
        private int GenerateTextboxParam(string paramname, int locationX, string defaultValue)
        {
            TextBox textbox = new TextBox();
            textbox.Location = new System.Drawing.Point(locationX + 12, 0);
            textbox.Name = "txt" + paramname;
            //textbox.Text = "txt" + paramname;
            textbox.Width = 300;

            textbox.Text = defaultValue;
            textbox.TextChanged += new EventHandler(txtParam_TextChanged);
            //textbox.TextAlign = HorizontalAlignment.Center;
            this.panelMain.Controls.Add(textbox);
            return textbox.Width;
        }

        private int GenerateLabelParam(string paramname, int locationX)
        {
            Label label = new Label();
            label.Location = new System.Drawing.Point(locationX + 12, 3);
            label.Name = "lbl" + paramname;
            label.Text = paramname;
            label.AutoSize = true;
            this.panelMain.Controls.Add(label);
            return label.Width;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            cmtAction.Show(PointToScreen(((Button)sender).Location));
        }

        private void cmtAction_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //_onMenuAction(this, MENU_ACTION.INSERT_BELOW);
            TableLayoutPanel tbl = (TableLayoutPanel)ParentObj;
            TableLayoutPanelCellPosition cellPosition = tbl.GetPositionFromControl(this);
            int rowIndex = cellPosition.Row;

            UCScriptItem script = new UCScriptItem(tbl, SlnScript.Sleep(new Sleep(10)), _levelIndex, _mappingControls, _getMappingControlsFunc);
            tbl.RowCount += 1;
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add(script, 0, rowIndex);
            SlnScript sc = GetScript();


            var a = 10;
        }

        private TableLayoutPanel CreateTableIfCondition()
        {
            TableLayoutPanel tbl = new System.Windows.Forms.TableLayoutPanel();
            tbl.AutoSize = true;
            tbl.ColumnCount = 1;
            tbl.Location = new System.Drawing.Point(0, 30);
            tbl.Name = "TableLayoutPanel_" + this.Id + "_"+ CommonUtils.UUID();
            //tbl.Size = new System.Drawing.Size(200, 200);
            //tbl.BackColor = Color.Yellow;
            return tbl;
        }

        private void cbbControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var a = 10;
            }
        }

        private void CreateContextMenuAction(ACTION action)
        {
            this.cmtAction.Items.Clear();

            if (action == ACTION.CONDITION)
            {
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = "InsertConditionAbove", Text = "Insert Condition Above", ToolTipText = action.ToDescriptionString() });
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = "InsertConditionBelow", Text = "Insert Condition Below", ToolTipText = action.ToDescriptionString() });
            }
            else if (action == ACTION.IF_CONDITION)
            {
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = "InsertCondition", Text = "Insert Condition", ToolTipText = action.ToDescriptionString() });
            }

            if (action != ACTION.CONDITION)
            {
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = "InsertAbove", Text = "Insert Above", ToolTipText = action.ToDescriptionString() });
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = "InsertBelow", Text = "Insert Below", ToolTipText = action.ToDescriptionString() });
            }

            this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = "Delete", Text = "DELETE", BackColor = Color.Red, ForeColor = Color.White, ToolTipText = action.ToDescriptionString() });
        }

        private void RemoveAllControls()
        {
            string[] acceptedControls = new string[] { "cbbAction", "cbbControl", "btnAction" };
            while (this.panelMain.Controls.Count > acceptedControls.Length)
            {
                ControlCollection controls = this.panelMain.Controls;

                foreach (Control control in controls)
                {
                    if (!acceptedControls.Contains(control.Name))
                    {
                        control.Visible = false;
                        this.panelMain.Controls.Remove(control);
                        control.Dispose();
                        this.panelMain.Refresh();
                    }
                }
            }
            this.panelMain.Refresh();
            this.Refresh();

        }
    }
}
