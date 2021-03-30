
using System.ComponentModel;

namespace Core.Common
{
    class Constants
    {

    }
    public enum ACTION
    {
        [Description("OpenWebsite")]
        OPEN_WEBSITE,

        [Description("Input")]
        INPUT,

        [Description("Click")]
        CLICK,

        [Description("IfCondition")]
        IF_CONDITION,
        
        [Description("Condition")]
        CONDITION,

        [Description("GetLabel")]
        GET_LABEL,

        [Description("GetTextValue")]
        GET_TEXT_VALUE,

        [Description("RedirectUrl")]
        REDIRECT_URL,

        [Description("Exit")]
        EXIT,

        [Description("Sleep")]
        SLEEP
    }
    public enum FB_ACTION_TYPE
    {
        VIEW_LIVESTREAM,
        AUTO_CREATE_POST_LIKE
    }

    public enum OS
    {
        Windows,
        Mac,
        Linux
    }
}
