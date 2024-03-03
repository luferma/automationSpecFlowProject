using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TaxChatTAFSpecFlow.utils;

namespace TaxChatTAF.pages.documents.signUp
{
    public class ElegibilityPage : SignUpPage
    {
        By emailField = By.Id("email");
        By emailConfirmationField = By.Id("confirmation");
        By registeredUser = By.XPath("//div[contains(@class, 'error')]");        

        public ElegibilityPage(IWebDriver driver)
        {
            this.driver = driver;
        }
      
        public void typeEmail(string email)
        {
            IWebElement emailFieldElement = driver.FindElement(emailField);
            emailFieldElement.Clear();
            emailFieldElement.SendKeys(email);
        }

        public void typeEmailConfirmation(string emailConfirmation)
        {
            IWebElement emailConfirmationFieldElement = driver.FindElement(emailConfirmationField);
            emailConfirmationFieldElement.Clear();
            emailConfirmationFieldElement.SendKeys(emailConfirmation);
        }
        
        public string validateRegisteredUser(IWebDriver driver, string emailPattern)
        {
            RandomEmail randomEmailObject = new RandomEmail();
            string nextSequenceEmail = randomEmailObject.GenerateRandomString(3);
            string[] emailPatternList = emailPattern.Split("@");
            string monthDay = DateTime.Now.ToString("MM-dd");
            string[] monthDayList = monthDay.Split("-");
            string month = monthDayList[0];
            string day = monthDayList[1];

            string email = emailPatternList[0]+ month + day + nextSequenceEmail + "@" + emailPatternList[1];            
            typeEmail(email);
            typeEmailConfirmation(email);
            clickOnNextButton();

            bool isNotRegisteredUserVal = true;
            while (isNotRegisteredUserVal)
            {
                try
                {
                    IWebElement registeredUserSearch = waitTillElementIsDisplayedWithTime(registeredUser, 3);
                    string textError = registeredUserSearch.Text;
                
                    if (textError.Contains("already registered"))
                    {
                        driver.Navigate().Refresh();
                        nextSequenceEmail = randomEmailObject.GenerateRandomString(3);
                        email = emailPatternList[0] + nextSequenceEmail + "@" + emailPatternList[1];                        
                        typeEmail(email);                    
                        typeEmailConfirmation(email);                        
                        clickOnNextButton();                    

                    }
                    else
                    {
                        isNotRegisteredUserVal = false;
                    }
                }
                catch (Exception)
                {
                    isNotRegisteredUserVal = false;
                }
            }
            return email;
        }

    }
}
