using OpenQA.Selenium;
using TaxChatTAF.utils;

namespace TaxChatTAF.pages.documents.signUp
{
    public class SignUpPage : SeleniumActions
    {
        By nextButton = By.XPath("//button[text()='Next']");
        By nextButtonId = By.Id("submit");        
        By quote = By.ClassName("quote--title");
        By tellUsAbout = By.XPath("//h1[contains(text(),'Tell us about your')]");

        public void clickOnNextButton()
        {                        
            IWebElement nextButtonElement = waitTillElementIsClickable(nextButton);
            nextButtonElement.Click();
            waitTillPageIsLoaded();
        }
       
        public void waitTillQuoteIsDisplayedVoid()
        {
            waitTillElementIsDisplayedVoid(quote, 50);           
        }

        public void waitTillTellUsMessageDisplayedVoid()
        {
            waitTillElementIsDisplayedVoid(tellUsAbout);
        }

        public void moveToNextButton()
        {
            scrollMoveElementJavaScript(nextButton);
            waitTillElementIsClickable(nextButton);
        }
    }
}