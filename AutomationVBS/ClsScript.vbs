
class Script
    Public Sub Class_Initialize()
        Set driver = CreateObject("Selenium.EdgeDriver")
        driver.Start "", ""
        driver.Get "https://www.google.com/"
    End Sub
End class

