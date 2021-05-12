using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SlnSeleniumWebDriver
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;
        private bool _isDriverClose = false;
        private string _driverFolder = "";

        public SlnSeleniumWebDriver(string workingFolder)
        {
            _driverFolder = workingFolder == "" ? SeleniumUtils.GetWebDriverExecutePath() : workingFolder;

            InitDriver();
        }

        private void InitDriver()
        {
            var service = OpenQA.Selenium.Edge.EdgeDriverService.CreateDefaultService(_driverFolder, "msedgedriver.exe");

            service.HideCommandPromptWindow = true;
            OpenQA.Selenium.Edge.EdgeOptions options = new OpenQA.Selenium.Edge.EdgeOptions();

            options.UseChromium = true;
            //options.AddArgument("headless");
            //options.AddArgument("disable-gpu");
            options.AddArgument("-inprivate");
            _webDriver = new OpenQA.Selenium.Edge.EdgeDriver(service, options);
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        }

        public string OpenWebsite(string url)
        {
            if (_isDriverClose)
            {
                InitDriver();
            }
            _webDriver.Navigate().GoToUrl(url);
            return _webDriver.CurrentWindowHandle;
        } 
        public string OpenNewTab(string url)
        {
            string currentTabHandle = _webDriver.CurrentWindowHandle;
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(string.Format("window.open('{0}', '_blank');", url));
            ReadOnlyCollection<string> tabHandles = _webDriver.WindowHandles;
            int currentTabIndex = tabHandles.IndexOf(currentTabHandle);
            if (currentTabIndex < tabHandles.Count - 1)
            {
                _webDriver.SwitchTo().Window(_webDriver.WindowHandles[currentTabIndex + 1]);
            }
           
            return _webDriver.CurrentWindowHandle;
        }

        public void CloseTab()
        {
            string currentTabHandle = _webDriver.CurrentWindowHandle;
            ReadOnlyCollection<string> tabHandles = _webDriver.WindowHandles;
            int currentTabIndex = tabHandles.IndexOf(currentTabHandle);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.close();");
            tabHandles = _webDriver.WindowHandles;
            if (tabHandles.Count > 0)
            {
                if (currentTabIndex == 0)
                {
                    _webDriver.SwitchTo().Window(tabHandles[0]);
                }
                else
                {
                    _webDriver.SwitchTo().Window(tabHandles[currentTabIndex - 1]);
                }
            }

        }
        public void CloseTabByTitle(string title)
        {
            if (title == null || title == "")
            {
                CloseTab();
                return;
            }

            string currentTabHandle = _webDriver.CurrentWindowHandle;
            ReadOnlyCollection<string> tabHandles = _webDriver.WindowHandles;
            int currentTabIndex = tabHandles.IndexOf(currentTabHandle);
            bool isExsts = false;
            for (int i = tabHandles.Count - 1; i >= 0; i--)
            {
                _webDriver.SwitchTo().Window(tabHandles[i]);
                string pageTitle = _webDriver.Title;
                if (pageTitle.ToLower().Contains(title.ToLower())) 
                {
                    CloseTab();
                    tabHandles = _webDriver.WindowHandles;
                    if (currentTabIndex == i)
                    {
                        if (tabHandles.Count > 0)
                        {
                            if (i == 0)
                            {
                                _webDriver.SwitchTo().Window(tabHandles[0]);
                            }
                            else
                            {
                                _webDriver.SwitchTo().Window(tabHandles[i - 1]);
                            }
                        }
                    }
                    else 
                    {
                        _webDriver.SwitchTo().Window(currentTabHandle);
                    }
                    isExsts = true;
                    break;
                }


            }
            if (!isExsts)
            {
                _webDriver.SwitchTo().Window(currentTabHandle);
            }

        }

        public async void Input(string xpath, string text)
        {
            IWebElement element = await GetElement(xpath);
            if (element != null)
            {
                element.SendKeys(text);
            }
        }
        public async void Click(string xpath)
        {
            IWebElement element = await GetElement(xpath);
            if (element != null)
            {
                element.Click();
            }
        }

        public async Task<string> GetLabel(string xpath)
        {
            string value = "";
            IWebElement element = await GetElement(xpath);
            if (element != null)
            {
                value = element.Text;
            }
            return value ?? "";
        }
        public async Task<string> GetTextValue(string xpath)
        {
            string value = "";
            IWebElement element = await GetElement(xpath);
            if (element != null)
            {
                value = element.GetAttribute("value");
            }
            return value ?? "";
        }

        public void Close()
        {
            if (_webDriver != null)
            {
                _webDriver.Close();
            }
        }  
      
        public void Exit()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
                _isDriverClose = true;
            }
        }
        public void Sleep(int second)
        {
            Thread.Sleep(second * 1000);
        }
        private async Task<bool> CheckElementIsExist(string xpath)
        {
            IWebElement element = await GetElement(xpath, 5);
            return element != null;
        }

        private Task<IWebElement> GetElement(string xpath)
        {
            return GetElement(xpath, 30);
        }

        private async Task<IWebElement> GetElement(string xpath, int timeoutInSecond)
        {
            IWebElement element = null;
            element = _wait.Until(e => e.FindElement(By.XPath(xpath)));
            //int count = 0;
            //while (count < timeoutInSecond)
            //{
            //    count++;
            //    ReadOnlyCollection<IWebElement> elements = _webDriver.FindElements(By.XPath(xpath));
            //    if (elements.Count > 0)
            //    {
            //        element = elements[0];
            //        break;
            //    }
            //    await CommonUtils.Sleep(1000);
            //}
            return element;
        }


    }
}
