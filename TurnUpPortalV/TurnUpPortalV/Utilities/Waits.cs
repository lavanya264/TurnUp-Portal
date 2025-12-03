using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TurnUpPortalV.Utilities

{
    public class Waits
    {
        public static void WaitTobeClickable(IWebDriver driver, String Locatortype, String LocatorValue, int Seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
            if (Locatortype == "ClassName")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(LocatorValue)));
            }
            if (Locatortype == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(LocatorValue)));
            }
        }

        internal static void WaitTobeClicable(IWebDriver driver, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}