
using UnilyChallenge.Base;
using UnilyChallenge.Pages;

namespace UnilyChallenge.Tests;
public class BaseCartTests : BaseTest
{
    public async Task<CartPage> SetUpForCartPageTest()
    {
        HomePage homePage = await new BaseHomeTest().SetUpForHomePageTest();
        return await homePage.ClickOnCartButton();
    }
}