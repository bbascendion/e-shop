// --------------------------------------------------------------------------------------------------------------------
// © [Anudharshini Kamaraj], [2024]. All rights reserved.
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
    public class MyOrdersTests
    {
        private IWebDriver _driver;
        private readonly string BaseUrl = "https://localhost:44315";
        private IMyOrders _myOrders;
        private object driver;

        /// <summary>
        /// Setup method to initialize WebDriver before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _myOrders = new MyOrders();
        }

        /// <summary>
        /// Cleanup resources after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        /// <summary>
        /// Test to verify the My Orders page is displayed successfully.
        /// </summary>
        [Test]
        public void VerifyMyOrdersPage()
        {
            // Arrange
            string loginUrl = BaseUrl + "/Identity/Account/Login";
            string myOrdersUrl = BaseUrl + "/order/my-orders";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Login as admin user
            _driver.Navigate().GoToUrl(loginUrl);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Email"))).SendKeys("admin@microsoft.com");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Input.Password"))).SendKeys("Pass@word1");
            _driver.FindElement(By.CssSelector("button[type='submit'].btn.btn-default")).Click();

            // Navigate to My Orders page
            var adminMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"logoutForm\"]/section[1]/div")));
            adminMenu.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("MY ORDERS"))).Click();

            // Act
            _myOrders.NavigateToMyOrders(_driver, myOrdersUrl);
            bool isHeaderVisible = _myOrders.VerifyMyOrdersPageHeader(_driver);
            bool isTableVisible = _myOrders.IsOrderTableDisplayed(_driver);

            // Assert
            Assert.IsTrue(isHeaderVisible, "My Order History");
            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Locate the element using XPath that checks for the specific class and text
            IWebElement orderNumberElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[@class='esh-orders-title col-xs-2' and text()='Order number']")));

            // Assert that the element is displayed
            Assert.IsTrue(orderNumberElement.Displayed, "The 'Order number' element is not present or visible on the page.");
            IWebElement dateElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[@class='esh-orders-title col-xs-4' and text()='Date']")));
            Assert.IsTrue(dateElement.Displayed, "The 'Date' element is not displayed on the page.");
            // Verify 'Total' element
            IWebElement totalElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[@class='esh-orders-title col-xs-2' and text()='Total']")));
            Assert.IsTrue(totalElement.Displayed, "The 'Total' element is not displayed on the page.");
            // Verify 'Status' element
            IWebElement statusElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[@class='esh-orders-title col-xs-2' and text()='Status']")));
            Assert.IsTrue(statusElement.Displayed, "The 'Status' element is not displayed on the page.");


        }
    }
}
