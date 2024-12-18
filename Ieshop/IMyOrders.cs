// --------------------------------------------------------------------------------------------------------------------
// © [Anudharshini Kamaraj], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ieshop
{
    public interface IMyOrders
    {
        /// <summary>
        /// Navigate to the "My Orders" page.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
        /// <param name="myOrdersUrl">The URL of the "My Orders" page.</param>
        void NavigateToMyOrders(IWebDriver driver, string myOrdersUrl);

        /// <summary>
        /// Verify that the "My Orders" page header is correctly displayed.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
        /// <returns>True if the header is displayed, otherwise false.</returns>
        bool VerifyMyOrdersPageHeader(IWebDriver driver);

        /// <summary>
        /// Check if the order table with columns is visible on the "My Orders" page.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
        /// <returns>True if the order table is visible, otherwise false.</returns>
        bool IsOrderTableDisplayed(IWebDriver driver);
    }
}
