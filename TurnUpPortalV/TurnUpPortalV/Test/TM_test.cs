using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalV.Pages;
using TurnUpPortalV.Utilities;

namespace TurnUpPortalV.Test
{
    [TestFixture]
    public class TM_test:CommanDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            //open browser

            var options = new ChromeOptions();
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("--incognito"); // fresh session
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);


            /*ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);*/

            //LoginPage object initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginFunction(driver);

            //HomePage object initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }
        [Test]
        public void CreateTime_Test()
        {
            //TMpage object initialization and Definition

            TMpage tmPageObj = new TMpage();
            tmPageObj.CreateTimeRecord(driver);

        }
        [Test]
        public void EditTime_Test()
        {
            TMpage tmPageObj = new TMpage();
            tmPageObj.EditTimeRecod(driver);
        }
        [Test]
        public void DeleteTime_Test()
        {
            TMpage tmPageObj = new TMpage();
            tmPageObj.DeleteTimeRecord(driver);
        }
       /* [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }*/
    }
}
