using Microsoft.Playwright;
using UnilyChallenge.Base;
using UnilyChallenge.Pages;

namespace UnilyChallenge.Tests;
public class BaseHomeTest : BaseTest
{
    private readonly string _homePageUrl = "https://automationexercise.com/";
    public async Task<HomePage> SetUpForHomePageTest()
    {
        IPage page = await Init();
        await NavigateTo(_homePageUrl, page);
        HomePage homePage = new(page);
        await homePage.WaitPageLoaded();
        return homePage;
    }
}