// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
using Ieshop;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ClassEshop
{
    /// <summary>
    /// Handles various catalog filters on the website, such as brand and type filters.
    /// Provides methods to apply filters, navigate pages, and retrieve URLs.
    /// </summary>
    public class CatalogFilters : ICatalogFilters
    {
        private readonly IWebDriver _driver;
        private readonly string _homePageUrl = "https://localhost:44315/";

        // Locators for filter elements
        private readonly By _brandFilterLocator = By.Id("CatalogModel_BrandFilterApplied");
        private readonly By _typeFilterLocator = By.Id("CatalogModel_TypesFilterApplied");
        private readonly By _submitButtonLocator = By.CssSelector(".esh-catalog-send");
        private readonly By _nextPageButtonLocator = By.CssSelector(".esh-pager-item-right.esh-pager-item--navigable");
        private readonly By _previousPageButtonLocator = By.CssSelector(".esh-pager-item-left.esh-pager-item--navigable");

        public CatalogFilters(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Sets the brand filter based on the specified brand value.
        /// </summary>
        /// <param name="brandValue">The brand value to filter by.</param>
        public void SetBrandFilter(string brandValue)
        {
            var brandSelect = new SelectElement(_driver.FindElement(_brandFilterLocator));
            brandSelect.SelectByValue(brandValue);
        }

        /// <summary>
        /// Sets the type filter based on the specified type value.
        /// </summary>
        /// <param name="typeValue">The type value to filter by.</param>
        public void SetTypeFilter(string typeValue)
        {
            var typeSelect = new SelectElement(_driver.FindElement(_typeFilterLocator));
            typeSelect.SelectByValue(typeValue);
        }

        /// <summary>
        /// Submits the selected filters.
        /// </summary>
        public void SubmitFilters()
        {
            _driver.FindElement(_submitButtonLocator).Click();
        }

        /// <summary>
        /// Gets the current URL of the page.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        /// <summary>
        /// Verifies if the current URL contains the expected partial URL.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected partial URL as a string.</param>
        /// <returns>True if the URL contains the expected partial URL; otherwise, false.</returns>
        public bool IsCurrentUrl(string expectedPartialUrl)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(driver => driver.Url.Contains(expectedPartialUrl));
        }

        /// <summary>
        /// Waits until the current URL contains the expected partial URL.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected partial URL as a string.</param>
        /// <param name="timeoutSeconds">The maximum amount of time to wait, in seconds. Default is 10 seconds.</param>
        public void WaitForUrlToContain(string expectedPartialUrl, int timeoutSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => driver.Url.Contains(expectedPartialUrl));
        }

        /// <summary>
        /// Navigates to the next page of the catalog.
        /// </summary>
        public void NavigateToNextPage()
        {
            _driver.FindElement(_nextPageButtonLocator).Click();
            WaitForUrlToContain("pageId=1");
        }

        /// <summary>
        /// Navigates to the previous page of the catalog.
        /// </summary>
        public void NavigateToPreviousPage()
        {
            _driver.FindElement(_previousPageButtonLocator).Click();
            WaitForUrlToContain("pageId=0");
        }
    }
}
