using System.Collections.Generic;
using TaxChatTAF;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TaxChatTAF.pages.documents.signUp;
using TaxChatTAFSpecFlow.models;
using System;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System.Diagnostics;
using TaxChatTAF.utils;
using NUnit.Framework;

namespace TaxChatTAFSpecFlow.utils
{
    class Utilities
    {        
        public static string obtainTileName(string tile)
        {
            string result = "";
            switch (tile)
            {
                case "1":
                    result= configConstants.CHILDREN_DEPENDENTS;
                    break;
                case "2":
                    result = configConstants.MORTAGE;
                    break;
                case "3":
                    result = configConstants.US_RENTAL_PROPERTIES;
                    break;
                case "4":
                    result = configConstants.SELF_EMPLOYED;
                    break;
                case "5":
                    result = configConstants.INVESTMENT_INCOME;
                    break;
                case "6":
                    result = configConstants.FOREIGN_INCOME;
                    break;
                case "7":
                    result = configConstants.K1_INCOME;
                    break;
                case "8":
                    result = configConstants.EDUCATION_EXPENSES;
                    break;
                case "9":
                    result = configConstants.IRA;
                    break;
                case "10":
                    result = configConstants.CRYPTOCURRENCY;
                    break;
                case "11":
                    result = configConstants.W2S;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static List<string> tileListSeparate(string tileListString)
        {
            string[] tileList;
            List<string> tileListResult = new List<string>();
            tileList = tileListString.Split(",");

            for (int i = 0; i < tileList.Length; i++)
            {
                switch (tileList[i])
                {
                    case "1":
                        tileListResult.Add(configConstants.CHILDREN_DEPENDENTS);
                        break;
                    case "2":
                        tileListResult.Add(configConstants.MORTAGE);
                        break;
                    case "3":
                        tileListResult.Add(configConstants.US_RENTAL_PROPERTIES);
                        break;
                    case "4":
                        tileListResult.Add(configConstants.SELF_EMPLOYED);
                        break;
                    case "5":
                        tileListResult.Add(configConstants.INVESTMENT_INCOME);
                        break;
                    case "6":
                        tileListResult.Add(configConstants.FOREIGN_INCOME);
                        break;
                    case "7":
                        tileListResult.Add(configConstants.K1_INCOME);
                        break;
                    case "8":
                        tileListResult.Add(configConstants.EDUCATION_EXPENSES);
                        break;
                    case "9":
                        tileListResult.Add(configConstants.IRA);
                        break;
                    case "10":
                        tileListResult.Add(configConstants.CRYPTOCURRENCY);
                        break;
                    case "11":
                        tileListResult.Add(configConstants.W2S);
                        break;
                    default:
                        break;
                }
            }
            return tileListResult;
        }

        public static string getRelativePathRoute(string pathFile)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string relativeRoute = outPutDirectory;
            string[] separateDate = relativeRoute.Split("bin");
            string fileComplete = separateDate[0] + pathFile;
            string[] fileUpload = fileComplete.Split("file");
            string fileSubstring = fileUpload[1];
            string file = fileSubstring.Substring(2);
            return file;
        }

        public static void fillOutFieldsCreationPage(ParticipantData participant, IWebDriver driver)
        {            
            CreatePage createPage = new CreatePage(driver);
            ConsentsTOSPage consentsTOSPage = new ConsentsTOSPage(driver);
            if (participant.showQuotePage == null || participant.showQuotePage.Equals(""))
            {                
                createPage.clickOnNextButton();
            }
            createPage.typeNickName("Nickname");
            ScenarioContext.Current["nickName"] = "Nickname";
            if (!participant.isB2B2CUser.Equals("Yes"))
            {
                if(participant.validateDateOfBirth.Equals("Yes"))
                {
                    validateDateOfBirth(createPage);
                }
                else
                {
                    createPage.selectDateOfBirthOld("December,7,1995");
                }
            }
            createPage.typePhone("1234567898");
            ScenarioContext.Current["phoneNumber"] = "1234567898";
            if (!participant.isB2B2CUser.Equals("Yes"))
            {
                createPage.typeMailingAddress("Stratford, London, Usa");
                createPage.typeMailingAddress2("Stratford, London, Usa");
            }

            if(participant.country != null)
            {
                string country = participant.country.Replace("_", " ");
                createPage.selectCountryList(country);

                if (participant.isStateSelect.Equals("Yes"))
                {
                    string state = participant.stateSelect.Replace("_", " ");
                    createPage.selectStateList(state);
                }
                else
                {
                    createPage.typeForeignState(participant.stateSelect);
                }
            }else
            {
                createPage.selectState("Wyoming");
            }
            if (!participant.isB2B2CUser.Equals("Yes"))
            {
                createPage.typeCity("Some City");
                createPage.typeZipCode("76543");
            }
            if(participant.validatePasswordMessage.Equals("Yes"))
            {
                validatePassword(driver);
                return;
            }
            else
            {
                createPage.typePassword(configConstants.USER_PASSWORD);
                createPage.typePasswordConfirmation(configConstants.USER_PASSWORD);
            }
            if (!participant.isB2B2CUser.Equals("Yes") && !participant.howDidYouHearAboutList.Equals("No"))
            {
                if(participant.otherOptionHowDidYouHearList != null)
                {
                    createPage.selectHowDidYouHearList("Other");
                    createPage.typeHowDidYouHearText(configConstants.OTHER_OPTION_TEXT_HOW_DID_LIST);
                }
                else
                {
                    createPage.selectHowDidYouHearList("Facebook");                    
                }
            }
            createPage.moveToNextButton();
            createPage.clickOnNextButton();            
            if (participant.consentAditionalQuestion.Equals("Yes"))
            {    
                if(participant.validateAdditionalConsents.Equals("Yes"))
                {
                    validateAdditionalConsents(createPage, driver);
                    return;
                }
                else
                {
                    createPage.waitTillAdditionalConsentTitle();
                    createPage.answerQuestion("is your business associated with the marijuana industry", "No");
                    createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
                    createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
                    createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
                    createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
                    createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
                    createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
                    createPage.clickOnNextButton();
                }
            }

            if (participant.consentMarried.Equals("Yes"))
            {
                consentsTOSPage.typeTaxPayerName(participant.name + " " + participant.lastName);
                consentsTOSPage.setTodayDate(DateTime.Now.ToString("MM/dd/yyyy"));
                if (participant.isMarriedOnBoarding.Equals("Yes"))
                {
                    consentsTOSPage.answerQuestion("Are you married?", "Yes");
                    consentsTOSPage.typeSpouseFirstName("Christina");
                    consentsTOSPage.typeSpouseLastName("Chloe");
                    if (participant.isB2B2CUser != null && participant.isB2B2CUser.Equals("No"))
                    {
                        SeleniumActions seleniumAction = new SeleniumActions();
                        seleniumAction.driver = driver;
                        string emailSpouseSend = emailSpouse();
                        consentsTOSPage.typeEmailSpouse(emailSpouseSend);
                        seleniumAction.selectDateOfBirth("December,7,1962");
                        ScenarioContext.Current["emailSpouse"] = emailSpouseSend;
                        ScenarioContext.Current["birthDaySpouse"] = "12/07/1962";
                    }                                        
                    ScenarioContext.Current["firstNameSpouse"] = "Christina";
                    ScenarioContext.Current["secondNameSpouse"] = "Chloe";                    
                }
                else
                {
                    consentsTOSPage.answerQuestion("Are you married?", "No");
                }
                consentsTOSPage.clickOnNextButton();
            }

            if (participant.consentFinantialReport.Equals("Yes"))
            {
                consentsTOSPage.selectNoAnswerInFinantialReporting();
                consentsTOSPage.clickOnNextButton();
            }

            if (participant.consentReportableTransaction.Equals("Yes"))
            {
                consentsTOSPage.selectNoAnswerToReportableTransaction();
                consentsTOSPage.clickOnNextButton();
            }            
        }

        public static string getNameFileUpload(string nameDocument)
        {
            string nameFileUpload = "";
            switch (nameDocument)
            {
                case nameFilesConstants.DEPENDENT_CARE_EXPENSES_DOC:
                    nameFileUpload = nameFilesConstants.CHILD_DEPENDENT_2018;
                    break;
                case nameFilesConstants.INFO_NEEDED_FOR_DEPENDENT_DOC:
                    nameFileUpload = nameFilesConstants.INFO_NEEDED_FOR_DEPENDENT;
                    break;
                case nameFilesConstants.MORTAGE_INTEREST_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.RENTA_AND_ROYALTI_INCOME_DOC:
                    nameFileUpload = nameFilesConstants.RENTAL_AND_ROYALTY_INCOME;
                    break;
                case nameFilesConstants.SETTLEMENT_STATEMENT_FOR_DOC:
                    nameFileUpload = nameFilesConstants.RENTAL_AND_ROYALTY_INCOME;
                    break;
                case nameFilesConstants.SETTLEMENT_STATEMENT_SALE_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.BUSINESS_INCOME_DOC:
                    nameFileUpload = nameFilesConstants.BUSINESS_INCOME_EXPENSES;
                    break;
                case nameFilesConstants.INVESTMENT_1099_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.FOREIGN_INCOME_QUEST_DOC:
                    nameFileUpload = nameFilesConstants.FOREIGN_INCOME_QUESTIONNARIE;
                    break;
                case nameFilesConstants.SUPPLEMENTARY_QUESTION_DOC:
                    nameFileUpload = nameFilesConstants.SUPPLEMENTARY_QUESTIONS_REG;
                    break;
                case nameFilesConstants.FOREIGN_RENTAL_DOC:
                    nameFileUpload = nameFilesConstants.FOREIGN_RENTAL;
                    break;
                case nameFilesConstants.FORM_2555_DOC:
                    nameFileUpload = nameFilesConstants.FORM_2555_OUTSIDE;
                    break;
                case nameFilesConstants.QUESTIONNAIRE_1040_DOC:
                    nameFileUpload = nameFilesConstants.QUESTIONNAIRE_1040NR;
                    break;
                case nameFilesConstants.K_1_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.CRYPTOCURRENCY_INF_DOC:
                    nameFileUpload = nameFilesConstants.CRYPTOCURRENCY_TAXCHAT;
                    break;
                case nameFilesConstants.CRYPTOCURRENCY_EXCHANGE_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.PRODUCTS_SERVICES_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.MINING_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.LENDING_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.ICO_SAFT_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.CFD_ACTIVITY_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.CAAT_TRUST_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.W_2_ALL_PAGES_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.EDUCATION_EXPENSE_DOC:
                    nameFileUpload = nameFilesConstants.EDUCATION_AOTC_2018;
                    break;
                case nameFilesConstants.FORM_1098_T_DOC:
                    nameFileUpload = nameFilesConstants.FORM_1098_T;
                    break;
                case nameFilesConstants.IRA_CONTRIBUTIONS_5498_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.DISTRIBUTION_STATEMENT_1099_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.W_2_SPOUSE_DOC:
                    nameFileUpload = nameFilesConstants.W2_SPOUSE;
                    break;
                case nameFilesConstants.GOVERNMENT_ISSUED_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.PRIOR_YEAR_RETURN_DOC:
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case nameFilesConstants.ITIN_APPLICATION_DOC:
                    nameFileUpload = nameFilesConstants.CRYPTOCURRENCY_TAXCHAT;
                    break;
                case nameFilesConstants.QUESTIONNAIRE_FOR_NON_DOC:
                    nameFileUpload = nameFilesConstants.QUESTIONNAIRE_FOR_NON;
                    break;
                case nameFilesConstants.FORM_2555_OUTSIDE_ANY_TIME:
                    nameFileUpload = nameFilesConstants.FORM_2555_OUTSIDE;
                    break;
                case nameFilesConstants.EDUCATOR_EXPENSE_DOC:
                    nameFileUpload = nameFilesConstants.EDUCATOR_EXPENSE;
                    break;
                default:
                    break;
            }            
            return nameFileUpload;
        }

        public static string getRandomFileUpload(string numberDocument)
        {
            string nameFileUpload = "";
            switch (numberDocument)
            {
                case "1":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_DOC;
                    break;
                case "2":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_XLS;
                    break;
                case "3":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_PNG;
                    break;
                case "4":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_DOCX;
                    break;
                case "5":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_XLSX;
                    break;
                case "6":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD;
                    break;
                case "7":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_JPG;
                    break;
                case "8":
                    nameFileUpload = nameFilesConstants.FILE_TEST_UPLOAD_JPEG;
                    break;
                default:
                    break;
            }
            return nameFileUpload;
        }

        public static void executeFile(string fileName, string route)
        {
            ProcessStartInfo info2 = new ProcessStartInfo();
            info2.UseShellExecute = true;
            info2.FileName = fileName;
            info2.WorkingDirectory = route;
            Process.Start(info2);
        }

        public static void validateAdditionalConsents(CreatePage createPage, IWebDriver driver)
        {
            SeleniumActions seleniumAction = new SeleniumActions();
            seleniumAction.driver = driver;
            By containerValidation = By.XPath("//div[@class='popup--container null']");
            By buttonContainer = By.XPath("//div[@class='popup--container null']//button[@type='submit']");

            createPage.answerQuestion("is your business associated with the marijuana industry", "Yes");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);

            createPage.answerQuestion("is your business associated with the marijuana industry", "No");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "Yes");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);

