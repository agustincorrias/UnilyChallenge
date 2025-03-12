using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Pages.Common;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages;
public class CartPage : BaseOperations
{
    private readonly string _cartContainer = "//table[@id='cart_info_table']//tr[@id]";
    private readonly string _quantityInput = "//td[@class='cart_quantity']//button";
    private readonly string _productPriceInput = "//p[@class='cart_total_price']";

    public CartPage(IPage page) : base(page)
    {
        base.page = page;
    }

    [AllureStep("Return Footer Page")]
    public FooterPage ReturnFooterPage()
    {
        return new FooterPage(page);    
    }

    [AllureStep("Return Quantity of Products in Cart")]
    public async Task<int> ReturnQuantityOfProductsInCart(int productIndex)
    {
        IReadOnlyList<IElementHandle> listOfProductsInCart = await GetElementsInsideParent(_cartContainer);
        IElementHandle product = listOfProductsInCart[productIndex];
        string quantity = await GetInnerText(product, _quantityInput);
        return int.Parse(quantity);
    }

    [AllureStep("Return Product Price in Cart")]
    public async Task<string> ReturnProductPriceInCart(int productIndex)
    {
        IReadOnlyList<IElementHandle> listOfProductsInCart = await GetElementsInsideParent(_cartContainer);
        IElementHandle product = listOfProductsInCart[productIndex];
        return await GetInnerText(product, _productPriceInput);
    }

    [AllureStep("Get Number of Products in Cart")]
    public async Task<int> GetNumberOfProductsInCart()
    {
        IReadOnlyList<IElementHandle> listOfProductsInCart = await GetElementsInsideParent(_cartContainer);
        return listOfProductsInCart.Count;
    }

}