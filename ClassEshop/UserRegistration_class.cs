// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation_selenium.Pages
{
    /// <summary>
    /// Implements the functionalities for the Registration Page.
    /// </summary>
    public class RegistrationPage : IRegistrationPage
    {
        private readonly IWebDriver driver; // The WebDriver instance used for browser automation
        private readonly WebDriverWait wait; // WebDriverWait instance for waiting on elements to be visible

        // Constructor
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver; // Initialize WebDriver instance
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Initialize WebDriverWait with a timeout of 10 seconds
        }

        // Locators
        private By LoginLink => By.XPath("//a[@class='esh-identity-name esh-identity-name--upper']"); // Locator for the login link
        private By RegisterLink => By.XPath("//a[contains(text(), 'Register as a new user')]"); // Locator for the registration link
        private By EmailInput => By.Id("Input_Email"); // Locator for the email input field
        private By PasswordInput => By.Id("Input_Password"); // Locator for the password input field
        private By ConfirmPasswordInput => By.Id("Input_ConfirmPassword"); // Locator for the confirm password input field
        private By RegisterButton => By.XPath("//button[@type='submit' and contains(text(), 'Register')]"); // Locator for the register button
        private By TakenEmailError => By.XPath("//span[contains(text(), 'is already taken')]"); // Locator for the error message if the email is already taken
        private By PasswordMismatchError => By.Id("Input_ConfirmPassword-error"); // Locator for the error message if passwords do not match
        private By RegisterHeader => By.XPath("//h2[text()='Register']"); // Locator for the registration header
        private By CreateAccountHeader => By.XPath("//h4[text()='Create a new account.']"); // Locator for the create account header

        // Navigate to the Registration Page
        public void NavigateToRegistrationPage()
        {
            driver.Navigate().GoToUrl("https://localhost:44315/"); // Navigate to the home page
            driver.FindElement(LoginLink).Click(); // Click on the login link
            wait.Until(drv => drv.Url.Contains("/Identity/Account/Login")); // Wait until the login page is loaded
            driver.FindElement(RegisterLink).Click(); // Click on the registration link
            wait.Until(drv => drv.Url.Contains("/Identity/Account/Register")); // Wait until the registration page is loaded
        }

        // Enter email in the registration form
        public void EnterEmail(string email)
        {
            driver.FindElement(EmailInput).SendKeys(email); // Input the email into the email field
        }

        // Enter password in the registration form
        public void EnterPassword(string password)
        {
            driver.FindElement(PasswordInput).SendKeys(password); // Input the password into the password field
        }

        // Enter confirm password in the registration form
        public void EnterConfirmPassword(string confirmPassword)
        {
            driver.FindElement(ConfirmPasswordInput).SendKeys(confirmPassword); // Input the confirm password into the confirm password field
        }

        // Click the register button to submit the form
        public void ClickRegisterButton()
        {
            driver.FindElement(RegisterButton).Click(); // Click the register button to submit the form
        }

        // Get the error message if the email is already taken
        public string GetErrorMessageForTakenEmail()
        {
            return wait.Until(drv => drv.FindElement(TakenEmailError)).Text; // Wait for the error message to be visible and return its text
        }

        // Get the error message if the passwords do not match
        public string GetErrorMessageForPasswordMismatch()
        {
            return wait.Until(drv => drv.FindElement(PasswordMismatchError)).Text; // Wait for the error message to be visible and return its text
        }

        // Get the invalid password error message
        public string GetInvalidPasswordError()
        {
            return wait.Until(drv => drv.FindElement(By.XPath("//span[contains(@class, 'field-validation-error')]"))).Text; // Wait for the error message to be visible and return its text
        }

        // Check if the registration header is displayed
        public bool IsRegisterHeaderDisplayed()
        {
            return wait.Until(drv => drv.FindElement(RegisterHeader)).Displayed; // Wait for the header to be visible and return its display status
        }

        // Check if the "Create a new account" header is displayed
        public bool IsCreateNewAccountHeaderDisplayed()
        {
            return wait.Until(drv => drv.FindElement(CreateAccountHeader)).Displayed; // Wait for the header to be visible and return its display status
        }

        // Get the current URL of the page
        public string GetCurrentUrl()
        {
            return driver.Url; // Return the current URL of the page
        }
    }
}
