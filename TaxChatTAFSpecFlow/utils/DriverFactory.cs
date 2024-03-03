using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using TaxChatTAF;
using TaxChatTAFSpecFlow.utils;

namespace BDDSelenium.driver
{
    public class DriverFactory
    {

        private static InternetExplorerOptions IEOptions()
        {
            var options = new InternetExplorerOptions()
            {
                EnableNativeEvents = false,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true
            };
            return options;
        }

        public static RemoteWebDriver CreateDriver(String browser)
        {
            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    return new ChromeDriver(Utilities.getRelativePathRoute(configConstants.ROUTE_DRIVER_BROWSER), options);                    
                case "FIREFOX":                    
                    /*FirefoxOptions optionsFirefox = new FirefoxOptions();
                    optionsFirefox.AddAdditionalCapability("useAutomationExtension", false);*/
                    //optionsFirefox.Capabilities("useAutomationExtension", false);
                    return new FirefoxDriver(Utilities.getRelativePathRoute(configConstants.ROUTE_DRIVER_BROWSER));
                case "IE":
                    return new InternetExplorerDriver(IEOptions());
                case "EDGE":
                    EdgeOptions optionsChromium = new EdgeOptions();
                    optionsChromium.AddAdditionalCapability("useAutomationExtension", false);                    
                    return new EdgeDriver(Utilities.getRelativePathRoute(configConstants.ROUTE_DRIVER_BROWSER), optionsChromium);
                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }

    }
}
