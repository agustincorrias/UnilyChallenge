using Microsoft.Playwright;
using NUnit.Framework;
using UnilyChallenge.Enums;

namespace UnilyChallenge.Base;
public class BaseTest
{
    private readonly PlaywrightRunner playwrightRunner;

    public async ValueTask DisposeAsync()
    {
        await playwrightRunner.CloseBrowser();
    }

    public BaseTest()
    {
        playwrightRunner = new PlaywrightRunner();
    }

    public PlaywrightRunner GetPlaywrightRunner()
    {
        return playwrightRunner;
    }

    public async Task<IPage> Init()
    {
        string browserString = TestContext.Parameters["browser"] ?? "Chromium";
        bool headless = bool.Parse(TestContext.Parameters["headless"] ?? "false");
        if (Enum.TryParse<EBrowser>(browserString, ignoreCase: true, out EBrowser parsedBrowser))
        {
            await playwrightRunner.LaunchBrowser(parsedBrowser, headless);
            return playwrightRunner.GetPage();
        }
        else
        {
            throw new ArgumentException($"Invalid browser value: {browserString}");
        }
    }

    protected static async Task NavigateTo(string url, IPage page)
    {
        await page.GotoAsync(url);
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
}