using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Pages.Common;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages;
public class ProductsPage : BaseOperations
{

    private readonly string _productsContainer = "//div[@class='features_items']//div[@class='col-sm-4']";
    public ProductsPage(IPage page) : base(page)
    {
        base.page = page;
    }

    [AllureStep("Add Specific Product To Cart")]
    public async Task<(string productName, string productPrice, ModalProductAddedPage productModal)> AddSpecificProductToCart(int index)
    {
        IElementHandle product = await GetProductByIndex(index);
        ProductModalPage productModal = new(page, product);
        await productModal.HoverOnProduct();
        string productName = await productModal.GetProductName();
        string productPrice = await productModal.GetProductPrice();
        await productModal.ClickOnAddToCartButton();
        return (productName, productPrice, new ModalProductAddedPage(page));
    }

    [AllureStep("View Product by Index")]
    public async Task<ProductPage> ViewProduct(int index)
    {
        IElementHandle product = await GetProductByIndex(index);
        ProductModalPage productModal = new(page, product);
        return await productModal.ClickOnViewProductButton();
    }

    public async Task<IElementHandle> GetProductByIndex(int index)
    {
        IReadOnlyList<IElementHandle> products  = await GetElementsInsideParent(_productsContainer);
        if (index < 0 || index >= products.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index of product out of range");
        }
        return products[index];
    }
}