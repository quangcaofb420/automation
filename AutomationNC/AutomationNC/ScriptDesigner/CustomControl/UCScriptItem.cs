using Core.Models;
using Core.Utilities;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Core.ActionParam;
using System.Collections.Generic;
using Core.Common;

namespace ScriptDesigner.CustomControl
{
    public partial class UCScriptItem : UserControl
    {
        private SlnScript _script;
        private SlnScript _scriptBk;
        private int _levelIndex;
        private string Id { get; set; }
        public TableLayoutPanel _parent;
        private List<SlnControl> _mappingControls;
        private Func<List<SlnControl>> _getMappingControlsFunc;
        private TableLayoutPanel tbl;
        public UCScriptItem(TableLayoutPanel parent, SlnScript script, int levelIndex, List<SlnControl> mappingControls, Func<List<SlnControl>> getMappingControlsFunc )
        {
            this.Id = script.Id;
            this._parent = parent;
            this._script = script;
            this._scriptBk =  script.To<SlnScript>();
            this._levelIndex = levelIndex;
            this._mappingControls = mappingControls;
            this._getMappingControlsFunc = getMappingControlsFunc;
            
            InitializeComponent();
            InitUI();
            LoadScript();
        }

        private void InitUI()
        {
            this.cbbControl.DataSource = _mappingControls.Select(c => c.Name).ToList();
            this.cbbControl.SelectedIndex = -1;

            int indent = 20;
            this.panelMain.Location = new Point(this.Location.X + indent, this.Location.Y);
            this.panelMain.Width = this.panelMain.Width - indent;

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
            if (_scriptBk.Action != action.ToDescriptionString())
            {
                _script.Action = action.ToDescriptionString();
                _script.InitParam();
            }
            else
            {
                _script = _scriptBk.To<SlnScript>();
            }
            
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            if (definedAction == null)
            {
                return;
            }

            CreateContextMenuAction(action);
            GenerateUIScript();
        }

        private void GenerateUIScript()
        {
            Core.Common.ACTION action = (Core.Common.ACTION)this.cbbAction.SelectedItem;
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            bool requiredElement = definedAction.RequiredElement;
            bool canChange = action.CanChange();
            this.cbbAction.Enabled = canChange;
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
                string[] prs = ClassUtils.GetPropertyNames(paramType)
                    .Where(pr => requiredElement == false || pr != "Control")
                    .Where(pr => !canChange || pr != "Actions")
                    .Where(pr => canChange || pr != "Actions" || action != ACTION.Condition)
                    .Where(pr => !pr.EndsWith("_T"))
                    .ToArray();
                int x = this.cbbAction.Location.X + this.cbbAction.Width + (requiredElement ? this.cbbControl.Width : 0) + 10;
                
                for (int i = 0; i < prs.Length; i++)
                {
                    string pr = prs[i];
                    String pt = _script.GetParamType(pr);
                    string defaultValue = (ClassUtils.GetProppertyValue(paramType, _script.Param, pr) ?? "").ToString();

                    x += GenerateLabelParam(pr, x);
                    if (pt == "String")
                    {
                        x += GenerateTextboxParam(pr, x, defaultValue);
                    }
                    else if (pt.Contains("[") && pt.Contains("]"))
                    {
                        string[] list = pt.Replace("[", "").Replace("]", "").Split(",");
                        x += GenerateComobBoxParam(pr, x, list, defaultValue);
                    }
                    x += 10;
                }
            }

            if (action.HasChildrenActions())
            {
                this.AutoSize = true;
                this.panelMain.AutoSize = true;
                tbl = CreateTable();
                List<SlnScript> childrenActions = _script.GetChildrenActions();

                for (int i = 0; i < childrenActions.Count; i++)
                {
                    SlnScript child = childrenActions[i];
                    UCScriptItem childUI = new UCScriptItem(tbl, child, _levelIndex + 1, _mappingControls, _getMappingControlsFunc);
                    tbl.RowCount += 1;
                    tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tbl.Controls.Add(childUI, 0, tbl.RowCount - 1);
                }
                this.panelMain.Controls.Add(tbl);
            }

            this.panelMain.Refresh();
            this.Refresh();
        }

