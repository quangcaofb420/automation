
Dim gsLibDir : gsLibDir = ".\"
Dim goFS     : Set goFS = CreateObject("Scripting.FileSystemObject")

' LibraryInclude
ExecuteGlobal goFS.OpenTextFile(goFS.BuildPath(gsLibDir, "ClsSeleniumWebDriver.vbs")).ReadAll()
ExecuteGlobal goFS.OpenTextFile(goFS.BuildPath(gsLibDir, "ClsScript.vbs")).ReadAll()

' WScript.Quit main()
class ClsAutomation

    Public Sub Class_Initialize()
        Set webDriver = new ClsSeleniumWebDriver 
        webDriver.openUrl "https://www.google.com/"
    End Sub
End class

Set automation = New ClsAutomation