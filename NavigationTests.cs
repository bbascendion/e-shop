// --------------------------------------------------------------------------------------------------------------------
// © [Anudharshini Kamaraj], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ClassEshop;
using Ieshop;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestEshop
{
    /// <summary>
    /// Test case to validate navigation from the homepage to the Profile page.
    /// </summary>
    [TestFixture]
    public class NavigationTests
    {
        private IWebDriver _driver;
        private const string BaseUrl = "https://localhost:44315";
        private NavigationAction _navigation;

        /// <summary>
        /// Setup method to initialize the WebDriver and test environment.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the Chrome WebDriver and maximize the browser window
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            // Instantiate the NavigationAction class for navigation actions
            _navigation = new NavigationAction(_driver);
        }

        /// <summary>
        /// Test case to verify navigation to the Profile page and visibility of key fields.
        /// </summary>
        [Test]
        public void NavigateToProfilePage()
        {
            // Arrange: Set up required data and navigate to login
            string username = "demouser@microsoft.com";
            string password = "Pass@word1";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            // Act: Navigate to the login page and perform login
            _navigation.NavigateToLoginPage(_driver, BaseUrl);
            _navigation.PerformLogin(_driver, username, password);

            // Navigate to My Account section
            _driver.Navigate().GoToUrl(BaseUrl + "/manage/my-account");
            _navigation.NavigateToMyAccounts(_driver);

            // Assert: Verify visibility of key elements on the Profile page
            // Verify 'Username' field
            var usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input#Username")));
            Assert.IsTrue(usernameField.Displayed, "The 'Username' field is not displayed on the My Account page.");
            Console.WriteLine("'Username' field is displayed.");

            // Verify 'Email' field
            var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input#Email")));
            Assert.IsTrue(emailField.Displayed, "The 'Email' field is not displayed on the My Account page.");
            Console.WriteLine("'Email' field is displayed.");
        }

        /// <summary>
        /// Cleanup method to dispose of the WebDriver instance after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Dispose of the WebDriver instance to free resources
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
