using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ActionParam
{
    public class Input
    {
        public SlnControl Control { get; set; }
        public string Text { get; set; }

        public Input(SlnControl control, string text)
        {
            Control = control;
            Text = text;
        }
    }
}
