// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

namespace Automation_selenium.Pages
{
    /// <summary>
    /// Defines the contract for interacting with the Login Page.
    /// </summary>
    public interface ILoginPage
    {
        /// <summary>
        /// Navigates to the login page.
        /// </summary>
        void NavigateToLoginPage(); // Navigate to the login page

        /// <summary>
        /// Enters the email into the login form.
        /// </summary>
        /// <param name="email">The email address to enter.</param>
        void EnterEmail(string email); // Enter email in the login form

        /// <summary>
        /// Enters the password into the login form.
        /// </summary>
        /// <param name="password">The password to enter.</param>
        void EnterPassword(string password); // Enter password in the login form

        /// <summary>
        /// Clicks the login button to submit the login form.
        /// </summary>
        void SubmitLogin(); // Click the login button to submit the form

        /// <summary>
        /// Gets the error message displayed if the login fails.
        /// </summary>
        /// <returns>The error message text, or null if no error is found.</returns>
        string GetErrorMessage(); // Get the error message if login fails
    }
}
