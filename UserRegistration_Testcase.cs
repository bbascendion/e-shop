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
using System;

namespace Automation_selenium.Tests
{
    [TestFixture]
    public class RegistrationTests
    {
        private IWebDriver driver;
        private IRegistrationPage registrationPage;

        /// <summary>
        /// Setup method that initializes WebDriver and maximizes the browser window.
        /// Instantiates the registration page interface.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); // Initializes the Chrome WebDriver
            driver.Manage().Window.Maximize(); // Maximizes the browser window
            registrationPage = new RegistrationPage(driver); // Instantiates the registration page interface
        }

        /// <summary>
        /// Teardown method that disposes of the WebDriver and quits the browser.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Dispose(); // Disposes of the WebDriver instance
            driver.Quit(); // Quits the browser session
        }

        /// <summary>
        /// Test to verify that the registration page can be navigated to successfully.
        /// </summary>
        [Test]
        public void Test_NavigateToRegistrationPage()
        {
            registrationPage.NavigateToRegistrationPage(); // Navigate to the registration page
            Assert.IsTrue(registrationPage.GetCurrentUrl().Contains("/Identity/Account/Register"),
                "The current URL does not contain '/Identity/Account/Register'.");
        }

        /// <summary>
        /// Test to verify that the registration header is displayed on the page.
        /// </summary>
        [Test]
        public void Test_RegisterHeaderDisplayed()
        {
            registrationPage.NavigateToRegistrationPage(); // Navigate to the registration page
            Assert.IsTrue(registrationPage.IsRegisterHeaderDisplayed(), "The registration header is not displayed.");
        }

        /// <summary>
        /// Test to verify that the 'Create a new account' header is displayed on the page.
        /// </summary>
        [Test]
        public void Test_CreateNewAccountHeaderDisplayed()
        {
            registrationPage.NavigateToRegistrationPage(); // Navigate to the registration page
            Assert.IsTrue(registrationPage.IsCreateNewAccountHeaderDisplayed(), "The 'Create a new account' header is not displayed.");
        }

        /// <summary>
        /// Test to verify that an appropriate error message is displayed when the passwords do not match.
        /// </summary>
        [Test]
        public void Test_PasswordMismatchError()
        {
            registrationPage.NavigateToRegistrationPage(); // Navigate to the registration page
            registrationPage.EnterEmail("mismatchuser@example.com"); // Enter email
            registrationPage.EnterPassword("Password123!"); // Enter password
            registrationPage.EnterConfirmPassword("MismatchPassword456!"); // Enter mismatched confirmation password
            registrationPage.ClickRegisterButton(); // Click the register button

            string actualError = registrationPage.GetErrorMessageForPasswordMismatch(); // Retrieve the error message
            Assert.AreEqual("The password and confirmation password do not match.", actualError,
                "The password mismatch error message is incorrect.");
        }

        /// <summary>
        /// Test to verify that a user can register successfully with valid details.
        /// </summary>
        [Test]
        public void Test_ValidRegistration()
        {
            registrationPage.NavigateToRegistrationPage(); // Navigate to the registration page
            string uniqueEmail = $"validuser{DateTime.Now.Ticks}@example.com"; // Generate a unique email address
            registrationPage.EnterEmail(uniqueEmail); // Enter the unique email
            registrationPage.EnterPassword("Valid@Password123!"); // Enter valid password
            registrationPage.EnterConfirmPassword("Valid@Password123!"); // Confirm the valid password
            registrationPage.ClickRegisterButton(); // Click the register button

            Assert.AreEqual("https://localhost:44315/", registrationPage.GetCurrentUrl(),
                "User was not redirected to the home page after successful registration.");
        }
    }
}
