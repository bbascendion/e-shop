// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automation_selenium.Pages;
using OpenQA.Selenium.Support.UI;

namespace Automation_selenium.Tests
{
    [TestFixture]
    public class LoginLogoutTests
    {
        private IWebDriver driver;
        private ILoginPage loginPage;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            // Initialize Chrome WebDriver
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Create instance of LoginPage
            loginPage = new LoginPage(driver);

            // Navigate to the homepage
            driver.Navigate().GoToUrl("https://localhost:44315/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void LoginAndLogoutTest()
        {
            // Step 1: Navigate to the login page
            loginPage.NavigateToLoginPage();

            // Step 2: Perform login with credentials
            loginPage.EnterEmail("demouser@microsoft.com");
            loginPage.EnterPassword("Pass@word1");
            loginPage.SubmitLogin();

            // Step 3: Verify successful login
            wait.Until(drv => drv.Url.Equals("https://localhost:44315/"));
            Assert.AreEqual("https://localhost:44315/", driver.Url, "User was not redirected to the home page after login.");

            // Step 4: Click on the logged-in user's email to trigger logout
            IWebElement loggedInEmail = wait.Until(drv => drv.FindElement(By.XPath("//div[@class='esh-identity-name' and contains(text(), 'demouser@microsoft.com')]")));
            loggedInEmail.Click(); // Click the email to trigger the logout options

            IWebElement logoutLink = wait.Until(drv => drv.FindElement(By.XPath("//a[@class='esh-identity-item' and contains(@href, 'logoutForm')]")));
            logoutLink.Click(); // This will trigger the form submission for logout

            // Step 5: Verify redirection to the home page after logout
            wait.Until(drv => drv.Url.Equals("https://localhost:44315/"));
            Assert.AreEqual("https://localhost:44315/", driver.Url, "User was not redirected to the home page after logout.");
        }
    }
}
