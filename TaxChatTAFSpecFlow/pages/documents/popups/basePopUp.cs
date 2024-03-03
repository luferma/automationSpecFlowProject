using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TaxChatTAF.utils;

namespace TaxChatTAF.pages.documents.popups
{
    public class BasePopUp : SeleniumActions{
        By cancelButton = By.Id("Cancel");
        By doneButton = By.Id("Done");
        By numberOfPropertiesField = By.Name("number");
        By numberOfPropertiesFieldXpath = By.XPath("//input[@name='number']");
        string checkBoxXpath = "//input/following-sibling::label[contains(text(), '{0}')]";        
        By yesRadioButton = By.XPath("//input[@value='Yes']");
        By noRadioButton = By.XPath("//input[@value='No']");
        
        string xpathDoneButton = "//div[contains(@id,'{0}')]//button[@id='Done']";
        string xpathDoneButtonAria = "//div[contains(@aria-label,'{0}')]//button[@id='Done']";

        public void clickOnDoneButton(){
            IWebElement doneButtonElement = getEnableElement(doneButton);           
            doneButtonElement.Click();
        }
        public void clickOnCancelButton(){
            IWebElement cancelButtonElement = waitTillElementIsClickable(cancelButton);
            cancelButtonElement.Click();
        }
        public void selectCheckBoxByText(string text){
            string checkBoxCompleteXpath = string.Format(checkBoxXpath, text);
            driver.FindElement(By.XPath(checkBoxCompleteXpath)).Click();
        }
        public void typeInputnumber(string numberOfProperties){
            IWebElement numberOfPropertiesElement = driver.FindElement(numberOfPropertiesField);
            numberOfPropertiesElement.Clear();
            numberOfPropertiesElement.SendKeys(numberOfProperties);
        } 

        public void selectYesOption(){
            IWebElement yesRadioButtonElement = waitTillElementIsClickable(yesRadioButton);
            yesRadioButtonElement.Click();
        }
        public void selectNoOption(){
            IWebElement noRadioButtonElement = waitTillElementIsClickable(noRadioButton);
            noRadioButtonElement.Click();
        }

        public void clickJavaScriptExecutorDoneButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement elementClick = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(doneButton));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", elementClick);
        }

        public void clickOnDoneButtonParameter(string tile)
        {
            string xpathDoneButtonComplete = string.Format(xpathDoneButton, tile);
            IWebElement doneButtonElement = waitTillElementIsClickable(By.XPath(xpathDoneButtonComplete));
            doneButtonElement.Click();
        }

        public void clickOnDoneButtonParameterAria(string tile)
        {
            string xpathDoneButtonComplete = string.Format(xpathDoneButtonAria, tile);
            IWebElement doneButtonElement = getEnableElement(By.XPath(xpathDoneButtonComplete));
            doneButtonElement.Click();
        }
    }
}