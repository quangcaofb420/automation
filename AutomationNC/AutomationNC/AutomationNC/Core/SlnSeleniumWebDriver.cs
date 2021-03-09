using AutomationNC.Core.Utilities;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;

namespace AutomationNC.Core
{
    class SlnSeleniumWebDriver
    {
        private IWebDriver webDriver;

        public SlnSeleniumWebDriver()
        {
            var service = EdgeDriverService.CreateDefaultService(SeleniumUtils.GetWebDriverExecutePath(), "edgedriver.exe");
            service.HideCommandPromptWindow = true;
            EdgeOptions options = new EdgeOptions();
            options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            //  options.UseChromium = true;
            options.AddArgument("-inprivate");
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
   
            webDriver = new EdgeDriver(service, options);
        }

        public void OpenWebsite(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public void Exit()
        {
            webDriver.Quit();
        }
    }
}
