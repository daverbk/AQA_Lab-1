using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AllureExtensionsFluentAssertionsHomework.Tests
{
    [AllureNUnit]
    [AllureStory]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureTag("E2E Critical path")]
    [AllureLabel("Priority", "High")]
    [AllureSuite("E2E SauceDemo")]
    [AllureOwner("David Ryabko")]
    public class EndToEndTest : BaseTest
    {
        [Test]
        [Category("EndToEnd")]
        public void EndToEnd_StandardUser()
        {
            StandardUserSteps.InsertUserNameAndPassword("standard_user", "secret_sauce");
            StandardUserSteps.CheckProductsPageOpened();
            
            StandardUserSteps.SelectItemAndCheckButtonChange();
            
            StandardUserSteps.GoToCartCheckIfOpens();
            
            StandardUserSteps.GoToCheckoutStepOneCheckIfOpens();
            StandardUserSteps.InsertPostInformation("Dave", "Davidson", "28031");
            
            StandardUserSteps.GoToCheckoutStepTwoCheckIfOpens();
            
            StandardUserSteps.GoToCheckoutCompleteCheckIfOpens();
            
            StandardUserSteps.GoBackToProductsPageCheckIfOpens();
        }
    }
}
