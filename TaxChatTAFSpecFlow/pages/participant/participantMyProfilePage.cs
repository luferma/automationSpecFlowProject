using TaxChatTAF.utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using NUnit.Framework;
using TaxChatTAFSpecFlow.utils;
using TechTalk.SpecFlow;
using TaxChatTAF.pages.documents.signUp;
using OpenQA.Selenium.Interactions;
using TaxChatTAFSpecFlow.models;
using System;

namespace TaxChatTAF.pages.participant
{
    class ParticipantMyProfilePage : SeleniumActions
    {      
        By firstName = By.XPath("(//div[@class='Family']//label)[1]//h3");
        By lastName = By.XPath("//div[@class='Family']//label[@for='name_last']//h3");
        By nameNick = By.XPath("//div[@class='Family']//label[@for='name_nick']//input");
        By phone = By.XPath("//div[@class='Family']//label[@for='phone']//input");
        By dob = By.XPath("//div[@class='Family']//label[@for='dob']//input");
        By ssn = By.XPath("//div[@class='Family']//label[@for='SSN']//input");
        By mailingAddress = By.XPath("//div[@class='Family']//label[@for='mailing_address']//input");
        By mailingAddress2 = By.XPath("//div[@class='Family']//label[@for='mailing_address_2']//input");
        By city = By.XPath("//div[@class='Family']//label[@for='city']//input");        
        By zipCode = By.XPath("//div[@class='Family']//label[@for='zipCode']//input");
        By buttonMyFamily = By.XPath("//div[contains(@class,'hide-sm')]//button[@id='edit' and contains(text(),'resume')]");
        string stateXpath = "//select[@id='mailing_state_id']/option[contains(text(),'{0}')]";
        By stateField = By.Id("mailing_state_id");
        By dateSelector = By.CssSelector("div.DayPickerInput > input");
        By dateInput = By.XPath("//div[@class='DayPickerInput']//input");
        By todaysDateContainer = By.ClassName("DayPickerInput");
        By buttonSave = By.XPath("//button[@id='Save']");
        By buttonSaveAboutMe = By.XPath("(//button[@id='Save'])[2]");
        By buttonSaveMyDeductions = By.XPath("(//button[@id='Save'])[3]");
        By buttonSaveMyBankInformation = By.XPath("(//button[@id='Save'])[4]");
        By buttonConfirm = By.Id("confirm");
        By buttonStart = By.XPath("(//div[contains(@class,'hide-sm')]//button[@id='edit' and contains(text(),'start')])[1]");
        By bankCheckMailed = By.Id("refund-mail-check");
        By checkPayOnline = By.Id("balance-mail-check");
        By profileTab = By.XPath("//div[contains(@class,'wrapper')]//ul//a[contains(@href,'profile')]");
        By homeTab = By.XPath("//div[contains(@class,'wrapper')]//ul//a[contains(@href,'home')]");
        By buttonSubmit = By.XPath("//button[@id='submit']");

        By spouseFirstName = By.XPath("//label[@for='spouse_name_first']//div[contains(@class,'group')]//input");
        By spouseLastName = By.XPath("//label[@for='spouse_name_last']//div[contains(@class,'group')]//input");
        By spouseSsn = By.XPath("//label[@for='spouse_ssn']//input");
        By checkSpouseSsn = By.XPath("//input[@id='spouse_no_ssn']");
        By emailSpouse = By.XPath("//label[@for='spouse_email']//div[contains(@class,'group')]//input");
        By emailConfirmationSpouse = By.XPath("//label[@for='spouse_confirmation_email']//div[contains(@class,'group')]//input");
        By buttonAddSpouse = By.XPath("//button[contains(@class,'btn--add-spouse')]");
        By buttonAddDependent = By.XPath("//button[contains(@class,'btn--add-dependent')]");

