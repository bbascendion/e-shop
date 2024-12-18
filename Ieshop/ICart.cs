// --------------------------------------------------------------------------------------------------------------------
// © [Satyapriya Nayak], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using System;
using OpenQA.Selenium;

namespace Ieshop
{
    /// <summary>
    /// Interface defining the contract for cart-related actions.
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// Adds a product to the cart using its CSS selector.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="productCssSelector">The CSS selector of the product to add to the cart.</param>
        void AddToCart(IWebDriver driver, string productCssSelector);

        /// <summary>
        /// Removes a product from the cart using its CSS selector.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="removeButtonCssSelector">The CSS selector of the remove button.</param>
        void RemoveFromCart(IWebDriver driver, string removeButtonCssSelector);

        /// <summary>
        /// Checks if a product is present in the cart.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="cartItemCssSelector">The CSS selector of the cart item to check.</param>
        /// <returns>True if the product is in the cart, otherwise false.</returns>
        bool IsProductInCart(IWebDriver driver, string cartItemCssSelector);

        /// <summary>
        /// Checks if the cart is empty by locating an empty cart message.
        /// </summary>
        /// <param name="driver">The WebDriver instance for browser interaction.</param>
        /// <param name="emptyCartMessageCssSelector">The CSS selector of the empty cart message.</param>
        /// <returns>True if the cart is empty, otherwise false.</returns>
        bool IsCartEmpty(IWebDriver driver, string emptyCartMessageCssSelector);
    }
}
