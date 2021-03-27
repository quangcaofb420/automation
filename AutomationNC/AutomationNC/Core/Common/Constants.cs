
using System.ComponentModel;

namespace Core.Common
{
    class Constants
    {

    }
    public enum ACTION
    {
        [Description("OpenWebsite")]
        OPEN_WEBSITE = 0,

        [Description("Input")]
        INPUT = 1,

        [Description("Click")]
        CLICK = 2,

        [Description("IfCondition")]
        IF_CONDITION = 3,

        [Description("GetLabel")]
        GET_LABEL = 4,

        [Description("GetTextValue")]
        GET_TEXT_VALUE = 5,

        [Description("RedirectUrl")]
        REDIRECT_URL = 6,

        [Description("Exit")]
        EXIT = 7,

        [Description("Sleep")]
        SLEEP = 8
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
