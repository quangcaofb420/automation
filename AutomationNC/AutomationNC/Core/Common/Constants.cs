
using System.ComponentModel;

namespace Core.Common
{
    class Constants
    {

    }
    public enum ACTION
    {
        [Description("OpenWebsite")]
        OpenWebsite,

        [Description("Input")]
        Input,

        [Description("Click")]
        Click,

        [Description("IfCondition")]
        IfCondition,
        
        [Description("Condition")]
        Condition,

        [Description("GetLabel")]
        GetLabel,

        [Description("GetTextValue")]
        GetTextValue,

        [Description("RedirectUrl")]
        RedirectUrl,

        [Description("Exit")]
        Exit,

        [Description("Sleep")]
        Sleep,

        [Description("LoopJsonFile")]
        LoopJsonFile

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
