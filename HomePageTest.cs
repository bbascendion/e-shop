/// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Ieshop;
using ClassEshop;

namespace TestEshop
{
    [TestFixture]
    public class HomePageTest
    {
        private IWebDriver _driver; // WebDriver instance to control the browser
        private IHomePage _brandImagePage; // Interface for the brand image page
        private IHomePage _mainBannerImagePage; // Interface for the main banner image page

        /// <summary>
        /// Setup method that runs before each test.
        /// Initializes the WebDriver and navigates to the initial page.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(); // Create a new instance of ChromeDriver
            _brandImagePage = new BrandImagePage(_driver); // Initialize the brand image page interface
            _mainBannerImagePage = new MainBannerImagePage(_driver); // Initialize the main banner image page interface
        }

        /// <summary>
        /// Teardown method that runs after each test.
        /// Closes the browser window and disposes of the WebDriver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver.Quit(); // Close the browser
            _driver.Dispose(); // Dispose of the WebDriver
        }

        /// <summary>
        /// Test to verify that the brand image is displayed on the homepage.
        /// </summary>
        [Test]
        public void VerifyBrandImageIsDisplayed()
        {
            _brandImagePage.NavigateToHomePage(); // Navigate to the homepage
            bool isImageDisplayed = _brandImagePage.IsImageDisplayed(); // Check if the brand image is displayed
            Assert.IsTrue(isImageDisplayed, "The brand image is not displayed on the page."); // Assert the result
        }

        /// <summary>
        /// Test to verify the 'src' attribute of the brand image.
        /// </summary>
        [Test]
        public void VerifyBrandImageSrcAttribute()
        {
            string expectedSrc = "/images/brand.png"; // Expected 'src' attribute value
            _brandImagePage.NavigateToHomePage(); // Navigate to the homepage
            string actualSrc = _brandImagePage.GetImageSrc(); // Get the actual 'src' attribute value
            Assert.That(actualSrc, Does.Contain(expectedSrc), "The 'src' attribute of the brand image does not match the expected value."); // Assert the result
        }

        /// <summary>
        /// Test to verify the 'alt' attribute of the brand image.
        /// </summary>
        [Test]
        public void VerifyBrandImageAltAttribute()
        {
            string expectedAlt = "eShop On Web"; // Expected 'alt' attribute value
            _brandImagePage.NavigateToHomePage(); // Navigate to the homepage
            string actualAlt = _brandImagePage.GetImageAlt(); // Get the actual 'alt' attribute value
            Assert.AreEqual(expectedAlt, actualAlt, "The 'alt' attribute of the brand image does not match the expected value."); // Assert the result
        }

        /// <summary>
        /// Test to verify that the main banner image is displayed on the homepage.
        /// </summary>
        [Test]
        public void VerifyMainBannerImageIsDisplayed()
        {
            _mainBannerImagePage.NavigateToHomePage(); // Navigate to the homepage
            bool isImageDisplayed = _mainBannerImagePage.IsImageDisplayed(); // Check if the main banner image is displayed
            Assert.IsTrue(isImageDisplayed, "The main banner image is not displayed on the page."); // Assert the result
        }

        /// <summary>
        /// Test to verify the 'src' attribute of the main banner image.
        /// </summary>
        [Test]
        public void VerifyMainBannerImageSrcAttribute()
        {
            string expectedSrc = "/images/main_banner_text.png"; // Expected 'src' attribute value
            _mainBannerImagePage.NavigateToHomePage(); // Navigate to the homepage
            string actualSrc = _mainBannerImagePage.GetImageSrc(); // Get the actual 'src' attribute value
            Assert.That(actualSrc, Does.Contain(expectedSrc), "The 'src' attribute of the main banner image does not match the expected value."); // Assert the result
        }

        /// <summary>
        /// Test to verify the 'class' attribute of the main banner image.
        /// </summary>
        [Test]
        public void VerifyMainBannerImageClassAttribute()
        {
            string expectedClass = "esh-catalog-title"; // Expected 'class' attribute value
            _mainBannerImagePage.NavigateToHomePage(); // Navigate to the homepage
            string actualClass = _mainBannerImagePage.GetImageClass(); // Get the actual 'class' attribute value
            Assert.AreEqual(expectedClass, actualClass, "The 'class' attribute of the main banner image does not match the expected value."); // Assert the result
        }

    }
}
