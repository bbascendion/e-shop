// --------------------------------------------------------------------------------------------------------------------
// © [Anudharshini Kamaraj], [2024]. All rights reserved.
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
    public class MyOrders : IMyOrders
    {
        /// <summary>
        /// Navigate to the "My Orders" page by accessing the provided URL.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
        /// <param name="myOrdersUrl">The URL of the "My Orders" page.</param>
        public void NavigateToMyOrders(IWebDriver driver, string myOrdersUrl)
        {
            driver.Navigate().GoToUrl(myOrdersUrl);
        }

        /// <summary>
        /// Verify that the page header matches "My Order History".
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
        /// <returns>True if the "My Order History" header is displayed, otherwise false.</returns>
        public bool VerifyMyOrdersPageHeader(IWebDriver driver)
        {
            try
            {
                var headerElement = driver.FindElement(By.XPath("//h1[text()='My Order History']"));
                return headerElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the order table with columns is displayed on the page.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
        /// <returns>True if the order table is displayed, otherwise false.</returns>
        public bool IsOrderTableDisplayed(IWebDriver driver)
        {
            try
            {
                var tableHeaders = driver.FindElement(By.XPath("//table"));
                return tableHeaders.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
