using Core.Utilities;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SlnSeleniumWebDriver
    {
        private IWebDriver _webDriver;

        public SlnSeleniumWebDriver()
        {
            var service = EdgeDriverService.CreateDefaultService(SeleniumUtils.GetWebDriverExecutePath(), "msedgedriver.exe");
            service.HideCommandPromptWindow = true;
            EdgeOptions options = new EdgeOptions();
            options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            //  options.UseChromium = true;
            options.AddArgument("-inprivate");
            //options.AddArgument("headless");
            //options.AddArgument("disable-gpu");

            _webDriver = new EdgeDriver(service, options);
        }

        public string OpenWebsite(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            return _webDriver.CurrentWindowHandle;
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

        public void Exit()
        {
            _webDriver.Quit();
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
            int count = 0;
            while (count < timeoutInSecond)
            {
                count++;
                ReadOnlyCollection<IWebElement> elements = _webDriver.FindElements(By.XPath(xpath));
                if (elements.Count > 0)
                {
                    element = elements[0];
                    break;
                }
                await CommonUtils.Sleep(1000);
            }
            return element;
        }


    }
}
