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
using TechTalk.SpecFlow.Assist;
using TaxChatTAF.pages.preparer;
using TaxChatTAF.pages.participant;
using TaxChatTAF.pages.documents.popups;

namespace TaxChatTAFSpecFlow.utils
{
    class UtilitiesSteps
    {        
        
        public static void creationPageValues(IWebDriver driver, string name, string lastname, int expectedQuote, string isB2B2CUser, ParticipantData participant)
        {            
            participant.name = name;
            participant.lastName = lastname;
            participant.expectedQuote = expectedQuote;
            participant.isB2B2CUser = isB2B2CUser;
            ScenarioContext.Current["name"] = participant.name;
            ScenarioContext.Current["lastName"] = participant.lastName;

            CreatePage createPage = new CreatePage(driver);            
            createPage.waitTillQuoteIsDisplayedVoid();
            Quote quote = new Quote(driver);
            Assert.AreEqual(quote.getQuoteValue(), "$" + expectedQuote);
            
            Utilities.fillOutFieldsCreationPage(participant, driver);
        }

        public static List<string> openPreparerPageAndReviewComplexity(IWebDriver driver, string lastname, string reviewComplexity)
        {            
            string email = (string) ScenarioContext.Current["email"];
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            ParticipantData participant = new ParticipantData();
            participant.isCreatedUser = "No";
            commonStepsPreparer(driver, participant);
            List<string> result = searchParticipantsPage.reviewParticipantComplexity(email, lastname, reviewComplexity);
            return result;
        }

        public void openPreparerPageAndConfirmsDocuments(IWebDriver driver, string lastname, ParticipantData participant)
        {            
            string email = (string)ScenarioContext.Current["email"];
            string lastNameAssign;
            lastNameAssign = lastname;
            if (participant.isCreatedUser.Equals("Yes"))
            {
                lastNameAssign = (string)ScenarioContext.Current["lastName"];
            }
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            commonStepsPreparer(driver, participant);
            searchParticipantsPage.preparerConfirmsDocuments(email, lastNameAssign);
        }

        public static string getTestPricing(string price)
        {
            string[] firstList = price.Split('$');
            string price1 = firstList[1];
            string[] secondList = price1.Split('.');
            string price2 = secondList[0];
            return price2;
        }

        public static void fillOutProfileSection(IWebDriver driver, List<ParticipantData> listParticipants, ParticipantData participantData)
        {            
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            participantMyProfilePage.fillOutAndValidateFamilySection(participantData.isMarriedOnBoarding, participantData.isMarriedDependent, participantData.spouseNotSsn, participantData.isB2B2CUser, participantData.isCCHValidation, listParticipants);
            if (participantData.isBuySell.Equals("Yes"))
            {
                participantMyProfilePage.fillOutAboutMeSectionForBuyOrSell(participantData.maritalStatus, participantData.isCCHValidation);
            }
            else
            {
                participantMyProfilePage.fillOutAboutMeSection(participantData.markCompleteOptions, participantData.maritalStatus, participantData.isCitizen, participantData.isCCHValidation);
            }
            participantMyProfilePage.fillOutMyDeductions(participantData.markCompleteOptions, participantData.hadDistributions, participantData.isCCHValidation);
            participantMyProfilePage.fillOutMyBankInformation(participantData.markCompleteOptions, participantData.directAndsameBankAccount, participantData.checkMailedAndDirect, participantData.isCCHValidation);
            participantDocumentsPage.uploadDocuments("listDocumentsAfterMyProfile", participantData.isRandomUploadFile);
            participantMyProfilePage.submitMyInformation();
        }
               
        public static void fillOutProfileSectionAndValidateMedical(IWebDriver driver, ParticipantData participantData, List<ParticipantData> listParticipants)
        {            
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            participantMyProfilePage.fillOutAndValidateFamilySection(participantData.isMarriedOnBoarding, participantData.isMarriedDependent, participantData.spouseNotSsn, participantData.isB2B2CUser, "No", listParticipants);
            participantMyProfilePage.fillOutAboutMeSectionForBuyOrSell(participantData.maritalStatus, participantData.isCCHValidation);
            participantMyProfilePage.fillOutMyDeductionsValidateMedical();
        }

        public List<string> SelectOptionTiles(IWebDriver driver, Table table, List<string> textDocumentUpload, List<string> tileList)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            ConfigPage configPage = new ConfigPage(driver);            