        public SlnScript GetScript()
        {
            ACTION action = GetSelectedAction();
            SlnAction definedAction = ScriptUtils.GetDefinedAction(action);
            Type paramType = definedAction.ParamType;
            String selectedControl = null ;
            bool requiredElement = definedAction.RequiredElement;
            List<SlnScript> childrenActions = new List<SlnScript>();
            if (action.HasChildrenActions())
            {
                TableLayoutPanel tbl = this.panelMain.Controls[this.panelMain.Controls.Count - 1] as TableLayoutPanel;
                for (int i = 0; i < tbl.Controls.Count; i++)
                {
                    UCScriptItem childActionUI = tbl.Controls[i] as UCScriptItem;
                    SlnScript childAction = childActionUI.GetScript();
                    childrenActions.Add(childAction);
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
                Control[] txts = this.panelMain.Controls.Find("txt" + pr, false);
                if (txts != null && txts.Length > 0)
                {
                    TextBox textBox = (TextBox)txts[0];
                    string value = textBox.Text;
                    args.Add(value);
                }
                Control[] cbbs = this.panelMain.Controls.Find("cbb" + pr, false);
                if (cbbs != null && cbbs.Length > 0)
                {
                    ComboBox cbb = (ComboBox)cbbs[0];
                    string value = cbb.SelectedItem.ToString();
                    args.Add(value);
                }
            }


            if (action.HasChildrenActions())
            {
                // add list of script actions
                args.Add(childrenActions);
            }

            object instanceArg = ClassUtils.Constructor(paramType, args.ToArray());
            object res = ClassUtils.CallStaticFunction(typeof(SlnScript), paramType.Name, requiredElement ? new[] {selectedControl, instanceArg } : new[] { instanceArg });
            SlnScript script = res as SlnScript;
            script.Id = Id;

            return script;
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
        private int GenerateComobBoxParam(string paramname, int locationX, string[] list, string defaultValue)
        {
            ComboBox control = new ComboBox();
            control.Location = new System.Drawing.Point(locationX + 12, 1);
            control.Name = "cbb" + paramname;
            control.Items.Clear();
            control.Items.AddRange(list);
            control.DropDownStyle = ComboBoxStyle.DropDownList;
            //textbox.Text = "txt" + paramname;
            //textbox.Width = 300;
            if (defaultValue != "")
            {
                control.Text = defaultValue;
            }
            else {
                control.SelectedIndex = 0;
            }
            //control.MouseHover += new EventHandler(txtParam_MouseHover);
            //textbox.TextAlign = HorizontalAlignment.Center;
            this.panelMain.Controls.Add(control);
            return control.Width;
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
      
        private TableLayoutPanel CreateTable()
        {
            TableLayoutPanel tblC = new System.Windows.Forms.TableLayoutPanel();
            tblC.BackColor = Color.FromArgb(40, new Random().Next(100, 240), new Random().Next(100, 240), new Random().Next(100, 240));
            tblC.Controls.Clear();
            tblC.AutoSize = true;
            tblC.RowCount = 0;
            tblC.ColumnCount = 1;
            tblC.Location = new System.Drawing.Point(0, 30);
            tblC.Height = 0;
            tblC.Name = "TableLayoutPanel";
            tblC.RowStyles.Clear();   //now you have zero rowstyles
            return tblC;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            cmtAction.Show(PointToScreen(((Button)sender).Location));
        }

        private void cmtAction_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            List<UCScriptItem> controls = new List<UCScriptItem>();
            int rowIndex = -1;
            for (int i = 0; i < _parent.Controls.Count; i++)
            {
                UCScriptItem c = _parent.Controls[i] as UCScriptItem;
                if(c != null)
                {
                    controls.Add(c);
                    if (c.Id == this.Id)
                    {
                        rowIndex = i;
                    }
                }
            }
            TableLayoutPanelCellPosition cellPosition = _parent.GetPositionFromControl(this);

            if (e.ClickedItem.Name == MNU_InsertAbove || e.ClickedItem.Name == MNU_InsertBelow)
            {
                rowIndex += e.ClickedItem.Name == MNU_InsertBelow ? 1 : 0;
                if (rowIndex == -1)
                {
                    rowIndex = 0;
                }
                
                UCScriptItem script = new UCScriptItem(_parent, SlnScript.Sleep(new Sleep(10)), _levelIndex, _mappingControls, _getMappingControlsFunc);
               
                controls.Insert(rowIndex, script);
               
            }
            else if (e.ClickedItem.Name == MNU_InsertConditionAbove || e.ClickedItem.Name == MNU_InsertConditionBelow)
            {
                rowIndex += e.ClickedItem.Name == MNU_InsertConditionBelow ? 1 : 0;
                if (rowIndex == -1)
                {
                    rowIndex = 0;
                }
                
                UCScriptItem script = new UCScriptItem(_parent, SlnScript.Condition(
                        (Condition)SlnAction.Condition.DefaultParam
                    ), _levelIndex, _mappingControls, _getMappingControlsFunc);
               
                controls.Insert(rowIndex, script);
               
            }
            else if (e.ClickedItem.Name == MNU_Delete)
            {
                controls.RemoveAt(rowIndex);
            }
            else if (e.ClickedItem.Name == MNU_InsertConditionBelow)
            {
                var ccccca = 10;
            }

            _parent.SuspendLayout();
            _parent.RowCount = 0;
            _parent.Controls.Clear();
            _parent.RowStyles.Clear();
            
            for (int i = 0; i < controls.Count; i++)
            {
                Control c = controls[i];
                _parent.RowCount += 1;
                _parent.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                _parent.Controls.Add(c, 0, _parent.RowCount - 1);
            }
            _parent.ResumeLayout();
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
            if (action == ACTION.Condition)
            {
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = MNU_InsertConditionAbove, Text = "Insert Condition Above", ToolTipText = action.ToDescriptionString() });
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = MNU_InsertConditionBelow, Text = "Insert Condition Below", ToolTipText = action.ToDescriptionString() });
            }
            else if (action == ACTION.IfCondition)
            {
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = MNU_InsertCondition, Text = "Insert Condition", ToolTipText = action.ToDescriptionString() });
            }

            if (action != ACTION.Condition)
            {
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = MNU_InsertAbove, Text = "Insert Above", ToolTipText = action.ToDescriptionString() });
                this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = MNU_InsertBelow, Text = "Insert Below", ToolTipText = action.ToDescriptionString() });
            }

            this.cmtAction.Items.Add(new ToolStripMenuItem() { Name = MNU_Delete, Text = "DELETE", BackColor = Color.Red, ForeColor = Color.White, ToolTipText = action.ToDescriptionString() });
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

        private static readonly string MNU_InsertConditionAbove = "InsertConditionAbove";
        private static readonly string MNU_InsertConditionBelow = "InsertConditionBelow";
        private static readonly string MNU_InsertCondition = "InsertCondition";
        private static readonly string MNU_InsertAbove = "InsertAbove";
        private static readonly string MNU_InsertBelow = "InsertBelow";
        private static readonly string MNU_Delete = "Delete";
    }
    
}
