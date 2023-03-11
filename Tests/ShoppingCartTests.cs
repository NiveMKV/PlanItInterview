using System;
using PlanItTestProject.Pages;
using NUnit.Framework;

namespace PlanItTestProject.Tests
{
    /// <summary>
    /// Testcases related to shop page and cart tests.
    /// </summary>
    [TestFixture]
    public class ShoppingCartTests
	{
        private PageFactory pageFactory = new PageFactory();
        IDictionary<string, int> ProductDetails = new Dictionary<string, int>()
        {
            {"Stuffed Frog", 2 },
            {"Fluffy Bunny", 5 },
            {"Valentine Bear", 3 }
        };

        IDictionary<string, decimal> ProductPriceDetails = new Dictionary<string, decimal>();
        
        [SetUp]
        public void BeforeTest()
        {
            pageFactory.VerifyHomePageIsLoaded();
        }

        [TearDown]
        public void AfterTest()
        {
            pageFactory.CloseDriver();
        }

        [Test]
        public void VerifyPurchasedProductsTotal_SubTotal_Price()
        {
            pageFactory.homePage.ClickShopMenu();

            //Adding items to the cart.
            foreach(KeyValuePair<string,int> productDetail in ProductDetails)
            {
                pageFactory.shopPage.AddItemToCartByClickingBuyButton(productDetail.Key, productDetail.Value);
                decimal ProductPrice = pageFactory.shopPage.GetPriceOfProductInProductListing(productDetail.Key);
                ProductPriceDetails.Add(productDetail.Key, ProductPrice);
            }

            //verify the price and subtotal of each product added to the cart.
            pageFactory.homePage.ClickCartMenu();
            decimal TotalOfSubTotal = 0;
            foreach (KeyValuePair<string, decimal> productPriceDetail in ProductPriceDetails)
            {
                decimal pdtPriceInTable = pageFactory.cartPage.GetPriceOfProductInCheckoutTable(productPriceDetail.Key);
                Assert.That(pdtPriceInTable.Equals(productPriceDetail.Value), "The price of the product in the shop page isn't equal to the" +
                    "price of the same in the checkout table!!!");
                decimal subTot = pageFactory.cartPage.GetSubTotalOfProductInCheckoutTable(productPriceDetail.Key);
                int qty = ProductDetails[productPriceDetail.Key];
                Assert.That((pdtPriceInTable * qty).Equals(subTot), $"The subtotal of the product/item {productPriceDetail.Key} is incorrect !!!");
                TotalOfSubTotal = TotalOfSubTotal + subTot;
            }

            //verify the total of all products in the cart.
            decimal productTot = pageFactory.cartPage.GetProductTotal();
            Assert.That(productTot.Equals(TotalOfSubTotal), "The total of all the products in the cart doesn't match the total of all sub-totals!!!");
        }

    }
}

