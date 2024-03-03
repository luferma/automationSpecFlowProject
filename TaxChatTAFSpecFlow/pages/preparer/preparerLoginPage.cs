using TaxChatTAF.utils;
using OpenQA.Selenium;

namespace TaxChatTAF.pages.preparer
{
    class PreparerLoginPage : SeleniumActions
    {
        By preparerIDField = By.XPath("//input[@ng-model='user.email']");
        By preparerPasswordField = By.XPath("//input[@ng-model='user.password']");
        By signInButton = By.XPath("//button[contains(text(), 'Sign In')]");

        public PreparerLoginPage(IWebDriver driver) {
            this.driver = driver;         
        }

        public void waitTillIdPreparerIsVisible()
        {
            waitTillElementIsDisplayedWithTime(preparerIDField, 90);
        }

        public void typePreparerID(string preparerID) 
        {
            IWebElement preparerIDElement = driver.FindElement(preparerIDField);
            preparerIDElement.SendKeys(Keys.Control + "a" + Keys.Delete);
            preparerIDElement.Clear();
            preparerIDElement.SendKeys(preparerID);            
        }
        
        public void typePreparerPassword(string preparerPassword)
        {
            IWebElement preparerPasswordElement = driver.FindElement(preparerPasswordField);
            preparerPasswordElement.SendKeys(Keys.Control + "a" + Keys.Delete);
            preparerPasswordElement.Clear();
            preparerPasswordElement.SendKeys(preparerPassword);            
        }

        public void clickOnSignInButton()
        {
            IWebElement signInButtonClick = waitTillElementIsClickable(signInButton);
            signInButtonClick.Click();
        }


    }
}
