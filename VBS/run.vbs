Dim WshShell, strCurDir
Set WshShell = CreateObject("WScript.Shell")
strCurDir    = WshShell.CurrentDirectory
Set WshShell = Nothing
'Code should be placed in a .vbs file
Set objExcel = CreateObject("Excel.Application")
objExcel.Application.Run "'" & strCurDir & ".\WebDriver_ViewLiveStream.xlsm'!RunScript.run"
objExcel.DisplayAlerts = False
objExcel.Application.Quit
Set objExcel = Nothing