// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;

namespace Automation_selenium.Pages
{
    /// <summary>
    /// Represents the Login Page of the application.
    /// Contains methods to interact with the login form elements.
    /// </summary>
    public class LoginPage : ILoginPage
    {
        private readonly IWebDriver _driver; // The WebDriver instance to control the browser
        private IWebElement EmailInput => _driver.FindElement(By.Id("Input_Email")); // Email input field
        private IWebElement PasswordInput => _driver.FindElement(By.Id("Input_Password")); // Password input field
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//button[@type='submit' and contains(text(), 'Log in')]")); // Login button
        private IWebElement LoginLink => _driver.FindElement(By.XPath("//a[@class='esh-identity-name esh-identity-name--upper']")); // Login link

        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the login page by clicking the login link.
        /// </summary>
        public void NavigateToLoginPage()
        {
            LoginLink.Click(); // Clicks the login link to navigate to the login page
        }

        /// <summary>
        /// Enters the email into the email input field.
        /// </summary>
        /// <param name="email">The email address to enter.</param>
        public void EnterEmail(string email)
        {
            EmailInput.Clear(); // Clears any existing text
            EmailInput.SendKeys(email); // Enters the email address
        }

        /// <summary>
        /// Enters the password into the password input field.
        /// </summary>
        /// <param name="password">The password to enter.</param>
        public void EnterPassword(string password)
        {
            PasswordInput.Clear(); // Clears any existing text
            PasswordInput.SendKeys(password); // Enters the password
        }

        /// <summary>
        /// Clicks the login button to submit the login form.
        /// </summary>
        public void SubmitLogin()
        {
            LoginButton.Click(); // Clicks the login button to submit the form
        }

        /// <summary>
        /// Gets the error message displayed if the login fails.
        /// </summary>
        /// <returns>The error message text, or null if no error is found.</returns>
        public string GetErrorMessage()
        {
            try
            {
                IWebElement errorElement = _driver.FindElement(By.XPath("//div[@class='validation-summary-errors']")); // Finds the error message element
                return errorElement.Text; // Returns the text of the error message
            }
            catch
            {
                return null; // No error message found
            }
        }
    }
}
