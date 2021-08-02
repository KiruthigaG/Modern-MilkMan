using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace specflowsolution.Steps
{
    [Binding]
    public class TestScenario1
    {
        IWebDriver driver = new ChromeDriver(@"C:/Users/Kiruthiga.Ganesan/source/repos");

        [TestInitialize]
        [Given(@"I navigate to the website")]
        public void INavigateToTheWebsite()
            {
            driver.Navigate().GoToUrl("https://cust.themodernmilkman.co.uk/");
            driver.Manage().Window.Maximize();
            }
   
        [When(@"I click the home image")]
        public void WhenIClickTheHomeImage()
        {

            IWebElement imageEle = driver.FindElement(By.XPath("//a[@id='home_url']/img"));
            imageEle.Click();
      

        }
        [When(@"I click the useraccount logo")]
        public void WhenIClickTheUseraccountLogo()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);
            IWebElement imageEle = driver.FindElement(By.XPath("/html/body/nav/div/div/div[2]/ul/li[1]/a/img"));
            imageEle.Click();


        }

        [Given(@"I enter the ""(.*)"" postcode")]
        public void IEnterThePostcode(string value)
        {
            IWebElement postCode = driver.FindElement(By.XPath("//input[@id='postcode']"));
            postCode.Clear();
            postCode.SendKeys(value);

        }
        [Then(@"I click ""(.*)"" button")]
        public void ThenIClickButton(string buttonName)
        {
         
            IWebElement enterButton = driver.FindElement(By.XPath("//button[contains(text(), '" + buttonName + "')]"));
            enterButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        }
        
        [Given(@"I click the ""(.*)"" logo")]
        public void GivenIClickTheLogo(string logoName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement logobutton = driver.FindElement(By.XPath("//a/img[contains(@class,'" + logoName + "')]"));
            logobutton.Click();

        }

        [When(@"I click the ""(.*)"" link")]
        [When(@"I click ""(.*)"" from the list")]
        public void WhenIClickTheLink(string signUp)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement signLink = driver.FindElement(By.XPath("//a[contains(text(),'" + signUp + "')]"));
            signLink.Click();

        }

        [When(@"I click ""(.*)"" link from the list")]
        public void WhenIClickLinkFromTheList(string account)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement signLink = driver.FindElement(By.XPath("//li[contains(text(),'" + account + "')]"));
            signLink.Click();

        }
        [Then(@"I click checkbox for ""(.*)""")]
        public void ThenIClickCheckboxFor(string value)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement checkValue = driver.FindElement(By.XPath("//input[@id='" + value + "']"));
            checkValue.Click();

        }


        [When(@"I enter ""(.*)"" into ""(.*)"" field")]
        [Then(@"I enter ""(.*)"" into ""(.*)"" field")]
        public void WhenIEnterIntoField(string value, string fieldName)
        {
            IWebElement field1;
            driver.FindElement(By.XPath("//label[contains(text(),'" + fieldName + "')]"));
            switch (fieldName)
            {
                case "Mobile number":
                    field1 = driver.FindElement(By.XPath("//input[@id='phoneNo']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;
                case "Postcode":
                    field1 = driver.FindElement(By.XPath("//input[ @id = 'postcode']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;
                case "First name":
                    field1 = driver.FindElement(By.XPath("//input[ @id = 'forename']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;
                case "Last name":
                    field1 = driver.FindElement(By.XPath("//input[ @id = 'surname']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;
                case "Email address":
                    field1 = driver.FindElement(By.XPath("//input[ @id = 'email']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;
                case "Create a password":
                    field1 = driver.FindElement(By.XPath("//input[ @id = 'password']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;
                case "Password":
                    field1 = driver.FindElement(By.XPath("//input[ @id = 'password']"));
                    field1.Clear();
                    field1.SendKeys(value);
                    break;

            }


        }
        [When(@"I select ""(.*)"" from ""(.*)"" field")]
        public void WhenISelectFromField(string selectValue, string fieldName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
            driver.FindElement(By.XPath("//label[contains(text(),'" + fieldName + "')]"));
            IWebElement signLink = driver.FindElement(By.XPath("//select[@id='heardFrom']/option[contains(text(),'" + selectValue + "')]"));
            signLink.Click();


        }

        [Then(@"the ""(.*)"" appears in the ""(.*)"" field")]
        public void ThenTheAppearsInTheField(string mobileNumber, string fieldName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//label[contains(text(),'" + fieldName + "')]"));
            driver.FindElement(By.XPath("//input[@id='phoneNo'][contains(@value,'" + mobileNumber + "')]"));
           

        }

        [Then(@"I see the field validation message ""(.*)"" on ""(.*)"" field")]
        public void ThenISeeTheFieldValidationMessage(string expectedMessage, string fieldName)
        {
            IWebElement errorMessage;
            string fieldMessage;
            driver.FindElement(By.XPath("//label[contains(text(),'" + fieldName + "')]"));
            if (fieldName == "Mobile number")
            {
                errorMessage = driver.FindElement(By.XPath("//em[@id='phoneNo-error']"));
                fieldMessage = errorMessage.Text;
                Assert.AreEqual(fieldMessage, expectedMessage);
            }
            else if (fieldName == "Postcode")
            {
               errorMessage = driver.FindElement(By.XPath("//em[@id ='postcode-error']"));
               fieldMessage = errorMessage.Text;
                Assert.AreEqual(fieldMessage, expectedMessage);
            }

        }

        [Then(@"an alert appears with the message ""(.*)""")]
        public void ThenAnAlertAppearsWithTheMessage(string expectedMessage)
        {
            IWebElement alertPopup = driver.FindElement(By.XPath("//div[@id='swal2-content'][contains(text(), '" + expectedMessage + "')]"));  
            string alertMessage = alertPopup.Text;
            Assert.AreEqual(alertMessage, expectedMessage);

        }

        [Then(@"the header is ""(.*)""")]
        public void ThenTheHeaderIs(string expectedMessage)
        {

            IWebElement alertPopup = driver.FindElement(By.XPath("//html/body/section[1]/h1[contains(text(), '" + expectedMessage + "')]"));
            string alertMessage = alertPopup.Text;
            Assert.AreEqual(alertMessage, expectedMessage);

        }


        [Then(@"I close the MilkMan Page")]
        public void ThenICloseTheMilkManPage()
        {
            driver.Quit();

        }
    }

    
}