            ChildrenDependentPopup childrenDependentPopup = new ChildrenDependentPopup(driver);
            OwnedRentalPropertyPopUp ownedRentalPropertyPopUp = new OwnedRentalPropertyPopUp(driver);            
            InvestMentPopUp investmentPopUp = new InvestMentPopUp(driver);
            ForeignIncomePopUp foreignIncomePopUp = new ForeignIncomePopUp(driver);
            K1IncomePopup k1Income = new K1IncomePopup(driver);
            CryptoCurrencyPopUp cryptoCurrencyPopUp = new CryptoCurrencyPopUp(driver);
            W2IncomePopUp w2IncomePopUp = new W2IncomePopUp(driver);
            IRAPopUp iraPopUp = new IRAPopUp(driver);
            EducationExpensesPopup educationExpensesPopup = new EducationExpensesPopup(driver);
            configPage.waitTillTellUsMessageDisplayedVoid();
            foreach (string tile in tileList)
            {
                switch (tile)
                {
                    case configConstants.CHILDREN_DEPENDENTS:

                        configPage.selectChildrenDependents();
                        textDocumentUpload.Add("Info needed for dependent credits");
                        if (participant.input >= 1)
                        {
                            textDocumentUpload.Add("ITIN application");
                        }
                        if (ConditionsTiles(participant, "Yes"))
                        {
                            childrenDependentPopup.selectYesOption();
                            textDocumentUpload.Add("Dependent care expenses");
                        }
                        else
                        {
                            childrenDependentPopup.selectNoOption();
                        }

                        childrenDependentPopup.typeInputnumber("" + participant.input);

                        childrenDependentPopup.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.MORTAGE;
                        }
                        break;

                    case configConstants.MORTAGE:

                        configPage.selectMortgage();
                        textDocumentUpload.Add("Mortgage interest statement / property taxes");
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.US_RENTAL_PROPERTIES;
                        }
                        break;

                    case configConstants.US_RENTAL_PROPERTIES:

                        configPage.selectOwnedRentalProperty();
                        textDocumentUpload.Add("Rental and royalty income and expenses 2019");

                        ownedRentalPropertyPopUp.typeInputnumber("" + participant.input);
                        if (ConditionsTiles(participant, "Personal Use"))
                        {
                            ownedRentalPropertyPopUp.selectOption1();
                        }
                        if (ConditionsTiles(participant, "Bought"))
                        {
                            ownedRentalPropertyPopUp.selectOption2();
                            textDocumentUpload.Add("Settlement statement for rental property purchase");
                        }
                        if (ConditionsTiles(participant, "Sold"))
                        {
                            ownedRentalPropertyPopUp.selectOption3();
                            textDocumentUpload.Add("Settlement statement for rental property sale");
                        }

                        ownedRentalPropertyPopUp.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.SELF_EMPLOYED;
                        }
                        break;

                    case configConstants.SELF_EMPLOYED:

                        configPage.selectSelfEmployedIncome();
                        textDocumentUpload.Add("Business income and expenses");
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.INVESTMENT_INCOME;
                        }
                        break;

                    case configConstants.INVESTMENT_INCOME:

                        configPage.selectInvestmentIncome();
                        textDocumentUpload.Add("1099 - Investment income");
                        investmentPopUp.typeInputnumber("" + participant.input);
                        investmentPopUp.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.FOREIGN_INCOME;
                        }
                        break;

                    case configConstants.FOREIGN_INCOME:

                        configPage.selectForeignIncome();
                        textDocumentUpload.Add("Foreign income questionnaire");
                        textDocumentUpload.Add("Supplementary Questions Regarding Foreign Tax Matters");
                        if (ConditionsTiles(participant, "Investment income through US"))
                        {
                            foreignIncomePopUp.selectOption1();
                        }
                        if (ConditionsTiles(participant, "Foreign rental"))
                        {
                            foreignIncomePopUp.selectOption2();
                            textDocumentUpload.Add("Foreign rental doc");
                        }
                        if (ConditionsTiles(participant, "Foreign mutual funds or similar investments"))
                        {
                            foreignIncomePopUp.selectOption3();
                            textDocumentUpload.Add("Form 2555");
                        }
                        if (ConditionsTiles(participant, "Direct investment in a foreign corporation or partnership"))
                        {
                            foreignIncomePopUp.selectOption4();
                        }
                        if (ConditionsTiles(participant, "Form 2555"))
                        {
                            foreignIncomePopUp.selectOption5();
                        }
                        if (ConditionsTiles(participant, "First year filing a US"))
                        {
                            foreignIncomePopUp.selectOption6();
                            textDocumentUpload.Add("1040NR Questionnaire");
                        }

                        foreignIncomePopUp.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.K1_INCOME;
                        }
                        break;

                    case configConstants.K1_INCOME:

                        configPage.selectK1Income();
                        textDocumentUpload.Add("K-1");
                        k1Income.typeInputnumber("" + participant.input);
                        k1Income.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.CRYPTOCURRENCY;
                        }
                        break;

                    case configConstants.CRYPTOCURRENCY:

                        configPage.selectCryptoCurrency();
                        textDocumentUpload.Add("Cryptocurrency information");
                        if (ConditionsTiles(participant, "sale or exchange"))
                        {
                            cryptoCurrencyPopUp.selectOption1();
                            textDocumentUpload.Add("CryptoCurrency exchanges and sales template");
                        }
                        if (ConditionsTiles(participant, "peer-to-peer"))
                        {
                            cryptoCurrencyPopUp.selectOption2();
                            textDocumentUpload.Add("Peer to peer transactions");
                        }
                        if (ConditionsTiles(participant, "purchase"))
                        {
                            cryptoCurrencyPopUp.selectOption3();
                            textDocumentUpload.Add("Products/service purchases");
                        }
                        if (ConditionsTiles(participant, "gifts or donations"))
                        {
                            cryptoCurrencyPopUp.selectOption4();
                            textDocumentUpload.Add("Gifts / donations");
                        }
                        if (ConditionsTiles(participant, "mining"))
                        {
                            cryptoCurrencyPopUp.selectOption5();
                            textDocumentUpload.Add("Mining / minting");
                        }
                        if (ConditionsTiles(participant, "not reported"))
                        {
                            cryptoCurrencyPopUp.selectOption6();
                            textDocumentUpload.Add("Forks / dividends / other off exchange");
                        }
                        if (ConditionsTiles(participant, "FIFO"))
                        {
                            cryptoCurrencyPopUp.selectOption7();
                        }
                        if (ConditionsTiles(participant, "lending arrangement"))
                        {
                            cryptoCurrencyPopUp.selectOption8();
                            textDocumentUpload.Add("Lending arrangement");
                        }
                        if (ConditionsTiles(participant, "ICO SAFT STO"))
                        {
                            cryptoCurrencyPopUp.selectOption9();
                            textDocumentUpload.Add("ICO, SAFT, STO");
                        }
                        if (ConditionsTiles(participant, "CFDs"))
                        {
                            cryptoCurrencyPopUp.selectOption10();
                            textDocumentUpload.Add("CFD activity");
                        }
                        if (ConditionsTiles(participant, "vehicle"))
                        {
                            cryptoCurrencyPopUp.selectOption11();
                            textDocumentUpload.Add("CAAT trust calculation template");
                        }
                        cryptoCurrencyPopUp.clickOnDoneButtonParameter("crypto");
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.EDUCATION_EXPENSES;
                        }
                        break;

                    case configConstants.EDUCATION_EXPENSES:

                        configPage.selectEducationExpenses();
                        if (ConditionsTiles(participant, "Student loan interest"))
                        {
                            educationExpensesPopup.selectOption1();
                            textDocumentUpload.Add("W-2 (all-pages)");
                        }
                        if (ConditionsTiles(participant, "Tuition expenses"))
                        {
                            educationExpensesPopup.selectOption2();
                            textDocumentUpload.Add("Education expense");
                            textDocumentUpload.Add("Form 1098-T");
                        }

                        educationExpensesPopup.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.IRA;
                        }
                        break;

                    case configConstants.IRA:
                        configPage.selectIRA();

                        if (ConditionsTiles(participant, "make contributions"))
                        {
                            iraPopUp.selectOption1();
                            textDocumentUpload.Add("5498 - IRA contributions");
                        }
                        if (ConditionsTiles(participant, "rollover or conversion"))
                        {
                            iraPopUp.selectOption2();
                            textDocumentUpload.Add("1099R - Distribution statement");
                        }
                        if (ConditionsTiles(participant, "distribution"))
                        {
                            iraPopUp.selectOption3();
                            textDocumentUpload.Add("1099R - Distribution statement (1)");
                        }
                        if (String.Equals(participant.internalOption, "none"))
                        {
                            iraPopUp.selectOption4();
                        }
                        iraPopUp.clickOnDoneButton();
                        if (participant.isValidationSpigotGroup.Equals("Yes"))
                        {
                            goto case configConstants.W2S;
                        }
                        break;

                    case configConstants.W2S:
                        configPage.selectW2();
                        if (ConditionsTiles(participant, "Do you have W-2 income"))
                        {
                            w2IncomePopUp.selectOption1();
                        }
                        if (ConditionsTiles(participant, "Does your spouse have"))
                        {
                            w2IncomePopUp.selectOption2();
                            textDocumentUpload.Add("W-2 (spouse)");
                        }
                        if (ConditionsTiles(participant, "Does your or your spouse's W-2 more than 3 States"))
                        {
                            w2IncomePopUp.selectOption3();
                        }

                        textDocumentUpload.Add("W-2 (all-pages)");
                        w2IncomePopUp.clickOnDoneButtonParameter("w2");
                        break;

                    default:
                        break;
                }
            }
            return textDocumentUpload;
        }

        public Boolean ConditionsTiles(ParticipantData participant, string stringCondition)
        {
            Boolean answer = false;
            if (String.Equals(participant.internalOption, stringCondition) || String.Equals(participant.isValidationSpigotGroup, "Yes") || String.Equals(participant.isValidationTileByParts, "Yes"))
            {
                answer = true;
            }
            return answer;
        }
        
        public static void commonStepsPreparer(IWebDriver driver, ParticipantData participant)
        {
            ConsentsTOSPage consentsTOSPage = new ConsentsTOSPage(driver);
            consentsTOSPage.openPreparerPage(participant);
            if(participant.isCreatedUser.Equals("No"))
            {
                consentsTOSPage.changeTab(3);
            }
            else
            {
                consentsTOSPage.changeTab(1);
            }
            PreparerLoginPage preparerLoginPage = new PreparerLoginPage(driver);
            preparerLoginPage.waitTillIdPreparerIsVisible();
            preparerLoginPage.typePreparerID(Environment.GetEnvironmentVariable("PREPARER_USER"));
            preparerLoginPage.typePreparerPassword(Environment.GetEnvironmentVariable("PREPARER_PASS"));
            preparerLoginPage.clickOnSignInButton();                        
        }

        public static void commonPaymentSteps(IWebDriver driver, Table table, Boolean isMarkingAddress)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            ParticipantPayment participantPayment = new ParticipantPayment(driver);
            if (participant.isCreatedUser.Equals("No"))
            {
                participantMyProfilePage.changeTabAndRefresh(2);
            }
            else
            {
                participantMyProfilePage.changeTabAndRefresh(0);
            }
            participantPayment.processPayment(participant, isMarkingAddress);
        }

        public static ParticipantData assignValuesParticipantData(List<ParticipantData> listParticipants)
        {
            ParticipantData participantData = new ParticipantData();
            participantData.isMarriedOnBoarding = listParticipants[0].isMarriedOnBoarding;
            participantData.spouseNotSsn = listParticipants[0].spouseNotSsn;
            participantData.isMarriedDependent = listParticipants[0].isMarriedDependent;
            participantData.markCompleteOptions = listParticipants[0].markCompleteOptions;
            participantData.maritalStatus = listParticipants[0].maritalStatus;
            participantData.hadDistributions = listParticipants[0].hadDistributions;
            participantData.directAndsameBankAccount = listParticipants[0].directAndsameBankAccount;
            participantData.checkMailedAndDirect = listParticipants[0].checkMailedAndDirect;
            participantData.isRandomUploadFile = listParticipants[0].isRandomUploadFile;
            participantData.isB2B2CUser = listParticipants[0].isB2B2CUser;
            participantData.isCCHValidation = listParticipants[0].isCCHValidation;

            return participantData;
        }

        public void openPreparerPageAndValidateCchProcess(IWebDriver driver, string lastname, ParticipantData participant)
        {
            string email = (string)ScenarioContext.Current["email"];            
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            commonStepsPreparer(driver, participant);
            searchParticipantsPage.preparerValidateCchProcess(email, lastname);
        }        
    }
}