            createPage.answerQuestion("is your business associated with the marijuana industry", "No");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "Yes");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);

            createPage.answerQuestion("is your business associated with the marijuana industry", "No");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "Yes");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);

            createPage.answerQuestion("is your business associated with the marijuana industry", "No");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "Yes");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);

            createPage.answerQuestion("is your business associated with the marijuana industry", "No");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "Yes");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "No");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);

            createPage.answerQuestion("is your business associated with the marijuana industry", "No");
            createPage.answerQuestion("Have you ever knowingly failed to file a required", "No");
            createPage.answerQuestion("Did you live in, or have close ties with any of the following", "No");
            createPage.answerQuestion("Did you launch, or assist in launching, a token offering", "No");
            createPage.answerQuestion("Did you design, or assist in designing, cryptocurrency", "No");
            createPage.answerQuestion("Did you participate/invest in derivative contracts involving cryptocurrency", "No");
            createPage.answerQuestion("Did the gross value of your cryptocurrency activity", "Yes");
            createPage.clickOnNextButton();
            seleniumAction.waitTillElementIsDisplayed(containerValidation);
            seleniumAction.clickButton(buttonContainer);
        }

        public static void validatePassword(IWebDriver driver)
        {
            By textValidationPassword = By.XPath("//p[text()='Password must contain one uppercase letter, one lowercase letter, and one number.']");
            By textValidationTooShort = By.XPath("//p[text()='Password is too short.']");
            By textValidationMessage = By.XPath("(//div[@class='error-notification'])[3]");
            By confirmPasswordField = By.Id("confirmPassword");
            SeleniumActions seleniumAction = new SeleniumActions();
            seleniumAction.driver = driver;
            CreatePage createPage = new CreatePage(driver);
            createPage.typePassword(configConstants.VALIDATION_PASS_UPPER);
            createPage.typePasswordConfirmation(configConstants.VALIDATION_PASS_UPPER);            
            createPage.waitTillElementIsDisplayed(textValidationMessage);
            string textMessage = seleniumAction.getTextElement(textValidationPassword);
            Assert.AreEqual(textMessage, configConstants.MESSAGE_VALIDATION_PASSWORD);

            createPage.typePassword(configConstants.VALIDATION_PASS_LOWER);
            createPage.typePasswordConfirmation(configConstants.VALIDATION_PASS_LOWER);            
            createPage.waitTillElementIsDisplayed(textValidationMessage);
            textMessage = seleniumAction.getTextElement(textValidationPassword);
            Assert.AreEqual(textMessage, configConstants.MESSAGE_VALIDATION_PASSWORD);

            createPage.typePassword(configConstants.VALIDATION_PASS_NUMBER);
            createPage.typePasswordConfirmation(configConstants.VALIDATION_PASS_NUMBER);            
            createPage.waitTillElementIsDisplayed(textValidationMessage);
            textMessage = seleniumAction.getTextElement(textValidationPassword);
            Assert.AreEqual(textMessage, configConstants.MESSAGE_VALIDATION_PASSWORD);

            createPage.typePassword(configConstants.VALIDATION_PASS_LENGTH);
            createPage.typePasswordConfirmation(configConstants.VALIDATION_PASS_LENGTH);            
            createPage.waitTillElementIsDisplayed(textValidationMessage);
            textMessage = seleniumAction.getTextElement(textValidationTooShort);
            Assert.AreEqual(textMessage, configConstants.MESSAGE_VALIDATION_LENGTH_PASSWORD);

        }

        public static void validateDateOfBirth(CreatePage createPage)
        {
            string currentYear = DateTime.Now.ToString("yyyy");
            int curretYearNumber = Int32.Parse(currentYear);
            int adultYear = curretYearNumber - 18;
            int yearValidation = adultYear + 1;
            bool elementNotPresent = false;
            try
            {
                createPage.selectDateOfBirth("December,7," + yearValidation.ToString());
            }
            catch (NoSuchElementException)
            {
                elementNotPresent = true;
                
            }  
            if(elementNotPresent)
            {
                createPage.selectDateOfBirth("December,7,1995");
            }
        }

        public static string emailSpouse()
        {
            RandomEmail randomEmailObject = new RandomEmail();
            string monthDay = DateTime.Now.ToString("MM-dd");
            string[] monthDayList = monthDay.Split("-");
            string month = monthDayList[0];
            string day = monthDayList[1];
            string nextSequenceEmail = randomEmailObject.GenerateRandomString(4);
            string email = "test@gmail.com";
            string[] emailList = email.Split("@");
            string emailSpouseSend = emailList[0] + month + day + nextSequenceEmail + "@" + emailList[1];
            return emailSpouseSend;
        }

        public static string getTextHowDidYouHearOtherOptionList(string email)
        {
            return ConnectionMySql.GetAnswerQuestionHowDidYou(email);            
        }
    }
}
