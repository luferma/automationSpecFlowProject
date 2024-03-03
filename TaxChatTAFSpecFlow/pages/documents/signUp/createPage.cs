using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.signUp
{
    class CreatePage : SignUpPage
    {
        By nickNameField = By.Id("name_nick");        
        By phoneField = By.Id("phone");
        By mailingAddressField = By.Id("mailing_address");
        By mailingAddress2Field = By.Id("mailing_address_2");
        By stateField = By.Id("state_id");
        string stateXpath = "//select[@id='state_id']/option[contains(text(),'{0}')]";
        By cityField = By.Id("city");
        By zipCodeField = By.Id("zip_code");
        By passwordField = By.Id("password");
        By confirmPasswordField = By.Id("confirmPassword");
        By hearAboutUsSelect = By.Name("name_nick");
        string hearAboutUsXpath = "//select[@name='InputSelect']/option[contains(text(),'{0}')]";

        By aditionalQuestions1 = By.Id("input-2-No");
        By aditionalQuestions2 = By.Id("input-3-No");
        By aditionalQuestions3 = By.Id("input-4-No");
        By aditionalQuestions4 = By.Id("input-5-No");
        By aditionalQuestions5 = By.Id("input-6-No");
        By aditionalQuestions6 = By.Id("input-7-No");
        By aditionalQuestions7 = By.Id("input-8-No");
        By dateOfBirthField = By.XPath("//input[@placeholder='Date of birth']");
        By countryList = By.Id("country");
        By stateFieldList = By.Id("mailing_state_id");
        By textStateForeign = By.Id("foreign_mailing_state");
        By additionLConsentsTitle = By.XPath("//h1[@class='text-title']");
        By howDidYouHearAboutText = By.Id("how_do_you_hear_about_text");
        By howDidYouHearAboutList = By.XPath("//select[@name='InputSelect']");

        public CreatePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void typeNickName(string nickName)
        {
            IWebElement nickNameFieldElement = driver.FindElement(nickNameField);
            nickNameFieldElement.Clear();
            nickNameFieldElement.SendKeys(nickName);
        }
        
        public void typePhone(string phoneNumber)
        {
            IWebElement phoneFieldElement = driver.FindElement(phoneField);
            phoneFieldElement.Clear();
            phoneFieldElement.SendKeys(phoneNumber);
        }

        public void typeMailingAddress(string mailingAddress)
        {
            IWebElement mailingAddressFieldElement = driver.FindElement(mailingAddressField);
            mailingAddressFieldElement.Clear();
            mailingAddressFieldElement.SendKeys(mailingAddress);
        }

        public void typeMailingAddress2(string mailingAddress2)
        {
            IWebElement mailingAddress2FieldElement = driver.FindElement(mailingAddress2Field);
            mailingAddress2FieldElement.Clear();
            mailingAddress2FieldElement.SendKeys(mailingAddress2);
        }

        public void selectState(string stateToSelect)
        {
            string stateToSelectXpath = string.Format(stateXpath, stateToSelect);
            driver.FindElement(stateField).Click();
            IWebElement stateToSelectElement = driver.FindElement(By.XPath(stateToSelectXpath));
            stateToSelectElement.Click();
        }

        public void typeCity(string cityName)
        {
            IWebElement cityFieldElement = driver.FindElement(cityField);
            cityFieldElement.Clear();
            cityFieldElement.SendKeys(cityName);
        }

        public void typeZipCode(string zipCode)
        {
            IWebElement zipCodeFieldElement = driver.FindElement(zipCodeField);
            zipCodeFieldElement.Clear();
            zipCodeFieldElement.SendKeys(zipCode);
        }

        public void typePassword(string password)
        {
            IWebElement passwordFieldElement = driver.FindElement(passwordField);
            passwordFieldElement.SendKeys(Keys.Control + "a" + Keys.Delete);            
            passwordFieldElement.SendKeys(password);
        }

        public void typePasswordConfirmation(string passwordConfirmation)
        {
            IWebElement confirmPasswordFieldElement = driver.FindElement(confirmPasswordField);
            confirmPasswordFieldElement.SendKeys(Keys.Control + "a" + Keys.Delete);            
            confirmPasswordFieldElement.SendKeys(passwordConfirmation);
        }

        public void selectHearAboutUsOption(string hearAboutUsToSelect)
        {
            string hearAboutUstoSelectXpath = string.Format(hearAboutUsXpath, hearAboutUsToSelect);
            driver.FindElement(hearAboutUsSelect).Click();
            IWebElement hearAboutUstoSelecElement = driver.FindElement(By.XPath(hearAboutUstoSelectXpath));
            hearAboutUstoSelecElement.Click();
        }

        public void selectHowDidYouHearList(string optionSelect)
        {
            scrollMoveElementJavaScript(howDidYouHearAboutList);
            selectFromList(howDidYouHearAboutList, optionSelect);
        }

        public void typeHowDidYouHearText(string text)
        {
            IWebElement passwordFieldElement = driver.FindElement(howDidYouHearAboutText);
            passwordFieldElement.SendKeys(Keys.Control + "a" + Keys.Delete);
            passwordFieldElement.SendKeys(text);
        }

        public void selectAnswerAdditionalQuestions(string numberQuestion, string answerQuestion)
        {
            string idQuestion = "input";
            string completeId = string.Concat(idQuestion, "-"+ numberQuestion + "-"+ answerQuestion);
            driver.FindElement(By.Id(completeId)).Click();
        }

        public void assignValueTOElement(By elementToAssign)
        {
            IWebElement elementAssign = driver.FindElement(elementToAssign);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value', '17/08/1996');", elementAssign);
        }

        public void selectCountryList(string countryToSelect)
        {
            selectFromList(countryList, countryToSelect);
        }

        public void selectStateList(string stateToSelect)
        {
            waitTillElementIsDisplayed(stateField);
            selectFromList(stateField, stateToSelect);
        }

        public void typeForeignState(string state)
        {
            IWebElement phoneFieldElement = driver.FindElement(textStateForeign);            
            phoneFieldElement.SendKeys(state);
        }

        public void waitTillAdditionalConsentTitle()
        {
            waitTillElementIsDisplayed(additionLConsentsTitle);           
        }
    }
}
