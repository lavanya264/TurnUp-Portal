using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

internal class Program
{
    public static void Main(string[] args)
    {
        //Launch Chrome Browser

        /* ChromeOptions options = new ChromeOptions();
         options.AddUserProfilePreference("profile.password_manage_leak_detection", false);
         IWebDriver driver = new ChromeDriver(options);*/

        var options = new ChromeOptions();
        options.AddArgument("--disable-save-password-bubble");
        options.AddArgument("--incognito"); // fresh session
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        IWebDriver driver = new ChromeDriver(options);



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



        //Check if user has logged in succefully
        IWebElement addNewjob = driver.FindElement(By.Id("addnewjob"));
        if (addNewjob.Text == "Add New Job")
        {
            Console.WriteLine("User has loggedin Succefully");
        }
        else
        {
            Console.WriteLine("UserNameTextBox has Not successfully loggedin");
        }
        //verifying alert

        /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

         try
         {
             // Wait until alert is present
             wait.Until(ExpectedConditions.AlertIsPresent());

             // Switch to alert
             IAlert alert = driver.SwitchTo().Alert();
             Console.WriteLine("Alert text: " + alert.Text);

             alert.Accept();
         }
         catch (WebDriverTimeoutException)
         {
             Console.WriteLine("Alert did not appear within 5 seconds.");
         }*/

        //Identify the Administration dropdown and click

        driver.FindElement(By.Id("eventbutton")).Click();
        IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/a"));
        administration.Click();


        //Idenfy Time and material and click
        IWebElement timeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a"));
        timeAndMaterial.Click();

        //Identify Create new file for Time Record
        IWebElement createNew = driver.FindElement(By.LinkText("Create New"));
        createNew.Click();

        // Opens the Typecode dropdown
        IWebElement dropdown = driver.FindElement(By.ClassName("k-dropdown-wrap"));
        dropdown.Click(); // Opens the dropdown
        Thread.Sleep(2000);

        // Selects the "Time" option
        IWebElement option = driver.FindElement(By.XPath("//li[text()='Time']"));
        option.Click();

        Thread.Sleep(2000);

        //Type code into Code box
        IWebElement code = driver.FindElement(By.Id("Code"));
        code.SendKeys("Industry Connect");

        //Type Description into DescriptionBox
        IWebElement description = driver.FindElement(By.Id("Description"));
        description.SendKeys("TestAnalyst");

        //Enter price
        IWebElement price = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[4]/div/span[1]/span/input[1]"));
        price.SendKeys("6789");

        //save button
        IWebElement save = driver.FindElement(By.Id("SaveButton"));
        save.Click();
        Thread.Sleep(3000);

        //Click on Go To the last page Button
        IWebElement lastPageButton = driver.FindElement(By.XPath("//html//body//div[4]//div[4]//a[4]"));
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
        IWebElement lastPage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lastPageButton));
        lastPage.Click();

        //Retrive last entered code

        IWebElement lastEnteredCode = driver.FindElement(By.XPath("//table//tr[last()]/td[1]"));


        Console.WriteLine(lastEnteredCode.Text);

        if (lastEnteredCode.Text == "Industry Connect")
        {
            Console.WriteLine("New Time file has Created Successfully");

        }
        else
        {
            Console.WriteLine("New Time file has Not Created successfully");
        }


        //Edit Existing Time File from the Record
        Console.WriteLine("Creating New Material file");
        IWebElement editButton = driver.FindElement(By.XPath("//table//tr[last()]/td[last()]/a[1]"));
        editButton.Click();

        //This time Create Material File By selecting material from TypeCode


        // Opens the Typecode dropdown
        IWebElement editDropdown = driver.FindElement(By.ClassName("k-dropdown-wrap"));
        editDropdown.Click(); // Opens the dropdown
        Thread.Sleep(2000);

        IWebElement material = driver.FindElement(By.XPath("//li[text()='Material']"));
        material.Click();

        //Type code into Code box
        IWebElement editedCode = driver.FindElement(By.Id("Code"));
        editedCode.Clear();
        editedCode.SendKeys("Lavanya");

        //Type Description into DescriptionBox
        IWebElement editedDescription = driver.FindElement(By.Id("Description"));
        editedDescription.Clear();
        editedDescription.SendKeys("TestAnalyst");

        //Enter price
        IWebElement editedPrice = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[4]/div/span[1]/span/input[1]"));

        Thread.Sleep(3000);

        editedPrice.SendKeys("6789");

        //save button
        IWebElement editedSave = driver.FindElement(By.Id("SaveButton"));
        editedSave.Click();

        Thread.Sleep(4000);
        //Click on Go To the last page Button
        IWebElement editedLastPageButton = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
        Thread.Sleep(4000);
        editedLastPageButton.Click();

        //Retrive Edited File TypeCode

        IWebElement typeCode = driver.FindElement(By.XPath("//table//tr[last()]/td[2]"));
        Console.WriteLine(typeCode.Text);

        if (typeCode.Text == "M")
        {
            Console.WriteLine("New Materia file has Created Successfully");

        }
        else
        {
            Console.WriteLine("New Material file has Not Created successfully");
        }
        //Delete Newly Created Material file
        IWebElement delete = driver.FindElement(By.XPath("//table//tr[last()]/td[last()]/a[2]"));
        delete.Click();

        IAlert alert = driver.SwitchTo().Alert();
        alert.Accept();

        driver.Quit();
    }
}