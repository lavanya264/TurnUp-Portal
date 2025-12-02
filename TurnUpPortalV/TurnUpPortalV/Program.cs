using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TurnUpPortalV.Pages;

public class Program
{
    public static void Main(string[] args)
    {


        /* ChromeOptions options = new ChromeOptions();
         options.AddUserProfilePreference("profile.password_manage_leak_detection", false);
         IWebDriver driver = new ChromeDriver(options);*/
        //Launch Chrome Browser

        var options = new ChromeOptions();
        options.AddArgument("--disable-save-password-bubble");
        options.AddArgument("--incognito"); // fresh session
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        IWebDriver driver = new ChromeDriver(options);

        //LoginPage object initialization and Definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginFunction(driver);

        //HomePage object initialization and definition

        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //TMpage object initialization and Definition

        TMpage tmPageObj = new TMpage();
        tmPageObj.CreateTimeRecord(driver);
        tmPageObj.EditTimeRecod(driver);
        tmPageObj.DeleteTimeRecord(driver);

    }
}