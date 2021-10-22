using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebAutomationTask.Pages
{
    public class HomePage
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        //The URL of the Project to be opened in the browser
        private const string projectUrl = "https://testscriptdemo.com/";

        //Page Objects
        private IList<IWebElement> AddtowishListElement => _webDriver.FindElements(By.XPath("//li[contains(@class,'product type-product')]//*[contains(@class,'yith-wcwl-add-button')]"));
        private IWebElement WishListheartIconElement => _webDriver.FindElement(By.XPath("//i[@class='lar la-heart']"));
        private IWebElement SearchIconElement => _webDriver.FindElement(By.XPath("//button[@class='header-search-button']"));
        private IList<IWebElement> ProductnamesElement => _webDriver.FindElements(By.XPath("//h2[@class='woocommerce-loop-product__title']"));
        private IList<IWebElement> AddtocartElement => _webDriver.FindElements(By.XPath("//a[@class='button product_type_simple add_to_cart_button ajax_add_to_cart']"));
        private IWebElement ShoplinkElement => _webDriver.FindElement(By.XPath("//li[@itemscope='itemscope']//a[@title='Shop']"));

        private IList<IWebElement> AlreadyAddedtowishListElement => _webDriver.FindElements(By.XPath("//div[contains(@class,'yith-wcwl-wishlistexistsbrowse')]//*[contains(@class,'yith-wcwl-icon fa fa-heart')]"));




        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Url = projectUrl;
        }




        public void SelectCategory(string category)
        {

            // select the drop down list
            var categories = _webDriver.FindElement(By.Name("product_cat"));
            //create select element object 
            var selectElement = new SelectElement(categories);
            //select by value
            selectElement.SelectByValue(category);

        }



        public string AddProductstoMyWishlist()
        {
            Random rnd = new Random();
            int iItemSelected = rnd.Next(AddtowishListElement.Count);
            if (AddtowishListElement[iItemSelected].Text.ToString() != "		The product is already in your wishlist!	")
            {
                AddtowishListElement[iItemSelected].Click();
            }
            return ProductnamesElement[iItemSelected].Text.ToString();
        }

        public void ClickonSearchIcon()
        {
            //Select on Search Icon
            SearchIconElement.Click();

        }

        public void ClickonShopLink()
        {
            //Select on Shop Link
            ShoplinkElement.Click();

        }


        public void ClickonWishListIconinHeader()
        {
            //Select WishList Heart Icon in Header
            WishListheartIconElement.Click();

        }


        public void ClickonAddtoCartButton()
        {
            //Select on Add to Cart Button
            AddtocartElement[0].Click();

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