        By dateMove = By.XPath("//div[@class='dependent-question']//div[contains(@class,'DayPicker')]//input");
        By directDepositBankAccount = By.Id("refund-direct-deposit");
        By refundCheking = By.Id("refund-checking");
        By refundSavings = By.Id("refund-savings");
        By bankName = By.Id("bank_name");
        By bankRounting = By.Id("bank_routing");
        By reBankRounting = By.Id("re_bank_routing");
        By bankAccount = By.Id("bank_account");
        By reBankAccount = By.Id("re_bank_account");
        By sameBankAccount = By.Id("balance-match");
        By differentBankAccount = By.Id("balance-direct-deposit");
        By validateValueTeachingExpenses = By.XPath("//label[@for='answer-192']/following-sibling::small");
        By routingNumberValidation = By.XPath("//p[contains(text(), 'Routing number is invalid.')]");
        By routingNumberDoesNotMath = By.XPath("//p[contains(text(), 'Bank routing numbers do not match')]");
        By accountNumberInvalid = By.XPath("//p[contains(text(), 'Account number is invalid.')]");
        By bankAccountDoesNotMath = By.XPath("//p[contains(text(), 'Bank account numbers do not match')]");

        By differentAccountCheking = By.Id("balance-checking");
        By bankNameDifferent = By.XPath("(//input[@id='bank_name'])[2]");
        By bankRountingDifferent = By.XPath("(//input[@id='bank_routing'])[2]");
        By reBankRountingDifferent = By.XPath("(//input[@id='re_bank_routing'])[2]");
        By bankAccountDifferent = By.XPath("(//input[@id='bank_account'])[2]");
        By reBankAccountDifferent = By.XPath("(//input[@id='re_bank_account'])[2]");
        By titleWelcomeB2C = By.XPath("//h1[contains(text(),'ready')]");
        By buttonNextWelcomeB2C = By.XPath("//button[contains(text(),'Next')]");
        By dateOfBirthField = By.XPath("//input[@placeholder='Date of birth']");
        By dateOfBirthFieldDependent = By.XPath("(//input[@placeholder='Date of birth'])[{0}]");
        By titleMessagePage = By.XPath("//div[contains(@class,'Message')]//h1");
        By messageValidationMedical = By.XPath("//small[contains(text(), 'Please enter a value greater than 0')]");
        By countryList = By.Id("country");
        By editProfileMeAndFamily = By.XPath("(//button[@id='edit'])[1]");
        By foreignMailState = By.Id("foreign_mailing_state");
        By hasSpouse = By.XPath("//h4[text()='My Spouse']");
        By dateOfBirthFieldSpouse = By.XPath("(//input[@placeholder='Date of birth'])[2]");

        By titleCCHWindow1 = By.XPath("//div[contains(@class,'popup--header')]//h4");
        By titleCCHWindow2 = By.XPath("//div[contains(@class,'popup--content')]//div[contains(@class,'popup--children')]");

        List<string> listUploadDocuments = new List<string>();
        public ParticipantMyProfilePage(IWebDriver driver) {
            this.driver = driver;
        }

        public void selectState(string stateToSelect)
        {
            string stateToSelectXpath = string.Format(stateXpath, stateToSelect);
            driver.FindElement(stateField).Click();
            IWebElement stateToSelectElement = driver.FindElement(By.XPath(stateToSelectXpath));
            stateToSelectElement.Click();
        }

        public void setDate(string date)
        {            
            IWebElement datePicker = driver.FindElement(dateInput);
            datePicker.SendKeys(date);
            driver.FindElement(todaysDateContainer).Click();
        }
        
        public void selectAnswerProfileQuestions(string numberQuestion)
        {
            string idQuestion = "answer";
            string completeId = string.Concat(idQuestion, "-" + numberQuestion);
            driver.FindElement(By.Id(completeId)).Click();
        }

