using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages.Common;
public class ModalProductAddedPage : BaseOperations
{   

    private readonly string _modalProductAdded = "//div[@class='modal-content']";
    private readonly string _continueShoppingButton = "//div[@class='modal-content']//button";
    private readonly string _viewCartButton = "//div[@class='modal-content']//u";


    public ModalProductAddedPage(IPage page) : base(page)
    {
        base.page = page;
    }

    [AllureStep("Verify Product Added Modal is visible")]
    public async Task VerifyProductAddedModalIsVisible()
    {
        await EnsureElementIsVisible(page.Locator(_modalProductAdded));
    }

    [AllureStep("Click on Continue Shopping Button")]
    public async Task ClickOnContinueShoppingButton()
    {
        await ClickOnElement(_continueShoppingButton);
    }

    [AllureStep("Click on View Cart Button")]
    public async Task<CartPage> ClickOnViewCartButton()
    {
        await ClickOnElement(_viewCartButton);
        return new CartPage(page);
    }
}