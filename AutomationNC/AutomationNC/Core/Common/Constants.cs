﻿
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

        [Description("Close")]
        Close,

        [Description("CloseTab")]
        CloseTab,

        [Description("CloseTabByTitle")]
        CloseTabByTitle,

        [Description("Sleep")]
        Sleep,

        [Description("LoopJsonFile")]
        LoopJsonFile,
        
        [Description("LoopApiData")]
        LoopApiData,

        [Description("OpenNewTab")]
        OpenNewTab

    }
    public enum FILE_ACTION
    {
        CONTROLS,
        SENARIOR,
        FB_ACTIONS
    } 
    public enum FB_ACTION_HANDLE
    {
        SIMPLE
    }

    public enum OS
    {
        Windows,
        Mac,
        Linux
    }

    public enum FILE
    {
        [Description("msedgedriver.exe")]
        MSEdgeDriverExe,
    }

    public enum THREAD_MODE
    {
        None,
        Multi
    }
}