        public void fillOutAndValidateFamilySection(string isMarriedOnBoarding, string isMarriedDependent, string spouseNotSsn, string isB2B2CUser, string isCCHValidation, List<ParticipantData> listParticipants)
        {            
            clickJavaScriptExecutor(profileTab);
            waitTillElementIsDisplayedVoid(buttonMyFamily);
            clickButton(buttonMyFamily);
            clickButton(buttonConfirm);

            if (listParticipants[0].isCreatedUser==null)
            {
                scrollMoveElement(firstName);
                string nameTextComparate = (string)ScenarioContext.Current["name"];
                string lastNameComparate = (string)ScenarioContext.Current["lastName"];
                string nickNameComparate = (string)ScenarioContext.Current["nickName"];
                string phoneNumberComparate = (string)ScenarioContext.Current["phoneNumber"];

                string firstNameText = getTextElement(firstName);
                string lastNameText = getTextElement(lastName);
                string nickNameText = getValueElement(nameNick);
                string phoneText = getValueElement(phone);

                Assert.AreEqual(nameTextComparate, firstNameText);
                Assert.AreEqual(lastNameComparate, lastNameText);
                Assert.AreEqual(nickNameComparate, nickNameText);
                Assert.AreEqual("123-456-7898", phoneText);
            }
            else
            {
                string lastNameText = getTextElement(lastName);
                ScenarioContext.Current["lastName"] = lastNameText;
            }

            scrollMoveElementJavaScript(phone);
            selectDateOfBirth("December,7,1962");

            sendValue("123456789", ssn);
            sendValue("Main Street", mailingAddress);
            sendValue("Main Street Corner", mailingAddress2);            
            sendValue("Manhattan", city);
            
            sendValue("12345", zipCode);
            sendTabKey(zipCode);

            dependentSpouse(isMarriedOnBoarding, isMarriedDependent, spouseNotSsn, isB2B2CUser, listParticipants);            

            addDependent(listParticipants);

            clickButton(buttonSave);
            if(isCCHValidation!=null)
            {
                UtilitiesPage.validateCCHConnection(driver, titleCCHWindow1, titleCCHWindow2);
            }
            clickButton(buttonConfirm);
        }

        public void fillOutAboutMeSection(string markCompleteOptions, string maritalStatus, string isCitizen, string isCCHValidation)
        {
            clickButton(buttonStart);            
            answerQuestion("Did you have a change in marital", maritalStatus.Replace("_", " "));
            if(String.Equals(markCompleteOptions, "Yes"))
            {
                answerQuestion("Did you have a change in dependents", "Yes");

                answerQuestion("Were you employed outside of the US any", "Yes");
                listUploadDocuments.Add("1040NR Questionnaire");
                listUploadDocuments.Add("Form 2555 - outside of the US any time");

                answerQuestion("Did you and any spouse/dependents have", "Yes");
                answerQuestion("Did you buy or sell a house in", "Yes");
                listUploadDocuments.Add("Sale of Home & Moving Expenses");
                listUploadDocuments.Add("Settlement / closing statement");

                answerQuestion("Did you move from one state to another", "Yes");
                listUploadDocuments.Add("Paystub from date of move");

                setMoveDate("05/02/2019");

                if(isCitizen.Equals("Yes"))
                {
                    answerQuestion("Are both you and your spouse (if applicable)", "Yes");
                }
                else
                {
                    answerQuestion("Are both you and your spouse (if applicable)", "No");
                    listUploadDocuments.Add("Questionnaire for non-US citizens");
                }

            }
            else
            {
                answerQuestion("Did you have a change in dependents", "No");
                answerQuestion("Were you employed outside of the US any", "No");
                answerQuestion("Did you and any spouse/dependents have", "No");
                answerQuestion("Did you buy or sell a house in", "No");
                answerQuestion("Did you move from one state to another", "No");
                if (isCitizen.Equals("Yes"))
                {
                    answerQuestion("Are both you and your spouse (if applicable)", "Yes");
                }
                else
                {
                    answerQuestion("Are both you and your spouse (if applicable)", "No");
                    listUploadDocuments.Add("Questionnaire for non-US citizens");
                }                
            }                        

            clickButton(buttonSaveAboutMe);
            if (isCCHValidation != null)
            {
                UtilitiesPage.validateCCHConnection(driver, titleCCHWindow1, titleCCHWindow2);
            }
            clickButton(buttonConfirm);
        }


