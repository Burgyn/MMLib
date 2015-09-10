using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchingKeyboardShortcut
{
    public class HotKeyEditorHelper
    {
        private HotKey _lastKey;
        private HashSet<Keys> _ignoredKeys = new HashSet<Keys>() { Keys.Control, Keys.ControlKey, Keys.LControlKey, Keys.RControlKey, Keys.Alt, Keys.Shift, Keys.ShiftKey, Keys.RShiftKey, Keys.LShiftKey };

        public void Attach(TextBox textBox)
        {
            textBox.ShortcutsEnabled = false;
            textBox.KeyDown += textBox_KeyDown;
        }

        public void Detach(TextBox textBox)
        {
            textBox.ShortcutsEnabled = true;
            textBox.KeyDown -= textBox_KeyDown;
        }

        void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;

            if (!_ignoredKeys.Contains(e.KeyCode) && (e.KeyCode.ToString() != "Menu"))
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && (_lastKey == null))
                {
                    textBox.Text = string.Empty;
                }
                else
                {
                    var hotKey = new HotKey() { Ctrl = e.Control, Alt = e.Alt, Shift = e.Shift, Key = e.KeyCode };
                    Application.DoEvents();
                    textBox.Text = string.Format("{0}{1}{2}", _lastKey != null ? _lastKey.ToString() : string.Empty, 
                        string.IsNullOrWhiteSpace(textBox.Text) ? string.Empty : ", ", hotKey);
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.SelectionLength = 0;
                    if (_lastKey == null)
                    {
                        _lastKey = hotKey;
                    }
                    else
                    {
                        _lastKey = null;
                    }
                }
            }
        }


    }
}
