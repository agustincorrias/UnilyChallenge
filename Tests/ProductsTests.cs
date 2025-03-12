using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using UnilyChallenge.Pages;
using UnilyChallenge.Pages.Common;
using UnilyChallenge.Tests.baseClasses;

namespace UnilyChallenge.Tests;

[Parallelizable(ParallelScope.Children)]
[TestFixture, Description("Products Page Tests")]
[AllureNUnit]
[AllureParentSuite("Products Page Tests")]
public class ProductsTests : BaseProductsPage
{

    [Test, Description("Add Products in Cart")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Agustin Corrias")]
    [AllureTag("ProductsPage")]
    public async Task ProductsPage_AddProductsInCart()
    {
        string firstExpectedProductPrice = "Rs. 500";
        string secondExpectedProductPrice = "Rs. 400";

        ProductsPage productsPage = await SetUpForProductsPageTest();
        (string firstProductName, string firstProductPrice, ModalProductAddedPage firstProductModal) = await productsPage.AddSpecificProductToCart(0);

        await firstProductModal.ClickOnContinueShoppingButton();

        (string secondProductName, string secondProductPrice, ModalProductAddedPage secondProductModal) = await productsPage.AddSpecificProductToCart(1);

        CartPage cartPage = await secondProductModal.ClickOnViewCartButton();

        int numberOfProductsInCart = await cartPage.GetNumberOfProductsInCart();
        int quantityOfFirstProductInCart = await cartPage.ReturnQuantityOfProductsInCart(0);
        int quantityOfSecondProductInCart = await cartPage.ReturnQuantityOfProductsInCart(1);
        string productPriceInCart = await cartPage.ReturnProductPriceInCart(0);
        string productPriceInCart2 = await cartPage.ReturnProductPriceInCart(1);

        Assert.Multiple(() =>
        {
            Assert.That(firstProductPrice, Is.EqualTo(firstExpectedProductPrice), "First product price is not correct");
            Assert.That(secondProductPrice, Is.EqualTo(secondExpectedProductPrice), "Second product price is not correct");
            Assert.That(numberOfProductsInCart, Is.EqualTo(2), "Number of products in cart is not correct");
            Assert.That(quantityOfFirstProductInCart, Is.EqualTo(1), "Quantity of first product in cart is not correct");
            Assert.That(quantityOfSecondProductInCart, Is.EqualTo(1), "Quantity of second product in cart is not correct");
            Assert.That(productPriceInCart, Is.EqualTo(firstExpectedProductPrice), "Product price in cart is not correct");
            Assert.That(productPriceInCart2, Is.EqualTo(secondExpectedProductPrice), "Product price in cart is not correct");
        });
    }

    [Test, Description("Verify Product quantity in Cart")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Agustin Corrias")]
    [AllureTag("ProductsPage")]
    public async Task ProductsPage_VerifyProductQuantityInCart()
    {
        int expectedProductQuantity = 4;

        ProductsPage productsPage = await SetUpForProductsPageTest(); //plural
        ProductPage productPage = await productsPage.ViewProduct(0); //singular
        await productPage.SetQuantity(expectedProductQuantity);
        CartPage cartPage = await productPage.ClickOnAddToCartButton();

        int numberOfProductsInCart = await cartPage.GetNumberOfProductsInCart();
        int quantityOfFirstProductInCart = await cartPage.ReturnQuantityOfProductsInCart(0);

        Assert.Multiple(() =>
        {
            Assert.That(numberOfProductsInCart, Is.EqualTo(1), "Number of products in cart is not correct");
            Assert.That(quantityOfFirstProductInCart, Is.EqualTo(expectedProductQuantity), "Quantity of first product in cart is not correct");
        });


    }

}