        public void fillOutAboutMeSectionForBuyOrSell(string maritalStatus, string isCCHValidation)
        {
            clickButton(buttonStart);            
            answerQuestion("Did you have a change in marital", maritalStatus.Replace("_", " "));
            answerQuestion("Did you have a change in dependents", "No");
            answerQuestion("Were you employed outside of the US any", "No");
            answerQuestion("Did you and any spouse/dependents have", "No");
            answerQuestion("Did you buy or sell a house in", "Yes");
            listUploadDocuments.Add("Sale of Home & Moving Expenses");
            listUploadDocuments.Add("Settlement / closing statement");
            answerQuestion("Did you move from one state to another", "No");
            answerQuestion("Are both you and your spouse (if applicable)", "Yes");                
            clickButton(buttonSaveAboutMe);
            if (isCCHValidation != null)
            {
                UtilitiesPage.validateCCHConnection(driver, titleCCHWindow1, titleCCHWindow2);
            }
            clickButton(buttonConfirm);
        }

        public void fillOutMyDeductions(string markCompleteOptions, string hadDistributions, string isCCHValidation)
        {
            clickButton(buttonStart);
            if (String.Equals(markCompleteOptions, "Yes"))
            {
                answerQuestion("Did you have a Health Savings Account", "Yes");
                answerQuestionXpathSubQuestionsProfile("If you had distributions", hadDistributions.Replace("_", " "));
                listUploadDocuments.Add("1099-SA / 5498-SA");

                answerQuestion("Did you make contributions to a 529", "Yes");
                listUploadDocuments.Add("529 Plan");

                answerQuestion("Did you make charitable contributions", "Yes");
                inputSubQuestionsProfile("What was the total value of any non-cash", "10000", "No");
                inputSubQuestionsProfile("What was the total value of any cash charitable", "15000", "No");
                listUploadDocuments.Add("Charitable contributions");

                answerQuestion("Did you or your spouse/dependents", "Yes");
                inputSubQuestionsProfile("What was the total amount of those medical", "12000", "No");

                answerQuestion("Were you or your spouse an eligible", "Yes");
                validateTeachingExpenses();
                listUploadDocuments.Add("Educator expenses");

                answerQuestion("Did you or your spouse purchase a vehicle in", "Yes");
                listUploadDocuments.Add("Electric vehicle");

                answerQuestion("Do you believe you may qualify for any", "Yes");
                inputSubQuestionsProfile("Please describe", "Yes, In my case I must have an additional qualification", "No");
            }
            else
            {
                answerQuestion("Did you have a Health Savings Account", "No");
                answerQuestion("Did you make contributions to a 529", "No");
                answerQuestion("Did you make charitable contributions", "No");
                answerQuestion("Did you or your spouse/dependents", "No");
                answerQuestion("Were you or your spouse an eligible", "No");
                answerQuestion("Did you or your spouse purchase a vehicle in", "No");
                answerQuestion("Do you believe you may qualify for any", "No");
            }
                       
            clickButton(buttonSaveMyDeductions);
            if (isCCHValidation != null)
            {
                UtilitiesPage.validateCCHConnection(driver, titleCCHWindow1, titleCCHWindow2);
            }
            clickButton(buttonConfirm);
        }

        public void fillOutMyDeductionsValidateMedical()
        {
            clickButton(buttonStart);

            answerQuestion("Did you have a Health Savings Account", "No");
            answerQuestion("Did you make contributions to a 529", "No");
            answerQuestion("Did you make charitable contributions", "No");
            answerQuestion("Did you or your spouse/dependents", "Yes");
            validateMedicalExpenses();
        }

