// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Password_Reset
{
    [TestFixture]
    public class PasswordResetTests
    {
        private IWebDriver driver;
        private PasswordResetPage passwordResetPage;

        /// <summary>
        /// Setup method that initializes WebDriver and navigates to the eShop URL.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); // Initializes Chrome WebDriver
            driver.Manage().Window.Maximize(); // Maximizes the browser window
            passwordResetPage = new PasswordResetPage(driver); // Instantiates the PasswordResetPage
            driver.Navigate().GoToUrl("https://localhost:44315/"); // Replace with your eShop URL
        }

        /// <summary>
        /// Validates that the image with alt text "eShop On Web" is displayed on the Reset Password page.
        /// </summary>
        [Test]
        public void ValidateImagePresenceOnResetPage()
        {
            passwordResetPage.NavigateToLoginPage();
            passwordResetPage.ClickForgotPasswordLink();

            string imageAltText = passwordResetPage.GetImageAltText();
            Assert.AreEqual("eShop On Web", imageAltText, "The image with alt 'eShop On Web' is not displayed.");
        }

        /// <summary>
        /// Verifies that an appropriate error message is shown when an invalid email is entered.
        /// </summary>
        [Test]
        public void ValidateInvalidEmailErrorMessage()
        {
            passwordResetPage.NavigateToLoginPage();
            passwordResetPage.ClickForgotPasswordLink();

            passwordResetPage.EnterEmail("invalid-email"); // Enter invalid email
            passwordResetPage.ClickResetPasswordButton(); // Click reset password button

            string errorMessage = passwordResetPage.GetErrorMessage();
            Assert.AreEqual("The Email field is not a valid e-mail address.", errorMessage,
                "The expected error message for invalid email was not displayed.");
        }

        /// <summary>
        /// Checks that the header text "Forgot your password?" is displayed on the Reset Password page.
        /// </summary>
        [Test]
        public void CheckForgotPasswordHeader()
        {
            passwordResetPage.NavigateToLoginPage();
            passwordResetPage.ClickForgotPasswordLink();

            string headerText = passwordResetPage.GetHeader();
            Assert.AreEqual("Forgot your password?", headerText,
                "The header text does not match the expected value.");
        }

        /// <summary>
        /// Validates the confirmation message after submitting a valid email for password reset.
        /// </summary>
        [Test]
        public void ValidateForgotPasswordConfirmationAndMessage()
        {
            passwordResetPage.NavigateToLoginPage();
            passwordResetPage.ClickForgotPasswordLink();

            passwordResetPage.EnterEmail("demouser@example.com"); // Enter a valid email
            passwordResetPage.ClickResetPasswordButton(); // Click reset password button

            string confirmationMessage = passwordResetPage.GetConfirmationMessage();
            Assert.AreEqual("Please check your email to reset your password.", confirmationMessage,
                "The confirmation message did not match the expected message.");
        }

        /// <summary>
        /// Validates both the confirmation message and header text after submitting a valid email for password reset.
        /// </summary>
        [Test]
        public void ValidateValidPasswordEmail()
        {
            passwordResetPage.NavigateToLoginPage();
            passwordResetPage.ClickForgotPasswordLink();

            passwordResetPage.EnterEmail("demouser@example.com"); // Enter a valid email
            passwordResetPage.ClickResetPasswordButton(); // Click reset password button

            string confirmationMessage = passwordResetPage.GetConfirmationMessage();
            Assert.AreEqual("Please check your email to reset your password.", confirmationMessage,
                "The confirmation message did not match the expected message.");

            string headerText = passwordResetPage.GetHeader();
            Assert.AreEqual("Forgot password confirmation", headerText,
                "The confirmation header text does not match the expected value.");
        }

        /// <summary>
        /// Teardown method to dispose WebDriver and close the browser.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Dispose(); // Disposes WebDriver resources
            driver.Quit(); // Closes the browser
        }
    }
}
