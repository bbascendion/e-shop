// --------------------------------------------------------------------------------------------------------------------
// © [Satyapriya Nayak], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using ClassEshop;
using Ieshop;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestEshop
{
    [TestFixture]
    public class CheckoutTests
    {
        private IWebDriver _driver;
        private readonly string BaseUrl = "https://localhost:44315";
        private ICheckout _checkout;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize(); // Maximizes the browser window
            _checkout = new Checkout(); // Initialize the Checkout implementation
        }

        [TearDown]
        public void TearDown()
        {
            Dispose(); // Dispose resources after each test
        }

        /// <summary>
        /// Tests the verification of the order total in the checkout process.
        /// </summary>
        [Test]
        public void VerifyOrderTotal()
        {
            // Arrange: Set up the necessary conditions for the test
            _driver.Navigate().GoToUrl("https://localhost:44315/");
            _driver.Navigate().GoToUrl(BaseUrl + "/Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); // Increased timeout

            // Act: Perform actions needed to achieve the test objective
            // Login
            var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Email")));
            var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Password")));
            emailField.SendKeys("demouser@microsoft.com");
            passwordField.SendKeys("Pass@word1");

            var loginButton = _driver.FindElement(By.CssSelector("button[type=\"submit\"].btn.btn-default"));
            loginButton.Click();

            // Wait for the cart icon to ensure login was successful
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[src=\"/images/cart.png\"]")));

            // Navigate to Checkout
            _checkout.NavigateToCheckout(_driver, BaseUrl + "/Basket/Checkout");

            // Fetch Price
            var priceElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("section.esh-basket-item.esh-basket-item--middle.col-xs-2")));
            string priceText = priceElement.Text.Trim('$');
            Assert.IsNotNull(priceText, "Price element is not found or contains invalid text.");
            Assert.IsTrue(decimal.TryParse(priceText, out decimal price), $"Price value '{priceText}' is invalid.");

            // Fetch Quantity
            var quantityElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/form/div/article/div[1]/section[4]")));
            string quantityText = quantityElement.Text.Trim(); // Extracts the visible quantity text
            Assert.IsNotNull(quantityText, "Quantity element is not found or contains invalid text.");
            Assert.IsTrue(int.TryParse(quantityText, out int quantity), $"Quantity value '{quantityText}' is invalid.");

            // Calculate Expected Total
            decimal expectedTotal = price * quantity;

            // Fetch and Validate Total
            var totalElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("section.esh-basket-item.esh-basket-item--mark.col-xs-2")));
            string totalText = totalElement.Text.Trim('$');
            Assert.IsNotNull(totalText, "Total element is not found or contains invalid text.");
            Assert.IsTrue(decimal.TryParse(totalText, out decimal actualTotal), $"Total value '{totalText}' is invalid.");

            // Assert: Verify the outcome
            Assert.AreEqual(expectedTotal, actualTotal, $"Expected total: ${expectedTotal} but found ${actualTotal}.");
        }

        /// <summary>
        /// Tests the verification of the order summary in the checkout process.
        /// </summary>
        [Test]
        public void VerifyOrderSummary()
        {
            // Arrange: Set up the necessary conditions for the test
            _driver.Navigate().GoToUrl(BaseUrl + "/Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); // Increased timeout

            // Act: Perform actions needed to achieve the test objective
            // Login
            var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Email")));
            var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Password")));
            emailField.SendKeys("demouser@microsoft.com");
            passwordField.SendKeys("Pass@word1");

            var loginButton = _driver.FindElement(By.CssSelector("button[type=\"submit\"].btn.btn-default"));
            loginButton.Click();

            // Navigate to Checkout
            _checkout.NavigateToCheckout(_driver, BaseUrl + "/Basket/Checkout");

            // Fetch Order Summary
            string orderSummary = _checkout.GetOrderSummary(_driver);

            // Assert: Verify the outcome
            string expectedOrderSummary = "Review"; // Replace with actual expected text
            Assert.That(orderSummary, Is.EqualTo(expectedOrderSummary), "Order summary does not match expected values.");
        }

        /// <summary>
        /// Tests the navigation of the Pay Now button in the checkout process.
        /// </summary>
        [Test]
        public void VerifyPayNowButtonNavigation()
        {
            // Arrange: Set up the necessary conditions for the test
            _driver.Navigate().GoToUrl("https://localhost:44315/");
            var addItem = _driver.FindElement(By.CssSelector("input.esh-catalog-button[type='submit']"));
            addItem.Click();

            // Navigate to the checkout page
            _checkout.NavigateToCheckout(_driver, BaseUrl + "/Basket/Checkout");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); // Increased timeout

            // Act: Perform actions needed to achieve the test objective
            // Login
            var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Email")));
            var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Password")));
            emailField.SendKeys("demouser@microsoft.com");
            passwordField.SendKeys("Pass@word1");

            var loginButton = _driver.FindElement(By.CssSelector("button[type=\"submit\"].btn.btn-default"));
            loginButton.Click();

            // Find and click the Pay Now button
            var payNowButton = _driver.FindElement(By.CssSelector("input[type='submit'].btn.esh-basket-checkout"));
            payNowButton.Click();

            // Wait for the success page to load and display the "Thanks for your Order!" heading
            var thanksForOrderHeading = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Thanks for your Order!']")));
            Assert.IsTrue(thanksForOrderHeading.Displayed, "The 'Thanks for your Order!' heading is not displayed.");

            // Check if the "Continue Shopping..." link is present
            var continueShoppingLink = _driver.FindElement(By.CssSelector("a[href='/']"));
            Assert.IsTrue(continueShoppingLink.Displayed, "'Continue Shopping...' link is not present.");

            // Act: Click the "Continue Shopping..." link
            continueShoppingLink.Click();

            // Assert: Verify the outcome
            // Verify the redirection to the home page
            string currentUrl = _driver.Url;
            Assert.IsTrue(currentUrl.Contains(BaseUrl), "The user was not redirected to the home page.");
        }

        /// <summary>
        /// Cleans up resources after each test.
        /// </summary>
        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
