Option Explicit
class ClsSeleniumWebDriver
    Private webDriver As New EdgeDriver


    Public Function openUrl(url As String) As String
        webDriver.start
        webDriver.Get url
        openUrl = ""
    End Function

    Public Function openTab(params As Variant) As String
        Dim url As String
        url = params(1)
    
        Application.SendKeys "^t"
        webDriver.SendKeys "^t"
        webDriver.SwitchToNextWindow 3000
        webDriver.Get url
    
        openTab = ""
    End Function

    Public Function closeTabByTitle(params As Variant)
        Dim t As Integer
        Dim title As String
        title = params(1)
        t = getTabByTitle(title)
        If t > 0 Then
            webDriver.Close
            If webDriver.Windows.Count > 0 Then
                If t = 1 Then ' tab was closed is the first tab so we should move to next tab
                    webDriver.SwitchToNextWindow
                Else
                    webDriver.SwitchToPreviousWindow
                End If
            End If
        End If
    
        closeTabByTitle = ""
    End Function

    Public Function sendInput(control As clsControl, text As String) As String

        Dim element As WebElement
        Set element = getElement(control.xpath)
        Call element.SendKeys(text)
    
        sendInput = ""
    End Function

    Public Function checkControlIsExists(control As clsControl) As Boolean
        Dim element As WebElement
        Dim isExists As Boolean
        isExists = False
        Set element = getElement(control.xpath)
    
        If Not element Is Nothing Then
            isExists = True
        End If
    
        checkControlIsExists = isExists
    End Function

    Public Function exitWeb()
        Dim msg As String
        msg = ""
        webDriver.Close
        exitWeb = msg
    
    End Function

    Public Function redirectUrl(url As String) As String
        webDriver.Get url
        redirectUrl = ""
    End Function

    Public Function getTextboxValue(control As clsControl) As String
        Dim content As String
        Dim element As WebElement
        Set element = getElement(control.xpath)
        Dim c As Integer
        c = 0
    
        content = element.value
    
        Do While StrComp(content, "") = 0 And c < 5
            Call Wait(1)
            c = c + 1
            content = element.value
        Loop
    
        getTextboxValue = content
    End Function

    Public Function getText(control As clsControl) As String
        Dim content As String
        Dim element As WebElement
        Set element = getElement(control.xpath)
        Dim c As Integer
        c = 0
    
        content = element.text
    
        Do While StrComp(content, "") = 0 And c < 5
            Call Wait(1)
            c = c + 1
            content = element.text
        Loop
    
        getText = content
    End Function

    Public Function click(control As clsControl) As String
        Dim msg As String
        Dim element As WebElement
        msg = ""

        Set element = getElement(control.xpath)
        Call element.click
    
        click = msg
    End Function

    Public Function validateControl(control As clsControl) As String
        Dim msg As String
        Dim element As WebElement
    
        msg = ""
    
        Set element = getElement(control.xpath)
        If element Is Nothing Then
            msg = "Cannot find control " & control.Name
        End If
   
        validateControl = msg
    End Function


    Private Function getElement(xpath As String) As WebElement
        Set getElement = findElement(xpath, 20)
    End Function

    Private Function findElement(xpath As String, timeOutInSecond As Integer) As WebElement
        Dim element As WebElement
        Dim i As Integer
        i = 0
    
        Do While i < timeOutInSecond
            If webDriver.FindElementsByXPath(xpath).Count > 0 Then
                Set element = webDriver.FindElementsByXPath(xpath).First
                Exit Do
            End If
            Wait (1)
            i = i + 1
            DoEvents
        Loop
        Set findElement = element
    End Function

    Public Sub Wait(second As Integer)
        Call BusinessUtils.Sleep(second)
    End Sub

    Private Function getTabByTitle(title As String) As Integer
        Dim t As Integer
        Dim tsCount As Integer
        Dim i As Integer
        Dim wTitle As String
        t = 0
        tsCount = webDriver.Windows.Count
        For i = 1 To tsCount
            wTitle = webDriver.Windows.Item(i).title
            If InStr(LCase(wTitle), LCase(title)) > 0 Then
                t = i
                Exit For
            End If
        Next
        getTabByTitle = t
    End Function
End class