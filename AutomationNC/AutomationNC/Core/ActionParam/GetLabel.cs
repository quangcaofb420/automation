using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ActionParam
{
    public class GetLabel
    {
        public SlnControl Control { get; set; }
        public string WithExpression { get; set; }
        public string ToVariable { get; set; }

        public GetLabel(SlnControl control, string withExpression, string toVariable)
        {
            Control = control;
            WithExpression = withExpression;
            ToVariable = toVariable;
        }
    }
}
