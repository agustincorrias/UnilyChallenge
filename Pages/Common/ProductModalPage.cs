using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages.Common;
public class ProductModalPage : BaseOperations
{
    private IElementHandle productModal;
    private readonly string _buttonAddToCart = "//a[@data-product-id]";
    private readonly string _productPrice = "//div[@class='productinfo text-center']//h2";
    private readonly string _productName = "//div[@class='productinfo text-center']//p";
    private readonly string _viewProductButton = "//a[@href]";

    public ProductModalPage(IPage page, IElementHandle product) : base(page)
    {
        base.page = page;
        productModal = product;
    }

    [AllureStep("Get Product Price")]
    public async Task<string> GetProductPrice()
    {
        return await GetInnerText(productModal, _productPrice);
    }

    [AllureStep("Get Product Name")]
    public async Task<string> GetProductName()
    {
        return await GetInnerText(productModal, _productName);
    }

    [AllureStep("Click on Add to Cart button")]
    public async Task ClickOnAddToCartButton()
    {
        await ClickChildElement(productModal, _buttonAddToCart);
    }

    [AllureStep("Click on View Product button")]
    public async Task<ProductPage> ClickOnViewProductButton()
    {
        await ClickChildElement(productModal, _viewProductButton);
        await WaitPageLoaded();
        return new ProductPage(page);
    }

    [AllureStep("Hover on Product")]
    public async Task HoverOnProduct()
    {
        await HoverElement(productModal);
    }

}