        public void fillOutMyBankInformation(string markCompleteOptions, string directAndsameBankAccount, string checkMailedAndDirect, string isCCHValidation)
        {
            clickButton(buttonStart);

            if (String.Equals(markCompleteOptions, "Yes"))
            {
                validateBankInformation();
                if(String.Equals(directAndsameBankAccount, "Yes"))
                {
                    clickButton(sameBankAccount);
                }
                else
                {
                    fillOutDifferentBankInformation();
                }
                                
            }
            else
            {
                clickButton(bankCheckMailed);
                if(String.Equals(checkMailedAndDirect, "Yes"))
                {
                    fillOutDifferentBankInformation();
                }
                else
                {
                    clickButton(checkPayOnline);
                }                
            }
            ScenarioContext.Current["listDocumentsAfterMyProfile"] = listUploadDocuments;
            clickButton(buttonSaveMyBankInformation);
            if (isCCHValidation != null)
            {
                UtilitiesPage.validateCCHConnection(driver, titleCCHWindow1, titleCCHWindow2);
            }
            clickButton(buttonConfirm);
            
        }

        public void submitMyInformation()
        {            
            clickButton(homeTab);            
            clickButton(buttonSubmit);
            clickButton(buttonConfirm);            
        }

        public void dependentSpouse(string isMarriedOnBoarding, string isMarriedDependent, string spouseNotSsn, string isB2B2CUser, List<ParticipantData> listParticipants)
        {            
            if (string.Equals(isMarriedOnBoarding, "Yes") && listParticipants[0].isCreatedUser == null)                
            {
                validateSpouseInformation(isB2B2CUser);                
            }
            else if(string.Equals(isMarriedDependent, "Yes") && listParticipants[0].isCreatedUser == null)
            {
                clickButton(buttonAddSpouse);
                sendValue("Janeth", spouseFirstName);
                sendValue("Connor", spouseLastName);               
                selectDateOfBirthSpouse("December,7,1962");
            }

            if(isDisplayed(hasSpouse))
            {
                string dateOfBirthValue = getValueElement(dateOfBirthFieldSpouse);
                if(dateOfBirthValue.Equals(""))
                {
                    selectDateOfBirthSpouse("December,7,1962");
                }

                if (string.Equals(spouseNotSsn, "Yes"))
                {
                    clickButton(checkSpouseSsn);
                }
                else
                {
                    sendValue("123456789", spouseSsn);
                }
                string emailSpouseSend = Utilities.emailSpouse();
                sendValue(emailSpouseSend, emailSpouse);
                sendValue(emailSpouseSend, emailConfirmationSpouse);
            }
        }

        public void addDependent(List<ParticipantData> listParticipants)
        {
            int cont = 0;
            int contAnswer = 1;
            int countParticipants = listParticipants.Count;
            int contAssignDependent = 2;
            foreach (ParticipantData participantData in listParticipants)
            {
                clickButton(buttonAddDependent);
                answerQuestionDependent(contAnswer.ToString(), participantData.typeDependent);
                sendKeyDependentFirstName(cont.ToString(), participantData.firstNameDependent);
                sendKeyDependentLastName(cont.ToString(), participantData.lastNameDependent);
                selectDateOfBirthDependent(participantData.dateOfBirth, cont.ToString());                

                if (contAnswer == countParticipants)
                {
                    if(string.Equals(participantData.dependentNotSsn, "Yes"))
                    {
                        sendKeyDependentCheckSsn(cont.ToString(), "Yes");
                    }
                    else
                    {
                        sendKeyDependentSsn(cont.ToString(), participantData.ssn, "Yes");
                    }
                }
                else
                {
                    if (string.Equals(participantData.dependentNotSsn, "Yes"))
                    {
                        sendKeyDependentCheckSsn(cont.ToString(), "No");
                    }
                    else
                    {
                        sendKeyDependentSsn(cont.ToString(), participantData.ssn, "No");
                    }                    
                }
                cont++;
                contAnswer++;
                contAssignDependent++;
            }                    
        }

