// --------------------------------------------------------------------------------------------------------------------
// © [Anudharshini Kamaraj], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
using Ieshop;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ClassEshop
{
    /// <summary>
    /// Implementation of navigation actions across the website.
    /// </summary>
    public class NavigationAction : Ieshop.INavigation
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        /// <summary>
        /// Constructor to initialize the WebDriver and WebDriverWait instances.
        /// </summary>
        /// <param name="driver">WebDriver instance for browser interaction.</param>
        public NavigationAction(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Navigates to the login page.
        /// </summary>
        /// <param name="driver">WebDriver instance.</param>
        /// <param name="baseUrl">Base URL of the application.</param>
        public void NavigateToLoginPage(IWebDriver driver, string baseUrl)
        {
            // Arrange: Define the URL of the login page.
            string loginPageUrl = baseUrl + "/Identity/Account/Login";

            // Act: Navigate to the login page.
            driver.Navigate().GoToUrl(loginPageUrl);

            // Assert: No assertion required here, as this is purely a navigation action.
        }

        /// <summary>
        /// Logs into the application with the provided credentials.
        /// </summary>
        /// <param name="driver">WebDriver instance.</param>
        /// <param name="username">Username for login.</param>
        /// <param name="password">Password for login.</param>
        public void PerformLogin(IWebDriver driver, string username, string password)
        {
            // Arrange: Wait for the username field to be visible.
            var usernameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Input_Email")));

            // Act: Enter the username and password, then click the login button.
            usernameField.SendKeys(username);
            var passwordField = _driver.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            loginButton.Click();

            // Assert: Assertions can be added in test cases to verify successful login.
        }

        /// <summary>
        /// Navigates to the "My Accounts" page.
        /// </summary>
        /// <param name="driver">WebDriver instance.</param>
        public void NavigateToMyAccounts(IWebDriver driver)
        {
            // Arrange: Wait for the "my-account" link to be present on the page.
            var myAccountsLink = _wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div/div/h2")));

            // Act: Click the "my-account" link.
            myAccountsLink.Click();

            // Assert: Verify that the link is displayed before clicking.
            Assert.IsTrue(myAccountsLink.Displayed, "The 'my-account' link is not visible on the page.");
        }

        /// <summary>
        /// Navigates to the "Profile" page under "My Accounts".
        /// </summary>
        /// <param name="driver">WebDriver instance.</param>
        public void NavigateToProfile(IWebDriver driver)
        {
            // Arrange: Wait for the "Profile" link to be clickable.
            var profileLink = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Profile")));

            // Act: Click the "Profile" link.
            profileLink.Click();

            // Assert: No direct assertion here, as this is a navigation step.
        }
    }
}
