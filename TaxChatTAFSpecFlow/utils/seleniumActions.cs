using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Google.Apis.Gmail.v1.Data;
using System.Threading;
using System.IO;
using TaxChatTAFSpecFlow.utils;
using System.Globalization;

namespace TaxChatTAF.utils {
    public class SeleniumActions{
        string monthSelectXpath = "//select[@name='month']/option[contains(text(), '{0}')]";
        string yearSelectXpath = "//select[@name='year']/option[contains(text(), '{0}')]";
        string dayXpath = "//div[@class='DayPicker-Day' and normalize-space(text()[1])='{0}']";
        By monthSelectOld = By.Name("month");
        By monthSelect = By.XPath("//select[@name='month']");
        By yearSelect = By.Name("year");
        By dateOfBirthField = By.XPath("//input[@placeholder='Date of birth']");
        By dateOfBirthFieldSpouse = By.XPath("(//input[@placeholder='Date of birth'])[2]");
        string answerQuestionXpath = "//h4[contains(text(), '{0}')]/following-sibling::div/input[@value='{1}']";

        string answerQuestionXpathDependent = "(//h4[contains(text(), 'Dependent')]/following-sibling::div/div/input[@value='{1}'])[{0}]";
        string dependentFirstNameXpath = "//label[@for='name_first_{0}']//div[contains(@class,'group')]//input";
        string dependentLastNameXpath = "//label[@for='name_last_{0}']//div[contains(@class,'group')]//input";
        string ssnXpath = "//label[@for='ssn_{0}']//div[contains(@class,'group')]//input";
        string checkSsnXpath = "//input[@id='no_ssn_{0}']";
        string dateOfBirthDependent = "//label[@for='dob_{0}']//div[contains(@class,'PickerInput')]//input";
        string answerSubQuestionsProfile = "//p[contains(text(), '{0}')]/following-sibling::div/input[@value='{1}']";
        string inputSubQuestionsProfileXpath = "//p[contains(text(), '{0}')]/following-sibling::label/input";
        string dateOfBirthDependentAssign = "(//input[@placeholder='Date of birth'])[{0}]";

        By monthSelectList = By.XPath("//select[@name='month']");        
        By yearSelectList = By.XPath("//select[@name='year']");
        By dateOfBirthFieldDependent = By.XPath("(//input[@placeholder='Date of birth'])[{0}]");
        By calendar = By.ClassName("DayPicker-Months");
        By calendarOpen = By.XPath("//div[@class='DayPicker-Months']");

        public IWebDriver driver;

        public IWebElement waitTillElementIsDisplayed(By elementLocator, int time=70){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            return element;
        }

        public IWebElement waitTillElementIsDisplayedWithTime(By elementLocator, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            return element;
        }

        public Boolean waitTillElementIsNotDisplayed(By elementLocator, int time = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            Boolean isVisible = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(elementLocator));
            return isVisible;
        }

        public IWebElement waitTillElementIsClickable(By elementLocator, int time=70){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            return element;
        }

        public IWebElement waitTillElementIsClickableWithTime(By elementLocator, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            return element;
        }

        public void scrollDownOnAElement(By elementToScrollLocator){
            Actions actions = new Actions(driver);
            driver.FindElement(elementToScrollLocator).Click();
            actions.KeyDown(Keys.Control).SendKeys(Keys.End).Perform();            
        }

