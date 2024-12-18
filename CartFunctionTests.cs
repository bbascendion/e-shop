// --------------------------------------------------------------------------------------------------------------------
// © [Satyapriya Nayak], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using ClassEshop;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestEshop
{
    /// <summary>
    /// This class contains test cases to validate the functionality of the cart feature in the e-shop application.
    /// It uses Selenium WebDriver for browser automation and NUnit for test execution.
    /// </summary>
    [TestFixture]
    public class CartFunctionTests
    {
        private IWebDriver _driver; // WebDriver instance for controlling the browser
        private const string BaseUrl = "https://localhost:44315"; // Base URL of the e-shop application
        private WebDriverWait _wait; // WebDriverWait instance for explicit waits

        /// <summary>
        /// Set up the WebDriver and prepare the test environment before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Arrange: Initialize WebDriver and maximize the browser
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Explicit wait of 10 seconds
        }

        /// <summary>
        /// Clean up resources and dispose of the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit(); // Close the browser
                _driver.Dispose(); // Release WebDriver resources
            }
        }

        /// <summary>
        /// Test to verify adding a product to the cart and then updating its quantity to zero.
        /// It validates that the cart reflects an empty state after the quantity is set to zero.
        /// </summary>
        [Test]
        public void AddToCartAndUpdateToZero()
        {
            // Arrange: Navigate to the website's base URL
            _driver.Navigate().GoToUrl(BaseUrl);

            // Act: Add a product to the cart
            var addToCartButton = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("input.esh-catalog-button[type='submit'][value='[ ADD TO BASKET ]']")
            ));
            addToCartButton.Click();

            // Act: Navigate to the cart page
            _driver.Navigate().GoToUrl(BaseUrl + "/Basket");

            // Act: Locate the quantity input field, set it to 1, and update the cart
            var quantityInput = _wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("input.esh-basket-input[name='Items[0].Quantity']")
            ));
            quantityInput.Clear();
            quantityInput.SendKeys("1");

            var updateButton = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button.btn.esh-basket-checkout[name='updatebutton']")
            ));
            updateButton.Click();

            // Act: Verify the cart updates with the correct quantity
            var quantityInput1 = _wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("input.esh-basket-input[name='Items[0].Quantity']")
            ));

            // Act: Change the quantity to 0 and update the cart
            quantityInput1.Clear();
            quantityInput1.SendKeys("0");

            var updateButton1 = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button.btn.esh-basket-checkout[name='updatebutton']")
            ));
            updateButton1.Click();

            // Assert: Wait for and verify the cart reflects an empty state
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(
                By.CssSelector("h3.esh-catalog-items.row"), "Basket is empty."
            ));
            var emptyCartMessage = _driver.FindElement(By.CssSelector("h3.esh-catalog-items.row")).Text;
            Assert.IsTrue(emptyCartMessage.Contains("Basket is empty."),
                "The cart is not empty after removing the item.");
        }
    }
}
