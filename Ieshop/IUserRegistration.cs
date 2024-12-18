// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

namespace Automation_selenium.Pages
{
    public interface IRegistrationPage
    {
        /// <summary>
        /// Navigate to the registration page from the login page.
        /// </summary>
        void NavigateToRegistrationPage();

        /// <summary>
        /// Enter the email address in the registration form.
        /// </summary>
        /// <param name="email">The email address to enter.</param>
        void EnterEmail(string email);

        /// <summary>
        /// Enter the password in the registration form.
        /// </summary>
        /// <param name="password">The password to enter.</param>
        void EnterPassword(string password);

        /// <summary>
        /// Enter the confirmation password in the registration form.
        /// </summary>
        /// <param name="confirmPassword">The confirmation password to enter.</param>
        void EnterConfirmPassword(string confirmPassword);

        /// <summary>
        /// Click the "Register" button on the registration form.
        /// </summary>
        void ClickRegisterButton();

        /// <summary>
        /// Get the error message displayed if the entered email is already taken.
        /// </summary>
        /// <returns>The error message text.</returns>
        string GetErrorMessageForTakenEmail();

        /// <summary>
        /// Get the error message displayed if the entered passwords do not match.
        /// </summary>
        /// <returns>The error message text.</returns>
        string GetErrorMessageForPasswordMismatch();

        /// <summary>
        /// Get the error message if the entered password format is invalid.
        /// </summary>
        /// <returns>The error message text.</returns>
        string GetInvalidPasswordError();

        /// <summary>
        /// Check if the registration header (e.g., "Register") is displayed on the page.
        /// </summary>
        /// <returns>True if the header is displayed, otherwise false.</returns>
        bool IsRegisterHeaderDisplayed();

        /// <summary>
        /// Check if the "Create a new account" header is displayed on the page.
        /// </summary>
        /// <returns>True if the header is displayed, otherwise false.</returns>
        bool IsCreateNewAccountHeaderDisplayed();

        /// <summary>
        /// Get the current URL of the page.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        string GetCurrentUrl();
    }
}
