// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

using ClassEshop;
using Ieshop;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestEshop
{
    [TestFixture]
    public class CatalogFiltersTest
    {
        private IWebDriver _driver;
        private ICatalogFilters _catalogFilters;

        /// <summary>
        /// Setup method to initialize WebDriver and navigate to the homepage.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _catalogFilters = new CatalogFilters(_driver);
            _driver.Navigate().GoToUrl("https://localhost:44315/");
        }

        /// <summary>
        /// Cleanup method to close the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        /// <summary>
        /// Test to verify that the brand filter can be applied correctly.
        /// </summary>
        [Test]
        public void VerifyBrandFilter()
        {
            // Act: Apply the brand filter
            _catalogFilters.SetBrandFilter("1"); // Setting brand to "Azure"
            _catalogFilters.SubmitFilters();

            // Assert: Verify if the brand filter was applied correctly
            Assert.IsTrue(_catalogFilters.IsCurrentUrl("CatalogModel.BrandFilterApplied=1"),
                "The 'Azure' brand filter was not applied correctly.");
        }

        /// <summary>
        /// Test to verify that the type filter can be applied correctly.
        /// </summary>
        [Test]
        public void VerifyTypeFilter()
        {
            // Act: Apply the type filter
            _catalogFilters.SetTypeFilter("3"); // Setting type to "Sheet"
            _catalogFilters.SubmitFilters();

            // Assert: Verify if the type filter was applied correctly
            Assert.IsTrue(_catalogFilters.IsCurrentUrl("CatalogModel.TypesFilterApplied=3"),
                "The 'Sheet' type filter was not applied correctly.");
        }

        /// <summary>
        /// Test to verify the application of multiple filters and navigation across pages.
        /// </summary>
        [Test]
        public void VerifyMultipleFiltersAndNavigation()
        {
            // Act: Apply multiple filters
            _catalogFilters.SetBrandFilter("2"); // Setting brand to ".NET"
            _catalogFilters.SetTypeFilter("2"); // Setting type to "T-Shirt"
            _catalogFilters.SubmitFilters();

            // Assert: Verify if multiple filters were applied correctly
            Assert.IsTrue(_catalogFilters.IsCurrentUrl("CatalogModel.BrandFilterApplied=2&CatalogModel.TypesFilterApplied=2"),
                "The '.NET' brand and 'T-Shirt' type filters were not applied correctly.");


        }
    }
}
