using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchingKeyboardShortcut
{
    public partial class KeyboardShortcutFrm : Form
    {
        private EnvDTE80.DTE2 _applicationObject;
        private ShortcutHelper _shortcutHelper;
        private HotKeyEditorHelper _hotkeyEditor;

        public KeyboardShortcutFrm()
        {
            InitializeComponent();
            _hotkeyEditor = new HotKeyEditorHelper();
        }

        public void ShowCommands(ShortcutHelper shortcutHelper, EnvDTE80.DTE2 applicationObject)
        {
            _applicationObject = applicationObject;
            _shortcutHelper = shortcutHelper;
            gvCommands.AutoGenerateColumns = false;
            this.gvCommands.DataSource = _shortcutHelper.GetVSCommands();
            Refresh();
            SearchTypeInfo();
            this.ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            TryClose(e);
            NavigateInGrid(e);
            
        }

        private void NavigateInGrid(KeyEventArgs e)
        {
            if (gvCommands.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Down && gvCommands.CurrentRow.Index < gvCommands.Rows.Count - 1)
                {
                    gvCommands.CurrentCell = gvCommands.Rows[gvCommands.CurrentRow.Index + 1].Cells[0];
                }
                else if (e.KeyCode == Keys.Up && gvCommands.CurrentRow.Index > 0)
                {
                    gvCommands.CurrentCell = gvCommands.Rows[gvCommands.CurrentRow.Index - 1].Cells[0];
                } 
            }
        }

        private void KeyboardShortcutFrm_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                this.gvCommands.DataSource = _shortcutHelper.GetVSCommands();
            }
            else
            {
                if (btnSearchType.Checked)
                {
                    this.gvCommands.DataSource = _shortcutHelper.GetCommandsByShortcut(txtSearch.Text);
                }
                else
                {
                    this.gvCommands.DataSource = _shortcutHelper.GetCommandsByName(txtSearch.Text); 
                }
            }
        }

        private void Refresh()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                this.lblCount.Text = string.Format("Count {0}", _shortcutHelper.CommandCount());
            }
            else
            {
                this.lblCount.Text = string.Format("Count {0} / {1}", gvCommands.Rows.Count, _shortcutHelper.CommandCount());
            }

            if (gvCommands.CurrentRow != null)
            {
                lblInfo.Text = (gvCommands.DataSource as IList<VSCommand>)[gvCommands.CurrentRow.Index].ToString();
            }
        }

        private void gvCommands_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Refresh();
        }

        private void btnSearchType_Click(object sender, EventArgs e)
        {
            btnSearchType.Checked = !btnSearchType.Checked;
            SearchTypeInfo();
            this.txtSearch.Text = string.Empty;
        }

        private void SearchTypeInfo()
        {
            if (btnSearchType.Checked)
            {
                btnSearchType.Text = "Search by shortcut";
                btnSearchType.Image = Properties.Resources.KeyList;
                btnSearchType.ToolTipText = "Switch to search by name";
                _hotkeyEditor.Attach(txtSearch);
            }
            else
            {
                btnSearchType.Text = "Search by name";
                btnSearchType.Image = Properties.Resources.List;
                btnSearchType.ToolTipText = "Switch to search by shortcut";
                _hotkeyEditor.Detach(txtSearch);
            }
        }

        private void gvCommands_KeyDown(object sender, KeyEventArgs e)
        {
            TryClose(e);
            txtSearch.Focus();
            txtSearch.Text = e.KeyCode.ToString();
            txtSearch.SelectionStart = 1;
            txtSearch.SelectionLength = 0;
        }

        private void KeyboardShortcutFrm_KeyDown(object sender, KeyEventArgs e)
        {
            TryClose(e);
        }

        private void TryClose(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            _applicationObject.ExecuteCommand("Tools.CustomizeKeyboard");
        }
    }
}
