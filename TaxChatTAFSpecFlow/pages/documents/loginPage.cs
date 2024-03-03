using OpenQA.Selenium;
using TaxChatTAF.utils;

namespace TaxChatTAF.pages.documents
{
    class LoginPage : SeleniumActions { 
        By emailField = By.Id("email");
        By passwordField = By.Id("password");
        By signUpButton = By.XPath("//button[contains(text(), 'Sign Up Now')]");
        By submitButton = By.XPath("//button[contains(text(), 'Submit')]");

        public LoginPage(IWebDriver driver){
            this.driver = driver;
        }

        public void TypeEmail(string email){
            IWebElement emailFieldElement = driver.FindElement(emailField);
            emailFieldElement.Clear();
            emailFieldElement.SendKeys(email);
        }

         public void TypePassword(string password){
            IWebElement passwordFieldElement = driver.FindElement(passwordField);
            passwordFieldElement.Clear();
            passwordFieldElement.SendKeys(password);
        }

        public void clickOnSubmitButton(){
            driver.FindElement(submitButton).Click();
        }

        public void clickOnSignUpButton(){
            driver.FindElement(signUpButton).Click();
        }
    }
}