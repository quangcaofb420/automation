# Manager App
 - Run `buildManagerAppNC.bat` to build app
 - Run Automation
    - Copy files to specify Facebook account folder like `./{Facebook Account}/`
        - `run.vbs`
        - `WebDriver_ViewLiveStream.xlsm`
        - Generate `fbacc.json` file with Facebook account info
        
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
## Config msedgedriver
 - Check Edge version in Edge 3 dots >> Settings >> About Microsoft Edge  
 - Goto this link to download msedgedriverhttps://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
    + Copy to 
        - C:\Program Files\SeleniumBasic 
        - C:\Users\\%username%\AppData\Local\SeleniumBasic
 - In VBA develop, Visual Basic window, goto Tool >> References >> check Selenium Type Library
 - Check by code
    ```
    Sub Test()
        Dim webDriver As New EdgeDriver
        
        webDriver.Start
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

# Run Automation
## Run macro outside Excel file without opening file
 - Open Excel file, Menu Files >> Options >> Trust Center >> Trust Center Settings ... 
    - Trusted Locations : Add Automation folder
    - Macro Settings : Enable all macros ... AND check Trust access the VBA project object model

# Git SourceTree and Excel VBA
## Git XL 
- Install https://www.xltrail.com/git-xl

## SourceTree
- Open file C:\\{User}\\AppData\Local\Atlassian\SourceTree\git_local\etc\gitconfig
    ```
    [diff "xl"]
	    command = git-xl-diff.exe
    [merge "xl"]
	    name = xl merge driver for Excel workbooks
	    driver = git-xl-merge.exe %P %O %A %B
    ```

    + We can add it into local git
- Open file C:\\{User}\\AppData\Local\Atlassian\SourceTree\git_local\etc\gitattributes
    ```
    *.xla diff=xl
    *.xla merge=xl
    *.xlam diff=xl
    *.xlam merge=xl
    *.xls diff=xl
    *.xls merge=xl
    *.xlsb diff=xl
    *.xlsb merge=xl
    *.xlsm diff=xl
    *.xlsm merge=xl
    *.xlsx diff=xl
    *.xlsx merge=xl
    *.xlt diff=xl
    *.xlt merge=xl
    *.xltm diff=xl
    *.xltm merge=xl
    *.xltx diff=xl
    *.xltx merge=xl
    ```