// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using Ieshop;
using OpenQA.Selenium;

namespace ClassEshop
{
    /// <summary>
    /// Represents the operations and checks for the brand image on the homepage.
    /// </summary>
    public class BrandImagePage : IHomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _homePageUrl = "https://localhost:44315/";

        // Locator for the brand image
        private readonly By _imageLocator = By.CssSelector("img[src='/images/brand.png']");

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandImagePage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        public BrandImagePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the homepage URL.
        /// </summary>
        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(_homePageUrl);
        }

        /// <summary>
        /// Checks if the brand image is displayed on the homepage.
        /// </summary>
        /// <returns>True if the image is displayed; otherwise, false.</returns>
        public bool IsImageDisplayed()
        {
            return _driver.FindElement(_imageLocator).Displayed;
        }

        /// <summary>
        /// Retrieves the 'src' attribute of the brand image.
        /// </summary>
        /// <returns>The image source URL as a string.</returns>
        public string GetImageSrc()
        {
            return _driver.FindElement(_imageLocator).GetAttribute("src");
        }

        /// <summary>
        /// Retrieves the 'alt' attribute of the brand image.
        /// </summary>
        /// <returns>The alt text of the image.</returns>
        public string GetImageAlt()
        {
            return _driver.FindElement(_imageLocator).GetAttribute("alt");
        }

        /// <summary>
        /// Retrieves the 'class' attribute of the brand image.
        /// Throws a NotImplementedException if called.
        /// </summary>
        /// <returns>Not implemented.</returns>
        public string GetImageClass()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Represents the operations and checks for the main banner image on the homepage.
    /// </summary>
    public class MainBannerImagePage : IHomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _homePageUrl = "https://localhost:44315/";

        // Locator for the main banner image
        private readonly By _imageLocator = By.CssSelector("img[src='/images/main_banner_text.png']");

        /// <summary>
        /// Initializes a new instance of the <see cref="MainBannerImagePage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        public MainBannerImagePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the homepage URL.
        /// </summary>
        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(_homePageUrl);
        }

        /// <summary>
        /// Checks if the main banner image is displayed on the homepage.
        /// </summary>
        /// <returns>True if the image is displayed; otherwise, false.</returns>
        public bool IsImageDisplayed()
        {
            return _driver.FindElement(_imageLocator).Displayed;
        }

        /// <summary>
        /// Retrieves the 'src' attribute of the main banner image.
        /// </summary>
        /// <returns>The image source URL as a string.</returns>
        public string GetImageSrc()
        {
            return _driver.FindElement(_imageLocator).GetAttribute("src");
        }

        /// <summary>
        /// Retrieves the 'alt' attribute of the main banner image.
        /// </summary>
        /// <returns>The alt text of the image.</returns>
        public string GetImageAlt()
        {
            return _driver.FindElement(_imageLocator).GetAttribute("alt");
        }

        /// <summary>
        /// Retrieves the 'class' attribute of the main banner image.
        /// </summary>
        /// <returns>The CSS class name of the image.</returns>
        public string GetImageClass()
        {
            return _driver.FindElement(_imageLocator).GetAttribute("class");
        }
    }
}
