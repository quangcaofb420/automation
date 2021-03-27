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
        public async void Input(SlnControl control, string text)
        {
            IWebElement element = await GetElement(control);
            if (element != null)
            {
                element.SendKeys(text);
            }
        }
        public async void Click(SlnControl control)
        {
            IWebElement element = await GetElement(control);
            if (element != null)
            {
                element.Click();
            }
        }

        public async Task<string> GetLabel(SlnControl control)
        {
            string value = "";
            IWebElement element = await GetElement(control);
            if (element != null)
            {
                value = element.Text;
            }
            return value ?? "";
        }
        public async Task<string> GetTextValue(SlnControl control)
        {
            string value = "";
            IWebElement element = await GetElement(control);
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

        }



        private async Task<bool> CheckElementIsExist(SlnControl control)
        {
            IWebElement element = await GetElement(control, 5);
            return element != null;
        }

        private Task<IWebElement> GetElement(SlnControl control)
        {
            return GetElement(control, 30);
        }
        private async Task<IWebElement> GetElement(SlnControl control, int timeoutInSecond)
        {
            IWebElement element = null;
            int count = 0;
            while (count < timeoutInSecond)
            {
                count++;
                ReadOnlyCollection<IWebElement> elements = _webDriver.FindElements(By.XPath(control.XPath));
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
