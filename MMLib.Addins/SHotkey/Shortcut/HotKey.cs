﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SearchingKeyboardShortcut
{
    public class HotKey
    {
        public bool Ctrl {get;set;}

        public bool Shift { get; set; }

        public bool Alt { get; set; }

        public Key Key { get; set; }

        public override string ToString()
        {
            return (Ctrl ? "Ctrl+" : "") + (Shift ? "Shift+" : "") + (Alt ? "Alt+" : "") + Key.ToString();
        }
    }
}