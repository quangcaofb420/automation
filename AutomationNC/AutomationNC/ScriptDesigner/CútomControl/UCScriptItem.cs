using Core.Models;
using Core.Utilities;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Core.ActionParam;
using OpenQA.Selenium.Interactions;
using System.Runtime.CompilerServices;
using ScriptDesigner.Common;
using System.Collections.Generic;
using Core.Common;

namespace ScriptDesigner.CútomControl
{
    public partial class UCScriptItem : UserControl
    {
        private SlnScript _script;
        private int _index;
        private int _levelIndex;
        private Action<UCScriptItem, MENU_ACTION> _onMenuAction;

        public SlnScript Script { get; }
        public UCScriptItem Parent { get; set; }
        public UCScriptItem(UCScriptItem parent, SlnScript script, int index, int levelIndex,Action<UCScriptItem, MENU_ACTION> onMenuAction)
        {
            this.Parent = parent;
            this._script = script;
            this._index = index;
            this._levelIndex = levelIndex;
            this._onMenuAction = onMenuAction;
            InitializeComponent();
            InitUI();
            int indent = 40;
            //this.panelMain.BackColor = index % 2 == 0 ? Color.FromArgb(180, 217, 255) : Color.FromArgb(223, 237, 251);
            this.panelMain.Location = new Point(this.Location.X + (_levelIndex * indent), this.Location.Y);
            this.panelMain.Width = this.panelMain.Width - (_levelIndex * indent);
            //this.Dock = DockStyle.Fill;
            //this.Height = 50;
            LoadScript();
        }

        public SlnScript GetScript()
        {
            return _script;
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
        private void UpdateUI()
        {
            RemoveAllControls();
            Core.Common.ACTION action = (Core.Common.ACTION)this.cbbAction.SelectedItem;
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            if (definedAction == null)
            {
                return;
            }
            bool isIfCondition = action == Core.Common.ACTION.IF_CONDITION;
            this.btnAction.Visible = !isIfCondition;
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
            this.cbbAction.Visible = false;
            this.cbbControl.Visible = false;
            this.AutoSize = true;
            this.panelMain.AutoSize = true;

            TableLayoutPanel tbl = CreateTableIfCondition();

            tbl.RowStyles.Clear();   //now you have zero rowstyles
            tbl.RowCount = 0;

            List<SlnScript> conditions = _script.Param as List<SlnScript>;
            for (int i = 0; i < conditions.Count; i++)
            {
                SlnScript condition = conditions[i];
                UCScriptItem conditionItem = new UCScriptItem(this, condition, 0, _levelIndex + 1, this._onMenuAction);
                tbl.RowCount += 1;
                tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl.Controls.Add(conditionItem, 0, tbl.RowCount - 1);


                TableLayoutPanel tblActionss = CreateTableIfCondition();
                tblActionss.RowStyles.Clear();   //now you have zero rowstyles
                tblActionss.RowCount = 0;
                Condition con = condition.Param as Condition;
                List<SlnScript> scripts = con.Actions;
                for (int j = 0; j < scripts.Count; j++)
                {
                    SlnScript script = scripts[j];
                    UCScriptItem item = new UCScriptItem(this, script, 0, _levelIndex + 2, this._onMenuAction);
                    //item.Dock = DockStyle.Fill;
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

        private void GenerateCondition()
        {
            this.cbbAction.Visible = false;
            this.cbbControl.Visible = false;
            this.AutoSize = true;
            this.panelMain.AutoSize = true;
            
            TableLayoutPanel tbl = CreateTableIfCondition();

            tbl.RowStyles.Clear();   //now you have zero rowstyles
            tbl.RowCount = 0;

            UCScriptItem conditionItem = new UCScriptItem(this, _script, 0, _levelIndex + 1, this._onMenuAction);
            tbl.RowCount += 1;
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add(conditionItem, 0, tbl.RowCount - 1);

            Condition condition = _script.Param as Condition;
            List<SlnScript> actions = condition.Actions;
            for (int i = 0; i < actions.Count; i++)
            {
                SlnScript action = actions[i];
                UCScriptItem script = new UCScriptItem(this, action, 0, _levelIndex + 1, this._onMenuAction);
                tbl.RowCount += 1;
                tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl.Controls.Add(script, 0, tbl.RowCount - 1);
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

            Type paramType = definedAction.ParamType;
            if (paramType != null)
            {
                string[] prs = ClassUtils.GetPropertyNames(paramType).Where(pr => requiredElement == false || pr != "Control").Where(pr => !isCondition || pr != "Actions").ToArray();
                int x = this.cbbAction.Location.X + this.cbbAction.Width + (requiredElement ? this.cbbControl.Width : 0);
                foreach (string pr in prs)
                {
                    x += GenerateLabelParam(pr, x);

                    string defaultValue = (ClassUtils.GetProppertyValue(_script.Param, pr) ?? "").ToString();
                    x += GenerateTextboxParam(pr, x, defaultValue);
                    x += 10;
                }
            }
        }
        private void txtParam_TextChanged(object sender, EventArgs e)
        {
            //TextBox textbox = (TextBox)sender;
            //Size size = TextRenderer.MeasureText(textbox.Text, textbox.Font);
            //textbox.Width = size.Width < 50 ? 50 : (size.Width > 300 ? 300 : size.Width);
        }

        private void RemoveAllControls()
        {
            string[] acceptedControls = new string[] { "cbbAction", "cbbControl", "btnAction", "tblÌConditionScript" };
            while (this.panelMain.Controls.Count > acceptedControls.Length)
            {
                ControlCollection controls = this.panelMain.Controls;

                foreach (Control control in controls)
                {
                    if (!acceptedControls.Contains(control.Name))
                    {
                        this.panelMain.Controls.Remove(control);
                        control.Dispose();
                    }
                }
                this.panelMain.Refresh();
            }
            
        }
        private int GenerateTextboxParam(string paramname, int locationX, string defaultValue)
        {
            TextBox textbox = new TextBox();
            textbox.Location = new System.Drawing.Point(locationX + 8, 8);
            textbox.Name = "txt" + paramname;
            //textbox.Text = "txt" + paramname;

            textbox.Text = defaultValue;
            textbox.TextChanged += new EventHandler(txtParam_TextChanged);
            textbox.TextAlign = HorizontalAlignment.Center;
            this.panelMain.Controls.Add(textbox);
            return textbox.Width;
        }

        private int GenerateLabelParam(string paramname, int locationX)
        {
            Label label = new Label();
            label.Location = new System.Drawing.Point(locationX + 8, 11);
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
            var a = 10;
            _onMenuAction(this, MENU_ACTION.INSERT_BELOW);
        }

        private TableLayoutPanel CreateTableIfCondition()
        {
            TableLayoutPanel tbl = new System.Windows.Forms.TableLayoutPanel();
            tbl.AutoSize = true;
            tbl.ColumnCount = 1;
            tbl.Location = new System.Drawing.Point(0, 0);
            tbl.Name = "tblÌConditionScript";
            //tbl.Size = new System.Drawing.Size(200, 200);
            return tbl;
        }
    }
}