        public IWebElement getEnableElement(By elementLocator){
            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(elementLocator));
            IWebElement enabledElement = null;
            foreach (IWebElement element in elements)
            {
                if (element.Enabled)
                {
                    enabledElement = element;                    
                }
            }
            return enabledElement;
        }

        public void waitTillPageIsLoaded(){
            new WebDriverWait(driver, TimeSpan.FromSeconds(200)).Until(
                d => ((IJavaScriptExecutor) d).ExecuteScript("return document.readyState").Equals("complete")
            );
        }

        public static void waitForLoadWithTime(IWebDriver driver, int timeoutSec = 5)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public void selectRadioButton(By elementLocator) {
            IWebElement radioButtonLocator = waitTillElementIsClickable(elementLocator);
            try
            {
                radioButtonLocator.Click();
            }
            catch 
            {
                radioButtonLocator.Click();
            }
        }

        public void openMailBrowserPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            List<string> listWindow = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(listWindow[1]);
            driver.Navigate().GoToUrl("https://mail.google.com/");
        }

        public void waitTillElementIsDisplayedVoid(By elementLocator, int time = 35)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));          
        }

        public void clickJavaScriptExecutor(By elementLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement elementClick = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", elementClick);           
        }

        public void scrollMoveElement(By elementToMove)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement elementMove = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToMove));
            Actions actions = new Actions(driver);            
            actions.MoveToElement(elementMove).Build().Perform();
        }

        public void changeTab(int tab)
        {
            List<string> listWindow = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(listWindow[tab]);
        }

        public void changeTabAndRefresh(int tab)
        {
            List<string> listWindow = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(listWindow[tab]);
            driver.Navigate().Refresh();
        }

        public string getTextElement(By element)
        {
            IWebElement elementGetText = driver.FindElement(element);
            return elementGetText.Text;
        }

        public string getValueElement(By element)
        {
            IWebElement elementGetValue = driver.FindElement(element);
            return elementGetValue.GetAttribute("value").Trim();
        }

        public void sendValue(string value, By element)
        {
            IWebElement elementSendValue = driver.FindElement(element);            
            elementSendValue.SendKeys(Keys.Control + "a" + Keys.Delete);
            elementSendValue.SendKeys(value);
        }

        public void selectDatePickerMonth(string monthToSelect)
        {
            System.Threading.Thread.Sleep(700);
            string monthToSelectXpath = string.Format(monthSelectXpath, monthToSelect);
            driver.FindElement(monthSelect).Click();
            IWebElement monthToSelectElement = driver.FindElement(By.XPath(monthToSelectXpath));            
            try
            {
                monthToSelectElement.Click();
            }
            catch (StaleElementReferenceException)
            {
                monthToSelectElement.Click();
            }            
        }

        public void selectDatePickerMonthList(string textSelect)
        {
            System.Threading.Thread.Sleep(300);
            IWebElement elementList = driver.FindElement(monthSelectList);
            var selectElement = new SelectElement(elementList);
            selectElement.SelectByText(textSelect);
        }

        public void selectDatePickerYear(string yearToSelect)
        {
            System.Threading.Thread.Sleep(700);
            string yearToSelectXpath = string.Format(yearSelectXpath, yearToSelect);
            driver.FindElement(yearSelect).Click();
            IWebElement yearToSelectElement = driver.FindElement(By.XPath(yearToSelectXpath));            
            try
            {
                yearToSelectElement.Click();
            }
            catch (StaleElementReferenceException)
            {
                yearToSelectElement.Click();
            }
        }

        public void selectDatePickerYearList(string textSelect)
        {
            System.Threading.Thread.Sleep(300);
            IWebElement elementList = driver.FindElement(yearSelectList);
            var selectElement = new SelectElement(elementList);
            selectElement.SelectByText(textSelect);
        }
                
        public void selectDatePickerDay(string dayToSelect)
        {
            System.Threading.Thread.Sleep(700);
            string dayToSelectXpath = string.Format(dayXpath, dayToSelect);
            IWebElement dayToSelectElement;
            dayToSelectElement = driver.FindElement(By.XPath(dayToSelectXpath));
            try
            {                                
                dayToSelectElement.Click();                
            }
            catch (StaleElementReferenceException)
            {                                
                dayToSelectElement.Click();                                
            }
        }
        
        public void selectDateOfBirth(string dateOfBirth)
        {
            IWebElement datePicker = driver.FindElement(dateOfBirthField);
            datePicker.Click();            
            string[] separateDate = dateOfBirth.Split(',');
            waitTillElementIsDisplayed(calendarOpen);
            selectDatePickerMonthList(separateDate[0]);
            selectDatePickerYearList(separateDate[2]);
            selectDatePickerDay(separateDate[1]);            
        }
        
        public void selectDateOfBirthSpouse(string dateOfBirth)
        {
            IWebElement datePicker = driver.FindElement(dateOfBirthFieldSpouse);
            datePicker.Click();
            string[] separateDate = dateOfBirth.Split(',');
            selectDatePickerMonthList(separateDate[0]);
            selectDatePickerYearList(separateDate[2]);
            selectDatePickerDay(separateDate[1]);
        }

        public void selectDateOfBirthDependent(string dateOfBirth, string questionNumber)
        {
            string dateOfBirthXpath = string.Format(dateOfBirthDependent, questionNumber);
            By dateOfBirthBy = By.XPath(dateOfBirthXpath);
            IWebElement dateOfBirthElement = driver.FindElement(dateOfBirthBy);
            dateOfBirthElement.Click();
            string[] separateDate = dateOfBirth.Split(',');            
            selectDatePickerMonthList(separateDate[0]);            
            selectDatePickerYearList(separateDate[2]);
            selectDatePickerDay(separateDate[1]);
        }

        public void selectDateOfBirthOld(string dateOfBirth)
        {
            IWebElement datePicker = driver.FindElement(dateOfBirthField);
            datePicker.Click();
            string[] separateDate = dateOfBirth.Split(',');
            selectDatePickerMonth(separateDate[0]);
            selectDatePickerYear(separateDate[2]);
            selectDatePickerDay(separateDate[1]);
        }

        public void AssignDateOfBirthDependent(string dateOfBirth, string numberDependent)
        {
            string dateOfBirthXpath = string.Format(dateOfBirthDependentAssign, numberDependent);
            By dateOfBirthBy = By.XPath(dateOfBirthXpath);
            IWebElement elementAssign = driver.FindElement(dateOfBirthBy);
            elementAssign.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value', '" + dateOfBirth + "');", elementAssign);
        }

        public void clickButton(By elementClick)
        {
            IWebElement buttonClick = waitTillElementIsClickable(elementClick);
            buttonClick.Click();
        }

        public void sendTabKey(By elementTab)
        {
            IWebElement elementTabKey = driver.FindElement(elementTab);
            elementTabKey.SendKeys(Keys.Tab);
        }
        
        public void answerQuestion(string questionToAnswer, string valueAnswer)
        {
            string answerCompleteXpath = string.Format(answerQuestionXpath, questionToAnswer, valueAnswer);
            By aswerCompleteElement = By.XPath(answerCompleteXpath);
            selectRadioButton(aswerCompleteElement);
        }

        public void answerQuestionDependent(string questionPosition, string valueAnswer)
        {
            string answerCompleteXpath = string.Format(answerQuestionXpathDependent, questionPosition, valueAnswer);
            By aswerCompleteElement = By.XPath(answerCompleteXpath);
            selectRadioButton(aswerCompleteElement);
        }

        public void answerQuestionXpathSubQuestionsProfile(string questionToAnswer, string valueAnswer)
        {
            string answerCompleteXpath = string.Format(answerSubQuestionsProfile, questionToAnswer, valueAnswer);
            By aswerCompleteElement = By.XPath(answerCompleteXpath);
            selectRadioButton(aswerCompleteElement);
        }
        
        public void sendKeyDependentFirstName(string questionNumber, string value)
        {
            string dependentFirstName = string.Format(dependentFirstNameXpath, questionNumber);
            By dependentFirstNameBy = By.XPath(dependentFirstName);
            IWebElement dependentFirstNameElement = driver.FindElement(dependentFirstNameBy);
            dependentFirstNameElement.Clear();
            dependentFirstNameElement.SendKeys(value);
        }

        public void sendKeyDependentLastName(string questionNumber, string value)
        {
            string dependentLastName = string.Format(dependentLastNameXpath, questionNumber);
            By dependentLastNameBy = By.XPath(dependentLastName);
            IWebElement dependentLastNameElement = driver.FindElement(dependentLastNameBy);
            dependentLastNameElement.Clear();
            dependentLastNameElement.SendKeys(value);
        }

        public void sendKeyDependentSsn(string questionNumber, string value, string sendTab)
        {
            string dependentSsn = string.Format(ssnXpath, questionNumber);
            By dependentSsnBy = By.XPath(dependentSsn);
            IWebElement dependentSsnElement = driver.FindElement(dependentSsnBy);
            dependentSsnElement.Clear();
            dependentSsnElement.SendKeys(value);
            if(String.Equals(sendTab, "Yes"))
            {
                sendTabKey(dependentSsnBy);
            }
        }

        public void sendKeyDependentCheckSsn(string questionNumber, string sendTab)
        {
            string dependentCheckSsn = string.Format(checkSsnXpath, questionNumber);
            By dependentCheckSsnBy = By.XPath(dependentCheckSsn);
            IWebElement dependentCheckSsnElement = driver.FindElement(dependentCheckSsnBy);
            dependentCheckSsnElement.Click();
            if (String.Equals(sendTab, "Yes"))
            {
                sendTabKey(dependentCheckSsnBy);
            }
        }

        public void inputSubQuestionsProfile(string questionToAnswer, string value, string sendTab)
        {
            string inputSubQuestionsXpath = string.Format(inputSubQuestionsProfileXpath, questionToAnswer);
            By aswerCompleteElement = By.XPath(inputSubQuestionsXpath);
            sendValue(value, aswerCompleteElement);
            if (String.Equals(sendTab, "Yes"))
            {
                sendTabKey(aswerCompleteElement);
            }
        }

        public string getTextInputSubQuestion(string questionToGetText)
        {
            string inputSubQuestionsXpath = string.Format(inputSubQuestionsProfileXpath, questionToGetText);
            By aswerCompleteElement = By.XPath(inputSubQuestionsXpath);
            return getTextElement(aswerCompleteElement);
        }

        public string getValueInputSubQuestion(string questionToGetValue)
        {
            string inputSubQuestionsXpath = string.Format(inputSubQuestionsProfileXpath, questionToGetValue);
            By aswerCompleteElement = By.XPath(inputSubQuestionsXpath);
            return getValueElement(aswerCompleteElement);
        }

        
        public void comparateElementTest(By elementLocator, string stringComparate)
        {
            string testElement = getTextElement(elementLocator);
            StringAssert.Contains(stringComparate, testElement);
        }

        public void scrollMoveElementJavaScript(By elementToMove)
        {           
            IWebElement elementMove = driver.FindElement(elementToMove);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", elementMove);
        }

        public void assignValueTOElement(By elementToAssign, string date)
        {
            IWebElement elementAssign = driver.FindElement(elementToAssign);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value', '"+ date + "');", elementAssign);
        }

        public void assignValueTOElementPathFile(By elementToAssign, string date)
        {
            IWebElement elementAssign = driver.FindElement(elementToAssign);            
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value', '" + date.Replace("\\", "\\\\") + "');", elementAssign);
        }

        public void assignTextTOElement(By elementToAssign, string date)
        {
            IWebElement elementAssign = driver.FindElement(elementToAssign);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('text', '" + date + "');", elementAssign);
        }

        public void assignTextTOElementPathFile(By elementToAssign, string date)
        {
            IWebElement elementAssign = driver.FindElement(elementToAssign);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('text', '" + date.Replace("\\", "\\\\") + "');", elementAssign);
        }

        public void cleanValue(string questionToAnswer)
        {
            string inputSubQuestionsXpath = string.Format(inputSubQuestionsProfileXpath, questionToAnswer);
            By aswerCompleteElement = By.XPath(inputSubQuestionsXpath);
            IWebElement elementSendValue = driver.FindElement(aswerCompleteElement);
            elementSendValue.SendKeys(Keys.Control + "a" + Keys.Delete);
            sendTabKey(aswerCompleteElement);
        }

        public void selectFromList(By elementToSelect, string textSelect)
        {            
            IWebElement elementList = driver.FindElement(elementToSelect);
            var selectElement = new SelectElement(elementList);
            selectElement.SelectByText(textSelect);            
        }

        public void assignDateOfBirthElement(string date)
        {
            IWebElement elementAssign = driver.FindElement(dateOfBirthField);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('text', '" + date + "');", elementAssign);            
        }

        public string getAttributeElement(By element, string attribute)
        {
            IWebElement elementGetValue = driver.FindElement(element);
            return elementGetValue.GetAttribute(attribute).Trim();
        }

        public Boolean isDisplayed(By elementLocator)
        {
            Boolean answer = false;
            try
            {
                IWebElement element = driver.FindElement(elementLocator);
                if (element.Displayed)
                {
                    answer = true;
                }
            }
            catch(NoSuchElementException)
            {
                answer = false;
            }           
            return answer;
        }

        public void selectFromListValue(By elementToSelect, string textSelect)
        {
            IWebElement elementList = driver.FindElement(elementToSelect);
            var selectElement = new SelectElement(elementList);
            selectElement.SelectByValue(textSelect);
        }
    }
}