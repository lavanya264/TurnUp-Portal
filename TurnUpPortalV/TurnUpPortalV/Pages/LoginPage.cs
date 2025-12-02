using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalV.Pages
{
    public class LoginPage
    {
        public void LoginFunction(IWebDriver driver)
        {
            

            //launch Turnup Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("proceed-button")).Click();


            //Identify username textbox and enter valid username
            IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
            userNameTextBox.SendKeys("hari");

            //Identify passwor textbox and enter valid password
            IWebElement PassWordTextBox = driver.FindElement(By.Id("Password"));
            PassWordTextBox.SendKeys("123123");

            //Identify login botton and click for login
            IWebElement LoginBotton = driver.FindElement(By.XPath("//input[@value='Log in']"));
            LoginBotton.Click();

        }
    }
}
