using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using UnilyChallenge.Pages;
using UnilyChallenge.Pages.Common;

namespace UnilyChallenge.Tests;

[Parallelizable(ParallelScope.Children)]
[TestFixture, Description("Cart Page Tests")]
[AllureNUnit]
[AllureParentSuite("Cart Page Tests")]
public class CartTests : BaseCartTests
{
    [Test, Description("Verify Subscription in Cart page")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Agustin Corrias")]
    [AllureTag("CartPage")]
    public async Task CartPage_VerifySubscription()
    {
        string expectedSubscriptionText = "subscription";
        string expectedEmail = "acorrias@unily.com";
        string expectedSuccessMessage = "You have been successfully subscribed!";

        CartPage cartPage = await SetUpForCartPageTest();
        await cartPage.ScrollToBottom();
        FooterPage footerPage = cartPage.ReturnFooterPage();
        await footerPage.VerifySubscriptionTextIsVisible();
        string subscriptionText = await footerPage.GetSubscriptionText();
        await footerPage.CompleteSubscriptionFormWithEmail(expectedEmail);
        await footerPage.ClickOnSubscriptionButton();
        bool isSuccessMessageVisible = await footerPage.IsSuccessMessageVisible();
        string successMessage = await footerPage.GetSuccessMessageText();
        Assert.Multiple(() =>
        {
            Assert.That(subscriptionText, Is.Not.Null.And.Not.Empty, "Subscription text is not visible");
            Assert.That(subscriptionText.ToLower(), Is.EqualTo(expectedSubscriptionText), "Subscription text is not correct");
            Assert.That(isSuccessMessageVisible, Is.True, "Success message is not visible");
            Assert.That(successMessage.ToLower(), Is.EqualTo(expectedSuccessMessage.ToLower()), "Success message is not correct");
        });
    }
}