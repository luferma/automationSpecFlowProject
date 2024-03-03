using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TaxChatTAF.pages.documents;
using TaxChatTAF.pages.documents.popups;
using TaxChatTAF.pages.documents.signUp;
using TaxChatTAF;
using NUnit.Framework;
using System;
using TaxChatTAFSpecFlow.models;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System.Collections.Generic;
using TaxChatTAFSpecFlow.utils;
using System.Data;
using System.Linq;
using TaxChatTAF.pages.participant;
using TaxChatTAF.pages.preparer;

namespace TaxChatTAFSpecFlow.steps
{
    [Binding]
    public class ParticipantUserSteps
    {
        public IWebDriver driver;                
        public string email;
        public string password;
        public List<string> listTexts;
        public ParticipantUserSteps(IWebDriver _driver) => driver = _driver;        

        [When(@"The user have entered into participant page")]        
        public void givenTheUserHaveEnteredIntoParticipantPage()
        {
            string emailVar = (string)ScenarioContext.Current["email"];
            var passwordVar = (string)ScenarioContext.Current["password"];            
            ParticipantLoginPage participanLoginPage = new ParticipantLoginPage(driver);
            participanLoginPage.typeParticipantID(emailVar);                       
            participanLoginPage.typeParticipantPassword(passwordVar);            
            participanLoginPage.clickOnSignInButton();            
        }

        [Then(@"He enters into upload documents option to upload all required files (.*)")]
        public void thenHeEnterIntoUploadDocumentsOptionToLoadFiles(string isRandomUploadFile)
        {            
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);            
            participantDocumentsPage.clickStepsParticipant();
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            participantDocumentsPage.uploadDocuments("listTextUploadDocuments", isRandomUploadFile);
        }

        [Then(@"Is validated and fill out all the information on the profile section")]
        public void thenIsValidatedAndFillOutTheProfileSetionTest(Table table)
        {
            List<ParticipantData> listParticipants = (List<ParticipantData>)table.CreateSet<ParticipantData>();            
            ParticipantData participantData = UtilitiesSteps.assignValuesParticipantData(listParticipants);
            participantData.isCitizen = "Yes";
            participantData.isBuySell = "No";
            UtilitiesSteps.fillOutProfileSection(driver, listParticipants, participantData);
        }

        [Then(@"Is validated and fill out all the information for non citizens on the profile section")]
        public void thenIsValidatedAndFillOutTheProfileSetionForNoCitizensTest(Table table)
        {
            List<ParticipantData> listParticipants = (List<ParticipantData>)table.CreateSet<ParticipantData>();           
            ParticipantData participantData = UtilitiesSteps.assignValuesParticipantData(listParticipants);
            participantData.isCitizen = "No";
            participantData.isBuySell = "No";
            UtilitiesSteps.fillOutProfileSection(driver, listParticipants, participantData);
        }

        [Then(@"Is validated and fill out all the information to validate the complexity for the option buy or sell a house")]
        public void thenIsValidatedAndFillOutTheProfileSetionForOptionBuyOrSellTest(Table table)
        {
            List<ParticipantData> listParticipants = (List<ParticipantData>)table.CreateSet<ParticipantData>();            
            ParticipantData participantData = UtilitiesSteps.assignValuesParticipantData(listParticipants);
            participantData.isCitizen = "No";
            participantData.isBuySell = "Yes";
            UtilitiesSteps.fillOutProfileSection(driver, listParticipants, participantData);
        }
                
