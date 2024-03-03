using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.signUp
{
    class TermsOfUse : SignUpPage
    {
        By termsOfServiceContiner = By.CssSelector(".terms-of-service-block");
        By acceptTermsRadioButton = By.Id("input-4-I accept");        
        By declineTermsRadioButton = By.Id("input-4-I decline");
        By containerValidation = By.XPath("//div[@class='popup--container null']");
        By buttonContainer = By.XPath("//div[@class='popup--container null']//button[@type='submit']");

        public TermsOfUse(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void acceptTerms()
        {
            waitTillElementIsClickable(termsOfServiceContiner);
            scrollDownOnAElement(termsOfServiceContiner);            
            scrollMoveElementJavaScript(acceptTermsRadioButton);            
            selectRadioButton(acceptTermsRadioButton);
        }

        public void declineTerms()
        {
            scrollDownOnAElement(termsOfServiceContiner);
            scrollMoveElement(declineTermsRadioButton);
            selectRadioButton(declineTermsRadioButton);
        }

        public void dialogDeclineTerms()
        {
            waitTillElementIsDisplayedVoid(containerValidation);
            clickButton(buttonContainer);
        }
    }
}
