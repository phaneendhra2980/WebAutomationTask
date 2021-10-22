using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationTask.Pages
{
    /// <summary>
    /// Cart Page Object
    /// </summary>
    public class CartPage
    {
        

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;


        public CartPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Page Objects
        private IWebElement ShoppingbagIconElement => _webDriver.FindElement(By.XPath("//i[@class='la la-shopping-bag']"));
    

        //Page Objects
        private IList<IWebElement> CartTableProductNamesElement => _webDriver.FindElements(By.XPath("//td[@class='product-name']"));


        public void VerifySelectedItemsinCart(string product)
        {
            for (int i = 0; i < CartTableProductNamesElement.Count; i++)
            {
                Assert.AreEqual(CartTableProductNamesElement[i].Text, product);               

            }
        }

        public void ClickonShoppinbagCartIconinHeader()
        {
            //Select Shopping Bag/Cart Icon in Header
            ShoppingbagIconElement.Click();

        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
    }
}
