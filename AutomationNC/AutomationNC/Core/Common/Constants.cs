
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
        SLEEP,

        [Description("LoopJsonFile")]
        LOOP_JSON_FILE

    }
    public enum FILE_ACTION
    {
        CONTROLS,
        SENARIOR,
        FB_ACTIONS
    } 
    public enum FB_ACTION_HANDLE
    {
        SIMPLE,
        LOOP_FB_ACC,
        MIXED_LOOP_FB_ACC,
        WATCH_VIDEO_STREAM
    }

    public enum OS
    {
        Windows,
        Mac,
        Linux
    }
}
