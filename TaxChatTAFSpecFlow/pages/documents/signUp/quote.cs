using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.signUp
{
    class Quote : SignUpPage
    {
        By quote = By.ClassName("quote--title");

        public Quote(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string getQuoteValue()
        {
            IWebElement quoteElement = waitTillElementIsDisplayed(quote);
            return quoteElement.Text;
        }
    }
}
