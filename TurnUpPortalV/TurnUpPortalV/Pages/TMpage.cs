using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalV.Utilities;

namespace TurnUpPortalV.Pages
{
    public class TMpage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Identify Create new file for Time Record
            IWebElement createNew = driver.FindElement(By.LinkText("Create New"));
            createNew.Click();

            Waits.WaitTobeClickable(driver, "ClassName", "k-dropdown-wrap", 2);
             // Opens the Typecode dropdown
             IWebElement dropdown = driver.FindElement(By.ClassName("k-dropdown-wrap"));
            dropdown.Click(); // Opens the dropdown
           

            // Selects the "Time" option
            IWebElement option = driver.FindElement(By.XPath("//li[text()='Time']"));
            option.Click();

            

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

            Waits.WaitTobeClickable(driver, "XPath", "/html//body//div[4]//div[4]//a[4]", 2);
            //Click on Go To the last page Button
            IWebElement lastPageButton = driver.FindElement(By.XPath("/html//body//div[4]//div[4]//a[4]"));
             lastPageButton.Click();

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
            }
        public void EditTimeRecod(IWebDriver driver)
        {
            //Edit Existing Time File from the Record
            Console.WriteLine("Creating New Material file");
            IWebElement editButton = driver.FindElement(By.XPath("//table//tr[last()]/td[last()]/a[1]"));
            editButton.Click();

            //This time Create Material File By selecting material from TypeCode


            // Opens the Typecode dropdown
            IWebElement editDropdown = driver.FindElement(By.ClassName("k-dropdown-wrap"));
            editDropdown.Click(); // Opens the dropdown
            

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
           

            editedPrice.SendKeys("6789");

            //save button
            IWebElement editedSave = driver.FindElement(By.Id("SaveButton"));
            editedSave.Click();

            Waits.WaitTobeClickable(driver, "XPath", "//span[text()='Go to the last page']", 2);
            //Click on Go To the last page Button
            IWebElement editedLastPageButton = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
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

        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Delete Newly Created Material file
            IWebElement delete = driver.FindElement(By.XPath("//table//tr[last()]/td[last()]/a[2]"));
            delete.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }

}
