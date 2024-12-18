// --------------------------------------------------------------------------------------------------------------------
// © [Satyapriya Nayak], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using System;

namespace Ieshop
{
    public interface ICheckout
    {
        /// <summary>
        /// Navigates to the checkout page.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        /// <param name="checkoutUrl">The URL of the checkout page.</param>
        void NavigateToCheckout(IWebDriver driver, string checkoutUrl);

        /// <summary>
        /// Fetches the order summary from the checkout page.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        /// <returns>The text of the order summary.</returns>
        string GetOrderSummary(IWebDriver driver);

        /// <summary>
        /// Verifies if the displayed order total matches the expected total.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        /// <param name="expectedTotal">The expected total value as a string.</param>
        /// <returns>True if the displayed total matches the expected total, otherwise false.</returns>
        bool VerifyOrderTotal(IWebDriver driver, string expectedTotal);
    }
}
