// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ClassEshop;
using Ieshop;
using static System.Net.Mime.MediaTypeNames;

namespace TestEshop
{
    [TestFixture]
    public class PagerTest
    {
        private IWebDriver _driver; // WebDriver instance to control the browser
        private IPager _pager; // Interface for the pager functionalities

        /// <summary>
        /// Setup method that runs before each test.
        /// Initializes the WebDriver, navigates to the application URL, and initializes the Pager interface.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(); // Create a new instance of ChromeDriver
            _driver.Navigate().GoToUrl("https://localhost:44315/"); // Replace with your actual URL
            _pager = new Pager(_driver); // Initialize the pager interface
        }

        /// <summary>
        /// Teardown method that runs after each test.
        /// Closes the browser and disposes of the WebDriver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver.Quit(); // Close the browser
            _driver.Dispose(); // Dispose of the WebDriver
        }

        /// <summary>
        /// Test to verify if the 'Previous' link is displayed on the page.
        /// </summary>
        [Test]
        public void VerifyPreviousLinkIsDisplayed()
        {
            Assert.IsTrue(_pager.IsPreviousLinkDisplayed(), "The 'Previous' link is not displayed.");
        }

        /// <summary>
        /// Test to verify if the 'Next' link is enabled on the page.
        /// </summary>
        [Test]
        public void VerifyNextLinkIsEnabled()
        {
            bool isEnabled = _pager.IsNextLinkEnabled(); // Check if the 'Next' link is enabled
            Assert.IsTrue(isEnabled, "The 'Next' link is enabled when it should be enabled.");
        }

        /// <summary>
        /// Test to verify if the 'Next' link is displayed on the page.
        /// </summary>
        [Test]
        public void VerifyNextLinkIsDisplayed()
        {
            Assert.IsTrue(_pager.IsNextLinkDisplayed(), "The 'Next' link is not displayed.");
        }

        /// <summary>
        /// Test to verify if the 'Previous' link is enabled on the page.
        /// </summary>
        [Test]
        public void VerifyPreviousLinkIsEnabled()
        {
            bool isEnabled = _pager.IsPreviousLinkEnabled(); // Check if the 'Previous' link is enabled
            Assert.IsFalse(isEnabled, "The 'Previous' link is enabled when it should be disabled.");
        }

        /// <summary>
        /// Test to verify the pager navigation with specific URL checks.
        /// Validates navigation to the next and previous pages and their corresponding URLs.
        /// </summary>
        [Test]
        public void VerifyPagerNavigationWithSpecificUrlCheck()
        {
            // Expected URLs
            string page1Url = "https://localhost:44315/?pageId=0";
            string page2Url = "https://localhost:44315/?pageId=1";

            // Navigate to the next page
            Assert.IsTrue(_pager.IsNextLinkDisplayed(), "The 'Next' link is not displayed.");
            Assert.IsTrue(_pager.IsNextLinkEnabled(), "The 'Next' link is not enabled.");
            _pager.ClickNext(); // Click the 'Next' link

            // Wait and validate URL of the next page
            Assert.IsTrue(_pager.IsCurrentUrl("?pageId=1"), $"Navigation to the next page did not result in the expected URL. Current URL: {_pager.GetCurrentUrl()}");

            // Navigate back to the previous page
            Assert.IsTrue(_pager.IsPreviousLinkDisplayed(), "The 'Previous' link is not displayed.");
            Assert.IsTrue(_pager.IsPreviousLinkEnabled(), "The 'Previous' link is not enabled.");
            _pager.ClickPrevious(); // Click the 'Previous' link

            // Wait and validate URL of the previous page
            Assert.IsTrue(_pager.IsCurrentUrl("?pageId=0"), $"Navigation back to the previous page did not result in the expected URL. Current URL: {_pager.GetCurrentUrl()}");
        }
    }
}
