// --------------------------------------------------------------------------------------------------------------------
// © [Satyapriya Nayak], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ieshop;
using SeleniumExtras.WaitHelpers;

namespace ClassEshop
{
    /// <summary>
    /// The `Checkout` class provides methods to interact with the checkout process in an e-commerce web application.
    /// It contains functionality to navigate to the checkout page, verify order totals, and retrieve order summaries.
    /// </summary>
    public class Checkout : ICheckout
    {
        /// <summary>
        /// Navigates to the checkout page using the provided URL.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        /// <param name="checkoutUrl">The URL of the checkout page.</param>
        public void NavigateToCheckout(IWebDriver driver, string checkoutUrl)
        {
            driver.Navigate().GoToUrl(checkoutUrl);
        }

        /// <summary>
        /// Verifies if the displayed order total matches the expected total.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        /// <param name="expectedTotal">The expected total value as a string.</param>
        /// <returns>True if the displayed total matches the expected total, otherwise false.</returns>
        public bool VerifyOrderTotal(IWebDriver driver, string expectedTotal)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Adjusted wait time for stability
                IWebElement totalElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3.esh-catalog-items.row + h3")));
                string actualTotal = totalElement.Text;
                return actualTotal.Contains(expectedTotal); // Checks if the actual total contains the expected value
            }
            catch (NoSuchElementException)
            {
                return false; // Returns false if the total element is not found
            }
        }

        /// <summary>
        /// Fetches the order summary from the checkout page.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        /// <returns>The text of the order summary.</returns>
        public string GetOrderSummary(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Adjusted wait time for stability
                IWebElement orderSummaryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/h1")));
                return orderSummaryElement.Text; // Returns the text of the order summary
            }
            catch (NoSuchElementException)
            {
                return "Order details not found."; // Returns a message if the order summary element is not found
            }
        }
    }
}