        public void validateSpouseInformation(string isB2B2CUser)
        {            
            scrollMoveElement(spouseFirstName);
            string firstNameSpouseText = getValueElement(spouseFirstName);
            string lastNameSpouseText = getValueElement(spouseLastName);
            string dateOfBirthText = getValueElement(dateOfBirthField);
            
            string firstNameSpouseCompare = (string)ScenarioContext.Current["firstNameSpouse"];
            string secondNameSpouseCompare = (string)ScenarioContext.Current["secondNameSpouse"];
            Assert.AreEqual(firstNameSpouseText, firstNameSpouseCompare);
            Assert.AreEqual(lastNameSpouseText, secondNameSpouseCompare);

            if(isB2B2CUser.Equals("No"))
            {                
                string birthDaySpouseCompare = (string)ScenarioContext.Current["birthDaySpouse"];
                Assert.AreEqual(dateOfBirthText, birthDaySpouseCompare);
            }
        }

        public void setMoveDate(string dateMoveString)
        {
            IWebElement datePicker = driver.FindElement(dateMove);
            datePicker.SendKeys(dateMoveString);
            driver.FindElement(todaysDateContainer).Click();
        }

        public void validateTeachingExpenses()
        {
            inputSubQuestionsProfile("What was the total amount of those teaching", "T", "No");
            string textValidate = getTextElement(validateValueTeachingExpenses);
            StringAssert.Contains(configConstants.TEACHING_EXPENSES_MESSAGE_TO_VALIDATE, textValidate);
            inputSubQuestionsProfile("What was the total amount of those teaching", "260", "Yes");
            string valueTeachingExpenses = getValueInputSubQuestion("What was the total amount of those teaching");
            Assert.AreEqual(valueTeachingExpenses, configConstants.TEACHING_EXPENSES_VALUE_TO_VALIDATE);
        }

        public void validateBankInformation()
        {
            clickButton(directDepositBankAccount);
            clickButton(refundCheking);
            sendValue("Bank Of America", bankName);
            sendValue("test", bankRounting);
            sendValue("testTest", reBankRounting);
            sendValue("test", bankAccount);
            sendValue("testTest", reBankAccount);
            sendTabKey(reBankAccount);

            comparateElementTest(routingNumberValidation, configConstants.MESSAGE_VALIDATE_ROUTING);
            comparateElementTest(routingNumberDoesNotMath, configConstants.MESSAGE_BANK_ROUTING_DOES_NOT_MATCH);
            comparateElementTest(accountNumberInvalid, configConstants.MESSAGE_VALIDATE_ACCOUNT_NUMBER);
            comparateElementTest(bankAccountDoesNotMath, configConstants.MESSAGE_ACCOUNT_NUMBER_DOES_NOT_MATCH);

            sendValue("021000021", bankRounting);
            sendValue("021000021", reBankRounting);
            sendValue("011401533", bankAccount);
            sendValue("011401533", reBankAccount);
            sendTabKey(reBankAccount);
        }

        public void fillOutDifferentBankInformation()
        {
            clickButton(differentBankAccount);
            clickButton(differentAccountCheking);
            sendValue("Bank Of America", bankNameDifferent);
            sendValue("091000019", bankRountingDifferent);
            sendValue("091000019", reBankRountingDifferent);
            sendValue("011401578", bankAccountDifferent);
            sendValue("011401578", reBankAccountDifferent);
            sendTabKey(reBankAccountDifferent);
        }

        public void updateStateUserAndAccesPage(string email, ParticipantLoginPage participanLoginPage)
        {
            ConnectionMySql.ConnectMySqlDataBase(email);
            participanLoginPage.openParticipantPage();                     
        }

        public void continueProcessAndAcceptTerms()
        {
            waitTillElementIsDisplayedVoid(titleWelcomeB2C);
            clickButton(buttonNextWelcomeB2C);
            TermsOfUse termsOfUse = new TermsOfUse(driver);
            termsOfUse.acceptTerms();
            termsOfUse.clickOnNextButton();
        }

        public void continueProcessWithoutAcceptTerms()
        {
            waitTillElementIsDisplayedVoid(titleWelcomeB2C);
            clickButton(buttonNextWelcomeB2C);            
        }

