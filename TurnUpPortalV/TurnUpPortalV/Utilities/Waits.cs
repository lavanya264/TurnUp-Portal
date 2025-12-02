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
        public static void WaitTobeClicable(IWebDriver driver,String Locatortype, String LacatorValue, int Seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
            if (Locatortype=="ClassName") 
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(LacatorValue)));
            }
        }
    
}
