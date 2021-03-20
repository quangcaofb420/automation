using Core.Utilities;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Threading;

namespace Core.Models
{
    public class SlnSeleniumWebDriver
    {
        private IWebDriver webDriver;

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

            webDriver = new EdgeDriver(service, options);
        }

        public string OpenWebsite(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            return webDriver.CurrentWindowHandle;
        }
        public void Input(SlnControl control, string text)
        {
            IWebElement element = GetElement(control);
            if (element != null)
            {
                element.SendKeys(text);
            }
        }
        public void Click(SlnControl control)
        {
            IWebElement element = GetElement(control);
            if (element != null)
            {
                element.Click();
            }
        }

        public string GetLabel(SlnControl control)
        {
            string value = "";
            IWebElement element = GetElement(control);
            if (element != null)
            {
                value = element.Text;
            }
            return value ?? "";
        }
         public string GetTextValue(SlnControl control)
        {
            string value = "";
            IWebElement element = GetElement(control);
            if (element != null)
            {
                value = element.GetAttribute("value");
            }
            return value ?? "";
        }

        public void Exit()
        {
            webDriver.Quit();
        }



        private bool CheckElementIsExist(SlnControl control)
        {
            return GetElement(control, 5) != null;
        }

        private IWebElement GetElement(SlnControl control)
        {
            return GetElement(control, 30);
        }
        private IWebElement GetElement(SlnControl control,int timeoutInSecond)
        {
            IWebElement element = null;
            int count = 0;
            while (count < timeoutInSecond)
            {
                count++;
                ReadOnlyCollection<IWebElement> elements = webDriver.FindElements(By.XPath(control.XPath));
                if (elements.Count > 0)
                {
                    element = elements[0];
                    break;
                }
                Thread.Sleep(1000);
            }
            return element;
        }

        
    }
}
