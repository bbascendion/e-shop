// --------------------------------------------------------------------------------------------------------------------
// © [Anudharshini Kamaraj], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;

namespace Ieshop
{
    /// <summary>
    /// Interface for handling navigation actions across the website.
    /// </summary>
    public interface INavigation
    {
        /// <summary>
        /// Navigate to the login page using the specified base URL.
        /// </summary>
        /// <param name="driver">WebDriver instance for browser interaction.</param>
        /// <param name="baseUrl">Base URL of the website.</param>
        void NavigateToLoginPage(IWebDriver driver, string baseUrl);

        /// <summary>
        /// Perform login to the application using the provided username and password.
        /// </summary>
        /// <param name="driver">WebDriver instance for browser interaction.</param>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        void PerformLogin(IWebDriver driver, string username, string password);

        /// <summary>
        /// Navigate to the "My Accounts" page.
        /// </summary>
        /// <param name="driver">WebDriver instance for browser interaction.</param>
        void NavigateToMyAccounts(IWebDriver driver);

        /// <summary>
        /// Navigate to the "Profile" page under "My Accounts".
        /// </summary>
        /// <param name="driver">WebDriver instance for browser interaction.</param>
        void NavigateToProfile(IWebDriver driver);
    }
}
