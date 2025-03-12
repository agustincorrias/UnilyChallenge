using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using UnilyChallenge.Pages;
using UnilyChallenge.Pages.Common;

namespace UnilyChallenge.Tests;

[Parallelizable(ParallelScope.Children)]
[TestFixture, Description("Home Page Tests")]
[AllureNUnit]
[AllureParentSuite("Home Page Tests")]
public class HomeTests : BaseHomeTest
{
    [Test, Description("Verify Subscription in home page")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Agustin Corrias")]
    [AllureTag("HomePage")]
    public async Task HomePage_VerifySubscription()
    {
        string expectedSubscriptionText = "subscription";
        string expectedEmail = "acorrias@unily.com";
        string expectedSuccessMessage = "You have been successfully subscribed!";

        HomePage homePage = await SetUpForHomePageTest();
        await homePage.ScrollToBottom();
        FooterPage footerPage = homePage.ReturnFooterPage();
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