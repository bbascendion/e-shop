// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

namespace Password_Reset
{
    /// <summary>
    /// Implements the functionalities for the Password Reset Page.
    /// </summary>
    public class PasswordResetPage : IPasswordResetPage
    {
        private IWebDriver driver; // The WebDriver instance used for browser automation
        private WebDriverWait wait; // WebDriverWait instance for waiting on elements to be visible

        // Locators for page elements
        private readonly By forgotPasswordLinkLocator = By.XPath("//a[contains(text(), 'Forgot your password?')]"); // Locator for the "Forgot your password?" link
        private readonly By emailInputLocator = By.Id("Input_Email"); // Locator for the email input field
        private readonly By resetPasswordButtonLocator = By.XPath("//button[@type='submit' and contains(@class, 'btn-primary') and contains(text(), 'Reset Password')]"); // Locator for the "Reset Password" button
        private readonly By confirmationMessageLocator = By.XPath("//p[contains(text(), 'Please check your email to reset your password.')]"); // Locator for the confirmation message
        private readonly By headerLocator = By.XPath("//h1"); // Locator for the header text (e.g., "Forgot password confirmation")
        private readonly By errorMessageLocator = By.XPath("//span[@data-valmsg-for='Input.Email']//span[contains(text(), 'The Email field is not a valid e-mail address.')]"); // Locator for the error message if the email is invalid
        private readonly By imageLocator = By.XPath("//img[@alt='eShop On Web']"); // Locator for the image element

        public PasswordResetPage(IWebDriver driver)
        {
            this.driver = driver; // Initialize WebDriver instance
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Initialize WebDriverWait with a timeout of 10 seconds
        }

        // Navigate to the login page
        public void NavigateToLoginPage()
        {
            IWebElement loginLink = driver.FindElement(By.XPath("//a[@class='esh-identity-name esh-identity-name--upper']")); // Locate the login link element
            loginLink.Click(); // Click the login link to navigate to the login page
        }

        // Click the "Forgot your password?" link
        public void ClickForgotPasswordLink()
        {
            wait.Until(drv => drv.FindElement(forgotPasswordLinkLocator)).Click(); // Wait for the "Forgot your password?" link to be clickable and then click it
        }

        // Enter an email in the "Forgot Password" page
        public void EnterEmail(string email)
        {
            IWebElement emailInput = wait.Until(drv => drv.FindElement(emailInputLocator)); // Wait for the email input field to be visible
            emailInput.SendKeys(email); // Enter the email into the input field
        }

        // Click the "Reset Password" button
        public void ClickResetPasswordButton()
        {
            wait.Until(drv => drv.FindElement(resetPasswordButtonLocator)).Click(); // Wait for the "Reset Password" button to be clickable and then click it
        }

        // Get the confirmation message after resetting password
        public string GetConfirmationMessage()
        {
            IWebElement messageElement = wait.Until(drv => drv.FindElement(confirmationMessageLocator)); // Wait for the confirmation message element to be visible
            return messageElement.Text; // Return the text of the confirmation message
        }

        // Get the header text (e.g., "Forgot password confirmation")
        public string GetHeader()
        {
            IWebElement headerElement = wait.Until(drv => drv.FindElement(headerLocator)); // Wait for the header element to be visible
            return headerElement.Text; // Return the text of the header
        }

        // Get the error message if the email is invalid
        public string GetErrorMessage()
        {
            IWebElement errorMessageElement = wait.Until(drv => drv.FindElement(errorMessageLocator)); // Wait for the error message element to be visible
            return errorMessageElement.Text; // Return the text of the error message
        }

        // Get the alt text of the image (e.g., "eShop On Web")
        public string GetImageAltText()
        {
            IWebElement imageElement = wait.Until(drv => drv.FindElement(imageLocator)); // Wait for the image element to be visible
            return imageElement.GetAttribute("alt"); // Return the alt attribute value of the image
        }
    }
}
