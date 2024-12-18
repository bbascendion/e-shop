// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using Ieshop;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace ClassEshop
{
    public class Pager : IPager
    {
        private readonly IWebDriver _driver; // WebDriver instance to control the browser

        // Locators for the Previous and Next links
        private readonly By _previousLinkLocator = By.Id("Previous"); // Locator for the 'Previous' link
        private readonly By _nextLinkLocator = By.Id("Next"); // Locator for the 'Next' link

        /// <summary>
        /// Initializes a new instance of the <see cref="Pager"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        public Pager(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Checks if the 'Previous' link is displayed on the page.
        /// </summary>
        /// <returns>True if the 'Previous' link is displayed, otherwise false.</returns>
        public bool IsPreviousLinkDisplayed()
        {
            return _driver.FindElement(_previousLinkLocator).Displayed; // Returns true if the 'Previous' link is visible on the page
        }

        /// <summary>
        /// Checks if the 'Previous' link is enabled.
        /// </summary>
        /// <returns>True if the 'Previous' link is enabled, otherwise false.</returns>
        public bool IsPreviousLinkEnabled()
        {
            var previousLink = _driver.FindElement(_previousLinkLocator);
            return !previousLink.GetAttribute("class").Contains("is-disabled"); // Returns true if the 'Previous' link is not disabled
        }

        /// <summary>
        /// Checks if the 'Next' link is displayed on the page.
        /// </summary>
        /// <returns>True if the 'Next' link is displayed, otherwise false.</returns>
        public bool IsNextLinkDisplayed()
        {
            return _driver.FindElement(_nextLinkLocator).Displayed; // Returns true if the 'Next' link is visible on the page
        }

        /// <summary>
        /// Checks if the 'Next' link is enabled.
        /// </summary>
        /// <returns>True if the 'Next' link is enabled, otherwise false.</returns>
        public bool IsNextLinkEnabled()
        {
            var nextLink = _driver.FindElement(_nextLinkLocator);
            return !nextLink.GetAttribute("class").Contains("is-disabled"); // Returns true if the 'Next' link is not disabled
        }

        /// <summary>
        /// Clicks the 'Previous' link.
        /// </summary>
        public void ClickPrevious()
        {
            _driver.FindElement(_previousLinkLocator).Click(); // Clicks the 'Previous' link
        }

        /// <summary>
        /// Clicks the 'Next' link.
        /// </summary>
        public void ClickNext()
        {
            _driver.FindElement(_nextLinkLocator).Click(); // Clicks the 'Next' link
        }

        /// <summary>
        /// Gets the current URL of the browser.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        public string GetCurrentUrl()
        {
            return _driver.Url; // Returns the current URL of the page
        }

        /// <summary>
        /// Checks if the current URL contains a specific partial URL.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected partial URL.</param>
        /// <returns>True if the current URL contains the expected partial URL, otherwise false.</returns>
        public bool IsCurrentUrl(string expectedPartialUrl)
        {
            return _driver.Url.Contains(expectedPartialUrl); // Returns true if the current URL contains the expected partial URL
        }

        /// <summary>
        /// Waits until the current URL contains a specific partial URL, with a default timeout of 10 seconds.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected partial URL.</param>
        /// <param name="timeoutSeconds">The maximum wait time in seconds.</param>
        public void WaitForUrlToContain(string expectedPartialUrl, int timeoutSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => driver.Url.Contains(expectedPartialUrl)); // Waits until the URL contains the expected partial URL
        }
    }
}
