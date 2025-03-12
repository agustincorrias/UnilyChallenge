using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using UnilyChallenge.Utils;

namespace UnilyChallenge.Pages.Common;
public class FooterPage : BaseOperations
{

    private readonly string _subscriptionText = "//footer[@id='footer']//h2";
    private readonly string _subscriptionEmailInput = "#susbscribe_email";
    private readonly string _subscriptionButton = "//button[@id='subscribe']";
    private readonly string _successMessageText = "//div[@class='alert-success alert']";

    public FooterPage(IPage page) : base(page)
    {
        base.page = page;
    }

    [AllureStep("Verify Subscription in home page")]
    public async Task VerifySubscriptionTextIsVisible()
    {
        await EnsureElementIsVisible(_subscriptionText);
    }

    [AllureStep("Get Subscription Text")]
    public async Task<string> GetSubscriptionText()
    {
        return await GetInnerText(_subscriptionText);
    }

    [AllureStep("Complete Subscription Form With Email {email}")]
    public async Task CompleteSubscriptionFormWithEmail(string email)
    {
        await TypeText(_subscriptionEmailInput, email);
    }

    [AllureStep("Click on Subscription Button")]
    public async Task ClickOnSubscriptionButton()
    {
        await ClickOnElement(_subscriptionButton);
    }

    [AllureStep("Verify Success Message is visible")]
    public async Task<bool> IsSuccessMessageVisible()
    {
        return await IsElementVisible(_successMessageText);
    }

    [AllureStep("Get Success Message Text")]
    public async Task<string> GetSuccessMessageText()
    {
        return await GetInnerText(_successMessageText);
    }
}