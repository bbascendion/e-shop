// --------------------------------------------------------------------------------------------------------------------
// © [Satyapriya Nayak], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using Ieshop;
using OpenQA.Selenium;
using System;

namespace ClassEshop
{
    /// <summary>
    /// Provides actions related to managing items in a shopping cart.
    /// Implements the ICart interface.
    /// </summary>
    public class CartAction : ICart
    {
        /// <summary>
        /// Adds a product to the cart using its CSS selector.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="productCssSelector">The CSS selector of the product to add to the cart.</param>
        public void AddToCart(IWebDriver driver, string productCssSelector)
        {
            // Arrange: Locate the product element by its CSS selector.
            var productElement = driver.FindElement(By.CssSelector(productCssSelector));

            // Act: Click on the product element to add it to the cart.
            productElement.Click();
        }

        /// <summary>
        /// Removes a product from the cart using its CSS selector.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="removeButtonCssSelector">The CSS selector of the remove button.</param>
        public void RemoveFromCart(IWebDriver driver, string removeButtonCssSelector)
        {
            // Arrange: Locate the remove button in the cart by its CSS selector.
            var removeButton = driver.FindElement(By.CssSelector(removeButtonCssSelector));

            // Act: Click on the remove button to delete the item from the cart.
            removeButton.Click();
        }

        /// <summary>
        /// Checks if a product is present in the cart.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="cartItemCssSelector">The CSS selector of the cart item.</param>
        /// <returns>True if the product is in the cart, otherwise false.</returns>
        public bool IsProductInCart(IWebDriver driver, string cartItemCssSelector)
        {
            try
            {
                // Arrange & Act: Try locating the cart item using its CSS selector.
                var cartItem = driver.FindElement(By.CssSelector(cartItemCssSelector));

                // Assert: Return true if the cart item is found.
                return cartItem != null;
            }
            catch (NoSuchElementException)
            {
                // Assert: Return false if the cart item is not found.
                return false;
            }
        }

        /// <summary>
        /// Checks if the cart is empty by locating an empty cart message.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="emptyCartMessageCssSelector">The CSS selector of the empty cart message.</param>
        /// <returns>True if the cart is empty, otherwise false.</returns>
        public bool IsCartEmpty(IWebDriver driver, string emptyCartMessageCssSelector)
        {
            try
            {
                // Arrange & Act: Try locating the empty cart message using its CSS selector.
                var emptyCartMessage = driver.FindElement(By.CssSelector(emptyCartMessageCssSelector));

                // Assert: Return true if the empty cart message is found.
                return emptyCartMessage != null;
            }
            catch (NoSuchElementException)
            {
                // Assert: Return false if the empty cart message is not found.
                return false;
            }
        }
    }
}
