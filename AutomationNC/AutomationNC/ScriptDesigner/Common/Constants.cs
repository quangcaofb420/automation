using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScriptDesigner.Common
{
    public enum MENU_ACTION
    {
        [Description("InsertAbove")]
        INSERT_ABOVE,

        [Description("Delete")]
        DELETE,

        [Description("In")]
        INSERT_BELOW
    }
}