        public void validateMedicalExpenses()
        {
            inputSubQuestionsProfile("What was the total amount of those medical", "-5", "No");
            string valueMedicalExpenses = getValueInputSubQuestion("What was the total amount of those medical");
            Assert.AreEqual(valueMedicalExpenses, configConstants.MEDICAL_EXPENSES_VALUE_TO_VALIDATE);

            cleanValue("What was the total amount of those medical");
            comparateElementTest(messageValidationMedical, configConstants.MESSAGE_VALIDATION_MEDICAL_EXPENSES);

            inputSubQuestionsProfile("What was the total amount of those medical", "%&/()ABCDEF*+", "Si");
            comparateElementTest(messageValidationMedical, configConstants.MESSAGE_VALIDATION_MEDICAL_EXPENSES);

            inputSubQuestionsProfile("What was the total amount of those medical", "250000000", "No");
            string valueMedicalBigValidate = getValueInputSubQuestion("What was the total amount of those medical");
            Assert.AreEqual(valueMedicalBigValidate, configConstants.MEDICAL_EXPENSES_BIG_VALUE_TO_VALIDATE);
        }
    

        public void fillOutAndValidateCountryEdition()
        {
            clickJavaScriptExecutor(profileTab);
            clickButton(editProfileMeAndFamily);

            scrollMoveElementJavaScript(countryList);
            selectFromList(countryList, "Russian Federation");
            sendValue("Moscu", foreignMailState);
            sendValue("Kremlin", city);
            sendValue("12345", zipCode);
            sendTabKey(zipCode);

            scrollMoveElement(buttonSave);
            clickButton(buttonSave);
            clickButton(buttonConfirm);
        }

        public void validateUserCanNotEditFamilySection()
        {
            clickJavaScriptExecutor(profileTab);
            clickButton(editProfileMeAndFamily);
            scrollMoveElementJavaScript(countryList);
            string disabledCountry = getAttributeElement(countryList, "disabled");
            Assert.AreEqual(disabledCountry, configConstants.TRUE);
            string disabledState;
            try
            {
                disabledState = getAttributeElement(stateField, "disabled");
            }catch(NoSuchElementException)
            {
                disabledState = "true";
            }
            
            Assert.AreEqual(disabledState, configConstants.TRUE);
        }

        public void validateCountryAndState(ParticipantData participant)
        {
            clickJavaScriptExecutor(profileTab);
            clickButton(buttonMyFamily);
            scrollMoveElementJavaScript(countryList);
            string country = getValueElement(countryList);
            string state;
            if (participant.isStateSelect.Equals("Yes"))
            {
                state = getValueElement(stateField);
            }
            else
            {
                state = getValueElement(foreignMailState);
            }

            Assert.AreEqual(country, participant.country.Replace("_", " "));
            Assert.AreEqual(state, participant.stateCompare);
        }

        public void validateCountrySelectAndStateSelect(List<ParticipantData> listParticipant)
        {
            clickJavaScriptExecutor(profileTab);
            clickButton(editProfileMeAndFamily);
            clickButton(buttonConfirm);
            scrollMoveElementJavaScript(countryList);

            foreach (ParticipantData participant in listParticipant)
            {
                string country = participant.country.Replace("_", " ");
                selectFromListValue(countryList, country);
                string state = participant.stateSelect.Replace("_", " ");
                if (participant.isCountryUs.Equals("Yes"))
                {
                    selectFromListValue(stateField, state);
                }
                else
                {
                    selectFromListValue(foreignMailState, state);
                }
            }
            RandomEmail randomEmailObjectSsn = new RandomEmail();
            string nextSequenceSsn = randomEmailObjectSsn.GenerateRandomString(9);
            sendValue(nextSequenceSsn, ssn);
            sendTabKey(ssn);            

            RandomEmail randomEmailObjectZip = new RandomEmail();
            string nextSequenceZip = randomEmailObjectZip.GenerateRandomString(5);
            sendValue(nextSequenceZip, zipCode);
            sendTabKey(zipCode);
           
            scrollMoveElementJavaScript(buttonSave);
            clickButton(buttonSave);
            waitTillElementIsDisplayed(buttonConfirm);
            clickButton(buttonConfirm);    
        }
    }
}
