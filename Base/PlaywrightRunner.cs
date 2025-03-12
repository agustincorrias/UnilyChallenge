using Microsoft.Playwright;
using UnilyChallenge.Enums;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Base;

public interface IBrowserManager
{
    Task<IPage> LaunchBrowser(EBrowser browserName, bool headless);
    Task NavigateToUrl(string url);
    Task CloseBrowser();
    IPage GetPage();
}
public class PlaywrightRunner : IBrowserManager
{
    private IPlaywright pw;
    private IBrowser Browser;
    private IBrowserContext BrowserContext;
    private IPage Page;

    public PlaywrightRunner()
    {
    }

    public async Task<IPage> LaunchBrowser(EBrowser browserName, bool headless)
    {
        pw = await Playwright.CreateAsync();
        Browser = browserName switch
        {
            EBrowser.Chromium => await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = headless
            }),
            EBrowser.Firefox => await pw.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = headless
            }),
            EBrowser.Webkit => await pw.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = headless
            }),
            _ => throw new Exception("Missing browser"),
        };
        BrowserContext = await Browser.NewContextAsync();
        Page = await BrowserContext.NewPageAsync();
        return Page;
    }

    public async Task NavigateToUrl(string url)
    {
        try
        {
            await Page.GotoAsync(url);
        }
        catch (Exception e)
        {
            LogHelper.LogError("Error navigating to url", e);
        }
    }

    public async Task CloseBrowser()
    {
        await Page.CloseAsync();
        await BrowserContext.CloseAsync();
        await Browser.CloseAsync();
        pw.Dispose();
        Page = null;
        BrowserContext = null;
        Browser = null;
        pw = null;
    }

    public IPage GetPage()
    {
        return Page;
    }

    public IBrowserContext GetBrowserContext()
    {
        return BrowserContext;
    }

    public IBrowser GetBrowser()
    {
        return Browser;
    }
}
    