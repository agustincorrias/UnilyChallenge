using UnilyChallenge.Base;
using UnilyChallenge.Pages;

namespace UnilyChallenge.Tests.baseClasses;
public class BaseProductsPage : BaseTest
{
    public async Task<ProductsPage> SetUpForProductsPageTest()
    {
        HomePage homePage = await new BaseHomeTest().SetUpForHomePageTest();
        return await homePage.ClickOnProductsButton();
    }
}