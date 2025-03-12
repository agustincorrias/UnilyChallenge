using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace UnilyChallenge.Utils;
public class BaseOperations(IPage page) : PageTest
{
    protected IPage page = page;
    private const float _LocatorWaitTime = 15000;
    private const float _VisibilityWaitTime = 15000;

    public async Task<IReadOnlyList<IElementHandle>> GetElementsInsideParent(string parent)
    {
        ILocator parentLocator = page.Locator(parent);
        return await parentLocator.ElementHandlesAsync();
    }

    [AllureStep("Wait for page to load")]
    public async Task WaitPageLoaded()
    {
        await WaitForDOMLoaded();
    }

    private async Task WaitForDOMLoaded()
    {
        await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }

    [AllureStep("Scroll to bottom of the page")]
    public async Task ScrollToBottom()
    {
        await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
    }

    protected async Task TypeText(string selector, string text)
    {
        await EnsureElementIsVisible(selector);
        await page.FillAsync(selector, text);
    }

    protected async Task HoverElement(IElementHandle parentElement)
    {
        await parentElement.HoverAsync();
    }

    protected async Task<string> GetInnerText(IElementHandle parentElement, string childElement)
    {
         return await (await parentElement.WaitForSelectorAsync(childElement)).InnerTextAsync();
    }

    protected async Task<string> GetInnerText(string selector)
    {
        return await page.Locator(selector).InnerTextAsync();
    }

    protected async Task ClickOnElement(string selector)
    {
        await EnsureElementIsVisible(selector);
        await page.ClickAsync(selector);
    }

    protected async Task<bool> IsElementVisible(string selector)
    {
        return await page.Locator(selector).IsVisibleAsync();
    }

    protected async Task EnsureElementIsVisible(ILocator element)
    {
        await Expect(element).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = _VisibilityWaitTime });
    }

    protected async Task EnsureElementIsVisible(string selector)
    {
        await EnsureElementIsVisible(page.Locator(selector));
    }

    protected async Task ClickChildElement(IElementHandle parentElement, string childElement)
    {
        var childHandle = await parentElement.WaitForSelectorAsync(childElement);
        await childHandle.ClickAsync();
    }

    protected async Task ClearInput(string selector)
    {
        await page.FillAsync(selector, "");
    }
}