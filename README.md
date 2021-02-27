# Selenium
## Config chromedriver
 - Check Chrome version in Chrome 3 dots >> Help >> About Google Chrome 
 - Goto this link to download chromedriver https://chromedriver.chromium.org/downloads
    + Copy to 
        - C:\Program Files\SeleniumBasic 
        - C:\Users\\%username%\AppData\Local\SeleniumBasic
 - In VBA develop, Visual Basic window, goto Tool >> References >> check Selenium Type Library
 - Check by code
    ```
    Sub Test()
        Dim webDriver As New WebDriver
        
        webDriver.Start "chrome", ""
        webDriver.Get "https://www.google.com"
        Stop
    End Sub
    ```

# Excel
## Update Actions and Controls
- On the Ribbon, go to Formulas tab, and tap or click on Name Manager in the Defined Names group. We can update the range of list
## 

# VBA
## Read JSON file
 - Follow the link https://github.com/VBA-tools/VBA-JSON
 - https://github.com/VBA-tools/VBA-Dictionary