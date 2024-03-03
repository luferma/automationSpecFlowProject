using NUnit.Framework;
using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.signUp
{
    class VerifyName : SignUpPage
    {
        By firtsNameField = By.XPath("//input[@id='name_first']");
        By lastNameField = By.XPath("//input[@id='name_last']");
        By codeReferralCheck = By.Id("promo_code_check");
        By codeReferralText = By.Id("promo_code");
        By invaldCode = By.XPath("//div[@class='error-notification']//p");
        public VerifyName(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void typeFirstName(string firstName)
        {
            IWebElement firstNameFieldElement = driver.FindElement(firtsNameField);
            firstNameFieldElement.Clear();
            firstNameFieldElement.SendKeys(firstName);
            firstNameFieldElement.SendKeys(firstName);
        }

        public void typeLastName(string lastName)
        {
            IWebElement lastNameFieldElement = driver.FindElement(lastNameField);
            lastNameFieldElement.Clear();
            lastNameFieldElement.SendKeys(lastName);
        }

        public void typeReferralCode(string referralCode)
        {
            IWebElement lastNameFieldElement = driver.FindElement(codeReferralText);
            lastNameFieldElement.Clear();
            lastNameFieldElement.SendKeys(referralCode);
        }

        public void denyReferral()
        {
            clickButton(codeReferralCheck);
        }

        public void validateReferralCode()
        {
            string textInvalidCode = getTextElement(invaldCode);
            Assert.AreEqual(textInvalidCode, configConstants.INVALID_REFERRAL_CODE);
        }
    }
}
