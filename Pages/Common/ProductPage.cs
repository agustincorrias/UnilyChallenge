using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages.Common;
public class ProductPage : BaseOperations
{

    private readonly string _quantityInput = "//input[@id='quantity']";
    private readonly string _addToCartButton = "//button[@type='button']";
    public ProductPage(IPage page) : base(page)
    {
        base.page = page;
    }

    [AllureStep("Set Quantity")]
    public async Task SetQuantity(int quantity)
    {
        await ClearInput(_quantityInput);
        await TypeText(_quantityInput, quantity.ToString());
    }

    [AllureStep("Click on Add to Cart button")]
    public async Task<CartPage> ClickOnAddToCartButton()
    {
        await ClickOnElement(_addToCartButton);
        ModalProductAddedPage modalProductAddedPage = new ModalProductAddedPage(page);
        await modalProductAddedPage.ClickOnContinueShoppingButton();
        return await new HomePage(page).ClickOnCartButton();
    }
}