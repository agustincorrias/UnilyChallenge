using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Pages.Common;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages;
public class HomePage : BaseOperations
{
    private readonly string _cartButton = "(//a[@href='/view_cart'])[1]";
    private readonly string _productsButton = "(//a[@href='/products'])[1]";
    public HomePage(IPage page) : base(page)
    {
        base.page = page;
    }

    [AllureStep("Click on Cart Button")]
    public async Task<CartPage> ClickOnCartButton()
    {
        await ClickOnElement(_cartButton);
        await WaitPageLoaded();
        return new CartPage(page);
    }

    [AllureStep("Click on Products Button")]
    public async Task<ProductsPage> ClickOnProductsButton()
    {
        await ClickOnElement(_productsButton);
        await WaitPageLoaded();
        return new ProductsPage(page);
    }

    [AllureStep("Return Footer Page")]
    public FooterPage ReturnFooterPage()
    {
        return new FooterPage(page);
    }


}