        [Then(@"Is validated and fill out all the information to validate the medical expenses field")]
        public void thenIsValidatedAndFillOutTheProfileSectionToValidateMedicalExpensesTest(Table table)
        {
            List<ParticipantData> listParticipants = (List<ParticipantData>)table.CreateSet<ParticipantData>();
            ParticipantData participantData = UtilitiesSteps.assignValuesParticipantData(listParticipants);
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);
            if (listParticipants[0].isCreatedUser == null)
            {
                participantDocumentsPage.clickStepsParticipant();
            }
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            UtilitiesSteps.fillOutProfileSectionAndValidateMedical(driver, participantData, listParticipants);
        }

        [When(@"The user uploads the required documents depends on the type (.*)")]
        public void thenTheUserUploadsRequiredDocuments(string isLicenseDriver)
        {
            ParticipantPhotoId participantPhotoIdPage = new ParticipantPhotoId(driver);
            if(String.Equals(isLicenseDriver, "Yes"))
            {
                participantPhotoIdPage.processLicenseDocuments();
            }
            else
            {
                participantPhotoIdPage.processPassportDocuments();
            }
        }

        [When(@"The user manage the profile information on the participant page and it is completed")]
        public void thenTheUserManageAndCompleteTheProfieInformationOnParticipantPage()
        {
            string emailVar = (string)ScenarioContext.Current["email"];
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            ParticipantLoginPage participanLoginPage = new ParticipantLoginPage(driver);
            string passwordVar = (string)ScenarioContext.Current["password"];
            participantMyProfilePage.updateStateUserAndAccesPage(emailVar, participanLoginPage);
            participanLoginPage.typeParticipantID(emailVar);
            participanLoginPage.typeParticipantPassword(passwordVar);
            participanLoginPage.clickOnSignInButton();            
            participantMyProfilePage.continueProcessAndAcceptTerms();
        }

        [When(@"He fills out the fields in user creation page so to complete participant information with the name (.*) the lastname (.*) the expectedquote (.*) and depends of user (.*) with the following consents")]
        public void GivenHeFillsOutTheFieldsInUserCreationPage(string name, string lastname, int expectedQuote, string isB2B2CUser, Table table)
        {            
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            participant.howDidYouHearAboutList = "Yes";
            participant.validateAdditionalConsents = "No";
            participant.validatePasswordMessage = "No";
            participant.validateDateOfBirth = "No";
            UtilitiesSteps.creationPageValues(driver, name, lastname, expectedQuote, isB2B2CUser, participant);
        }

        [When(@"He fills out the fields in user creation page so to complete participant information with the name (.*) the lastname (.*) the expectedquote (.*) without selects list how_did_you_hear and depends of user (.*) with the following consents")]
        public void GivenHeFillsOutTheFieldsInUserCreationPageWithoutHowDidYouearList(string name, string lastname, int expectedQuote, string isB2B2CUser, Table table)
        {            
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            participant.howDidYouHearAboutList = "No";
            participant.validateAdditionalConsents = "No";
            participant.validatePasswordMessage = "No";
            participant.validateDateOfBirth = "No";
            UtilitiesSteps.creationPageValues(driver, name, lastname, expectedQuote, isB2B2CUser, participant);
        }

        [When(@"He fills out the fields in user creation page so to complete participant information with the name (.*) the lastname (.*) the expectedquote (.*) selecting Yes in additional consents and depends of user (.*) with the following consents")]
        public void GivenHeFillsOutTheFieldsInUserCreationPageSelectingYesAdditional(string name, string lastname, int expectedQuote, string isB2B2CUser, Table table)
        {            
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            participant.howDidYouHearAboutList = "Yes";
            participant.validateAdditionalConsents = "Yes";
            participant.validatePasswordMessage = "No"; 
            participant.validateDateOfBirth = "No";
            UtilitiesSteps.creationPageValues(driver, name, lastname, expectedQuote, isB2B2CUser, participant);
        }

        [Then(@"He fills out the fields in user creation page so to complete participant information with the name (.*) the lastname (.*) the expectedquote (.*) and depends of user (.*) verifying the password validation message and date of birth")]
        public void GivenHeFillsOutTheFieldsInUserCreationPageValidatingPassMessage(string name, string lastname, int expectedQuote, string isB2B2CUser)
        {            
            ParticipantData participant = new ParticipantData();
            participant.howDidYouHearAboutList = "Yes";
            participant.validateAdditionalConsents = "No";
            participant.validatePasswordMessage = "Yes";
            participant.validateDateOfBirth = "Yes";
            UtilitiesSteps.creationPageValues(driver, name, lastname, expectedQuote, isB2B2CUser, participant);
        }
        
        [When(@"The user manage the profile information on the participant page for reach the consented status")]
        public void thenTheUserManageAndCompleteTheProfieInformationForBackGroundStatus()
        {
            string emailVar = (string)ScenarioContext.Current["email"];
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            ParticipantLoginPage participanLoginPage = new ParticipantLoginPage(driver);
            string passwordVar = (string)ScenarioContext.Current["password"];
            participantMyProfilePage.updateStateUserAndAccesPage(emailVar, participanLoginPage);
            participanLoginPage.typeParticipantID(emailVar);
            participanLoginPage.typeParticipantPassword(passwordVar);
            participanLoginPage.clickOnSignInButton();
            participantMyProfilePage.continueProcessAndAcceptTerms();
        }

        [Then(@"He enters into upload documents option and validate the documents quantity (.*) (.*)")]
        public void thenHeEnterIntoUploadDocumentsOptionToValidateQuantity(string input, string isItin)
        {
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);
            participantDocumentsPage.clickStepsParticipant();
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            participantDocumentsPage.validateDocumentsQuantity("listTextUploadDocuments", input, isItin);
        }

        [Then(@"Is validated the country edition with all document submitted status")]
        public void thenIsValidatedEditioCountryWithAllDocsStatus()
        {                           
                ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
                participantMyProfilePage.fillOutAndValidateCountryEdition();
        }

        [Then(@"The user changes to participant app to edit the country information")]
        public void thenTheUserTriesToChangeTheCountryInformation(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            if(participant.isCreatedUser.Equals("No"))
            {
                participantMyProfilePage.changeTab(2);
            }
            else
            {
                participantMyProfilePage.changeTab(0);
            }
            participantMyProfilePage.validateUserCanNotEditFamilySection();

        }
        
        [Then(@"Is validated the correct entry of country and state fields on the profile section")]
        public void thenIsValidatedTheCorrectEntryOfCountryAndState(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);
            participantDocumentsPage.clickStepsParticipant();
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            participantMyProfilePage.validateCountryAndState(participant);
        }

        [Given(@"The user have entered into participant page with a created user (.*) (.*)")]
        public void givenTheUserHaveEnteredIntoParticipantPageWithCreated(string email, string password)
        {            
            ParticipantLoginPage participanLoginPage = new ParticipantLoginPage(driver);
            ScenarioContext.Current["email"] = email;
            ScenarioContext.Current["password"] = configConstants.USER_PASSWORD;
            participanLoginPage.typeParticipantID(email);
            participanLoginPage.typeParticipantPassword(password);
            participanLoginPage.clickOnSignInButton();
        }

        [When(@"He enters into upload documents option with an user created to upload all required files (.*)")]
        public void thenHeEnterIntoUploadDocumentsOptionWithUserCreatedToLoadFiles(string isRandomUploadFile)
        {            
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);            
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            participantDocumentsPage.uploadDocuments("listTextUploadDocuments", isRandomUploadFile);
        }

        [When(@"The participant user process the payment")]
        public void thenTheParticipantProcessThePayment(Table table)
        {            
            UtilitiesSteps.commonPaymentSteps(driver, table, false);
        }

        [When(@"The participant user process the payment marking mailing address")]
        public void thenTheParticipantProcessThePaymentWithoutMarkingMailingAddress(Table table)
        {            
            UtilitiesSteps.commonPaymentSteps(driver, table, true);
        }

        [Then(@"The user enter into chat option and validate the correct functioning")]
        public void thenTheUserValidateTheCorrectFunctioningChatModule()
        {
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);
            ChatPage chatPage = new ChatPage(driver);
            participantDocumentsPage.clickStepsParticipant();
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            chatPage.reviewAndValidateChatTitles();
        }

        [Given(@"The user manage the recovery password process on participant page (.*) (.*) (.*)")]
        public void givenTheUserManageTheRecoveryPasswordProcess(string email, string name, string lastname)
        {
            ParticipantRecoveryPasswordProcessPage participantRecoveryPasswordProcessPage = new ParticipantRecoveryPasswordProcessPage(driver);
            participantRecoveryPasswordProcessPage.startTheRecoveryPasswordProcess(email);
            string recoveryCode = GmailQuickstart.obtainCodeRecoveryPassword(name, lastname);
            participantRecoveryPasswordProcessPage.createNewPassword(recoveryCode);
            ScenarioContext.Current["email"] = email;
            ScenarioContext.Current["password"] = configConstants.NEW_PASSWORD;

        }

        [Then(@"The user can enter correctly with the new password")]
        public void thenTheUserCanEnterWithTheNewPassword()
        {
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
        }

        [When(@"Are validated the countries with related states")]
        public void whenAreValidatedTheCountriesWithRelatedStates(Table table)
        {
            List<ParticipantData> listParticipants = (List<ParticipantData>)table.CreateSet<ParticipantData>();           
            ParticipantMyProfilePage participantMyProfilePage = new ParticipantMyProfilePage(driver);
            ParticipantDocumentsPage participantDocumentsPage = new ParticipantDocumentsPage(driver);            
            participantDocumentsPage.waitTillParticipantMessageIsDisplayedVoid();
            participantMyProfilePage.validateCountrySelectAndStateSelect(listParticipants);
        }

        [Then(@"Is validated the correct update in the field text after the process")]
        public void whenIsValidatedTheCorrectUpdateInTheField()
        {
            string emailVar = (string)ScenarioContext.Current["email"];
            string text = Utilities.getTextHowDidYouHearOtherOptionList(emailVar);
            Assert.AreEqual(configConstants.OTHER_OPTION_TEXT_HOW_DID_LIST, text);
        }
    }
}
