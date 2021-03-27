using Core.Models;
using Core.Utilities;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace ScriptDesigner.CútomControl
{
    public partial class UCScriptItem : UserControl
    {
        private SlnScript _script;
        private int _index;
        private int _levelIndex;
        public UCScriptItem(SlnScript script, int index, int levelIndex)
        {
            this._script = script;
            this._index = index;
            this._levelIndex = levelIndex;
            InitializeComponent();
            InitUI();
            int indent = 40;
            this.panelMain.BackColor = index % 2 == 0 ? Color.FromArgb(180, 217, 255) : Color.FromArgb(223, 237, 251);
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
            cbbAction.DataSource = Enum.GetValues(typeof(Core.Common.ACTION));
        }

        private void LoadScript()
        {
            SlnAction action = _script.Action;
            this.cbbAction.SelectedItem = action.Name;
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

            bool requiredElement = definedAction.RequiredElement;
            this.cbbControl.Visible = requiredElement;

            Type paramType = definedAction.ParamType;
            if (paramType != null)
            {
                string[] prs = ClassUtils.GetPropertyNames(paramType).Where(pr => requiredElement == false || pr != "Control").ToArray();
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
            string[] acceptedControls = new string[] { "cbbAction", "cbbControl", "btnAction" };
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
        }
    }
}
