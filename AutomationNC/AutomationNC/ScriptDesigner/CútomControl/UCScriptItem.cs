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
            //this.panelMain.AutoSize = true;
            //this.panelMain.BackColor = Color.FromArgb(180, 217, 255);
            this.panelMain.Location = new Point(this.Location.X + (_levelIndex * indent), this.Location.Y);
            this.panelMain.Width = this.panelMain.Width - (_levelIndex * indent);
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
            this.Height = 30;
            Core.Common.ACTION action = GetSelectedAction() ;
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            if (definedAction == null)
            {
                return;
            }
            CreateContextMenuAction(action);
            if (action == Core.Common.ACTION.IF_CONDITION)
            {
                GenerateIfCondition();
            }
            else if (action == ACTION.CONDITION)
            {
                GenerateNormalAction();
                GenerateCondition();
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

            List<SlnScript> conditions = _script.Param as List<SlnScript>;
            if (conditions == null || conditions.Count == 0)
            {
                conditions = new List<SlnScript>() {
                    SlnScript.Condition(
                        new Condition("true",
                        new List<SlnScript>(){
                                SlnScript.Sleep(new Sleep(10))
                            }
                        )
                    )
                };
            }
            for (int i = 0; i < conditions.Count; i++)
            {
                SlnScript condition = conditions[i];
                UCScriptItem conditionItem = new UCScriptItem(tbl, condition,  _levelIndex + 1, _mappingControls, _getMappingControlsFunc);
                tbl.RowCount += 1;
                tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl.Controls.Add(conditionItem, 0, tbl.RowCount - 1);
            }
            this.panelMain.Controls.Add(tbl);
            this.panelMain.Refresh();
            this.Refresh();
        }

        private void GenerateCondition()
        {
            this.cbbControl.Visible = false;
            this.AutoSize = true;
            this.panelMain.AutoSize = true;

            Condition condition = _script.Param as Condition;

            TableLayoutPanel tbl = CreateTableIfCondition();

            List<SlnScript> scripts = condition.Actions;
            for (int i = 0; i < scripts.Count; i++)
            {
                SlnScript script = scripts[i];
                UCScriptItem item = new UCScriptItem(tbl, script, _levelIndex, _mappingControls, _getMappingControlsFunc);
                tbl.RowCount += 1;
                tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl.Controls.Add(item, 0, tbl.RowCount - 1);
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
               String control = _script.Control;
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

                    string defaultValue = (ClassUtils.GetProppertyValue(paramType, _script.Param, pr) ?? "").ToString();
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
            String selectedControl = null ;
            bool requiredElement = definedAction.RequiredElement;
            List<SlnScript> conditionActions = new List<SlnScript>();
            if (action == ACTION.IF_CONDITION || action == ACTION.CONDITION)
            {
                if (action == ACTION.IF_CONDITION)
                {
                    List<SlnScript> conditions = new List<SlnScript>();
                    TableLayoutPanel tbl = this.panelMain.Controls[3] as TableLayoutPanel;
                    for (int i = 0; i < tbl.RowCount; i++)
                    {
                        UCScriptItem conditionUI = tbl.GetControlFromPosition(0, i) as UCScriptItem;
                        SlnScript condition = conditionUI.GetScript();
                        conditions.Add(condition);
                    }

                    IfCondition ifCondition = new IfCondition(conditions);
                    SlnScript script = SlnScript.IfCondition(ifCondition);
                    return script;
                }
                else
                {
                    TableLayoutPanel tblActions = this.panelMain.Controls[5] as TableLayoutPanel;
                    for (int i = 1; i < tblActions.RowCount + 1; i++)
                    {
                        UCScriptItem conditionUI = tblActions.GetControlFromPosition(0, i) as UCScriptItem;
                        SlnScript act = conditionUI.GetScript();
                        conditionActions.Add(act);
                    }
                }
            }
            if (requiredElement && cbbControl.SelectedItem != null)
            {
                selectedControl = cbbControl.SelectedItem.ToString();
            }

            string[] prs = ClassUtils.GetPropertyNames(paramType).Where(pr => requiredElement == false || pr != "Control").ToArray();
            List<object> args = new List<object>();
           
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


            if (action == ACTION.CONDITION)
            {
                // add list of script actions
                args.Add(conditionActions);
            }

            object instanceArg = ClassUtils.Constructor(paramType, args.ToArray());


            object res = ClassUtils.CallStaticFunction(typeof(SlnScript), paramType.Name, requiredElement ? new[] {selectedControl, instanceArg } : new[] { instanceArg });

            return res as SlnScript;
           
        }

        private void txtParam_MouseHover(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show(textbox.Text, textbox, 0, 0, VisibleTime);
            //Size size = TextRenderer.MeasureText(textbox.Text, textbox.Font);
            //textbox.Width = size.Width < 50 ? 50 : (size.Width > 300 ? 300 : size.Width);
        }

       
        private int GenerateTextboxParam(string paramname, int locationX, string defaultValue)
        {
            TextBox textbox = new TextBox();
            textbox.Location = new System.Drawing.Point(locationX + 12, 1);
            textbox.Name = "txt" + paramname;
            //textbox.Text = "txt" + paramname;
            //textbox.Width = 300;
            textbox.Text = defaultValue;
            textbox.MouseHover += new EventHandler(txtParam_MouseHover);
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
            //TableLayoutPanel tbl = (TableLayoutPanel)ParentObj;
            //TableLayoutPanelCellPosition cellPosition = tbl.GetPositionFromControl(this);
            //int rowIndex = cellPosition.Row;

            //UCScriptItem script = new UCScriptItem(tbl, SlnScript.Sleep(new Sleep(10)), _levelIndex, _mappingControls, _getMappingControlsFunc);
            //tbl.RowCount += 1;
            //tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //tbl.Controls.Add(script, 0, rowIndex);
            SlnScript sc = GetScript();


            var a = 10;
        }

        private TableLayoutPanel CreateTableIfCondition()
        {
            TableLayoutPanel tbl = new System.Windows.Forms.TableLayoutPanel();
            tbl.Controls.Clear();
            tbl.AutoSize = true;
            //tbl.RowCount = 0;
            //tbl.ColumnCount = 1;
            tbl.Location = new System.Drawing.Point(0, 30);
            tbl.Height = 0;
            tbl.Name = "TableLayoutPanel";
            //tbl.Size = new System.Drawing.Size(200, 200);
            tbl.RowStyles.Clear();   //now you have zero rowstyles

            return tbl;
        }

        private void cbbControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                object selectedItem = cbbControl.SelectedItem;
                List<SlnControl> controls = _getMappingControlsFunc();
                this.cbbControl.DataSource = null;
                this.cbbControl.DataSource = controls.Select(c => c.Name).ToList();
                this.cbbControl.SelectedItem = selectedItem;
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
