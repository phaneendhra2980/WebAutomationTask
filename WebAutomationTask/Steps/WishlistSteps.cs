using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using WebAutomationTask.Drivers;
using WebAutomationTask.Pages;
using WebAutomationTask.Support;

namespace WebAutomationTask.Steps
{
    [Binding]
    public class WishlistSteps
    {

        private readonly HomePage homePage;
        private readonly CartPage cartPage;
        private readonly ShopPage shopPage;
        private readonly WishlistPage wishlistPage;
        string lowestpriceproduct = string.Empty;
        List<string> productslist = new List<string>();



        public WishlistSteps(BrowserDriver browserDriver)
        {
            homePage = new HomePage(browserDriver.Current);
            cartPage = new CartPage(browserDriver.Current);
            wishlistPage = new WishlistPage(browserDriver.Current);
            shopPage = new ShopPage(browserDriver.Current);

        }
        [Given(@"I add four different products to my wish list")]
        public void GivenIAddFourDifferentProductsToMyWishList()
        {

            homePage.SelectCategory("watches");
            homePage.ClickonSearchIcon();
            string watchesproduct = homePage.AddProductstoMyWishlist();
            

            homePage.SelectCategory("womens-clothing");
            homePage.ClickonSearchIcon();
            string womenclothingproduct =  homePage.AddProductstoMyWishlist();
           

            homePage.SelectCategory("mens-clothing");
            homePage.ClickonSearchIcon();
            string menclothingproduct = homePage.AddProductstoMyWishlist();
            

            homePage.SelectCategory("clothing");
            homePage.ClickonSearchIcon();
            string clothingproduct = homePage.AddProductstoMyWishlist();

            
            productslist.Add(clothingproduct);
            Console.WriteLine(clothingproduct);
            productslist.Add(menclothingproduct);
            Console.WriteLine(menclothingproduct);
            productslist.Add(womenclothingproduct);
            Console.WriteLine(womenclothingproduct);
            productslist.Add(watchesproduct);
            Console.WriteLine(watchesproduct);

        }

        [When(@"I view my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {
            homePage.ClickonWishListIconinHeader();

        }

        [Then(@"I find total four selected items in my Wishlist")]
        public void ThenIFindTotalFourSelectedItemsInMyWishlist()
        {
            wishlistPage.VerifySelectedItemsinWishList(productslist);
        }

        [When(@"I search for lowest price product")]
        public void WhenISearchForLowestPriceProduct()
        {
            homePage.ClickonShopLink();
            shopPage.SelectLowPrice();
        }

        [When(@"I am able to add the lowest price item to my cart")]
        public void WhenIAmAbleToAddTheLowestPriceItemToMyCart()
        {
            lowestpriceproduct = homePage.AddProductstoMyWishlist();
            Console.WriteLine(lowestpriceproduct);
            homePage.ClickonAddtoCartButton();
        }



        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart()
        {
            cartPage.ClickonShoppinbagCartIconinHeader();
            cartPage.VerifySelectedItemsinCart(lowestpriceproduct);
        }
    }
}
