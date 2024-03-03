using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TaxChatTAF.pages.documents;
using TaxChatTAF.pages.documents.popups;
using TaxChatTAF.pages.documents.signUp;
using TaxChatTAF.pages.preparer;
using TaxChatTAF;
using NUnit.Framework;
using System;
using TaxChatTAFSpecFlow.models;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System.Collections.Generic;
using TaxChatTAFSpecFlow.utils;
using System.IO;
using System.Linq.Expressions;
using System.Globalization;

namespace TaxChatTAFSpecFlow.steps
{
    [Binding]
    public class OnboardingUserSteps
    {
        public IWebDriver driver;                
        public string email;
        public string password;
        public List<string> tileList;
        public List<string> textDocumentUpload = new List<string>();
        public OnboardingUserSteps(IWebDriver _driver) => driver = _driver;
        
        [Given(@"The user have entered into onboarding option")]
        public void givenTheUserHaveEnteredIntoOnboardingOption(Table table)
        {           
                ParticipantData participant = table.CreateInstance<ParticipantData>();                
                LoginPage loginPage = new LoginPage(driver);
                loginPage.clickOnSignUpButton();

                ElegibilityPage elegibilityPage = new ElegibilityPage(driver);
                
                string emailPattern = participant.emailPattern;
                email = elegibilityPage.validateRegisteredUser(driver, emailPattern);

                tileList = Utilities.tileListSeparate(participant.tile);

                TermsOfUse termsOfUse = new TermsOfUse(driver);
                termsOfUse.acceptTerms();
                termsOfUse.clickOnNextButton();
                       
                VerifyName verifyName = new VerifyName(driver);            
                verifyName.typeFirstName(participant.name);
                verifyName.typeLastName(participant.lastName);                       
                if (participant.discountCode!=null)
                {
                   verifyName.typeReferralCode(participant.discountCode);
                }                
                verifyName.clickOnNextButton();
                ScenarioContext.Current["email"] = email;
                ScenarioContext.Current["password"] = configConstants.USER_PASSWORD;
                ScenarioContext.Current["tile"] = participant.tile;
                ScenarioContext.Current["internal_option"] = participant.internalOption;
                ScenarioContext.Current["input"] = participant.input;
                ScenarioContext.Current["isValidationSpigotGroup"] = participant.isValidationSpigotGroup;
                ScenarioContext.Current["emailPattern"] = participant.emailPattern;                
        }

        [Given(@"The user have entered into onboarding option to decline the terms of use")]
        public void givenTheUserHaveEnteredIntoOnboardingOptionDecliningTermsOfUse(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.clickOnSignUpButton();

            ElegibilityPage elegibilityPage = new ElegibilityPage(driver);

            string emailPattern = participant.emailPattern;
            email = elegibilityPage.validateRegisteredUser(driver, emailPattern);

            tileList = Utilities.tileListSeparate(participant.tile);
            
            ScenarioContext.Current["email"] = email;
            ScenarioContext.Current["password"] = configConstants.USER_PASSWORD;                      
        }

        [When(@"The user declines the terms of use")]
        public void whenTheUserDeclinesTheTermsOfUse()
        {            
            TermsOfUse termsOfUse = new TermsOfUse(driver);
            termsOfUse.declineTerms();
            termsOfUse.clickOnNextButton();            
        }

        [Then(@"The user sees the dialog window")]
        public void thenTheUserSeesTheDialogWindow()
        {
            TermsOfUse termsOfUse = new TermsOfUse(driver);            
            termsOfUse.dialogDeclineTerms();            
        }

        [When(@"He fills out the fields related to tax situation")]
        public void WhenHeFillsOutTheFieldsRelatedToTaxSituation(Table table)
        {
            ConfigPage configPage = new ConfigPage(driver);
            UtilitiesSteps utilitiesSteps = new UtilitiesSteps();
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            textDocumentUpload = utilitiesSteps.SelectOptionTiles(driver, table, textDocumentUpload, tileList);                
            textDocumentUpload.Add("Government issued ID");
            textDocumentUpload.Add("Prior year return (complete federal and state returns)");
            ScenarioContext.Current["listTextUploadDocuments"] = textDocumentUpload;
            ScenarioContext.Current["tileList"] = tileList;
            ScenarioContext.Current["isValidationTileByParts"] = participant.isValidationTileByParts;
            configPage.moveToNextButton();
            configPage.clickOnNextButton();
        }

        [When(@"He fills out the fields in user creation page with the name (.*) the lastname (.*) the expectedquote (.*) and depends of user (.*) with the following consents")]
        public void GivenHeFillsOutTheFieldsInUserCreationPage(string name, string lastname, int expectedQuote, string isB2B2CUser, Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            participant.name = name;
            participant.lastName = lastname;
            participant.expectedQuote = expectedQuote;
            participant.isB2B2CUser = isB2B2CUser;
            int quoteValidate = validateDiscountQuote(participant, expectedQuote);
            ScenarioContext.Current["quoteWithoutDiscount"] = expectedQuote;
            ScenarioContext.Current["quoteValidate"] = quoteValidate;
            participant.howDidYouHearAboutList = "Yes";
            participant.validateAdditionalConsents = "No";
            participant.validatePasswordMessage = "No";
            participant.validateDateOfBirth = "No";

            if (participant.showQuotePage != null && participant.showQuotePage.Equals("No"))
            {                
                Utilities.fillOutFieldsCreationPage(participant, driver);
            }
            else
            {
                CreatePage createPage = new CreatePage(driver);
                createPage.waitTillQuoteIsDisplayedVoid();
                Quote quote = new Quote(driver);
                Assert.AreEqual(quote.getQuoteValue(), "$" + quoteValidate);

                if (String.Equals(participant.isValidationSpigotGroup, "No"))
                {                    
                    Utilities.fillOutFieldsCreationPage(participant, driver);
                }
            }                
        }

        [When(@"He confirms the e-mail sent with the email, the name (.*) and the lastname (.*) for the type of user (.*)")]
        public void WhenHeConfirmsTheE_MailSent(string name, string lastname, string isB2B2CUser)
        {
            MailPage mail = new MailPage(driver);
            if (String.Equals(isB2B2CUser, "Yes"))
            {                
                mail.openMailBrowserPage();                
                mail.searchMail(name, lastname, isB2B2CUser);
            }
            else
            {
                string link = GmailQuickstart.obtainLinkGmailConfirmation(name, lastname);
                mail.refreshURLConfirmed(link, isB2B2CUser);
            }            
        }
        
        [Then(@"He should see a total quote of (.*)")]
        public void ThenHeShouldSeeATotalQuoteOf(int expectedQuote)
        {            
                Quote quote = new Quote(driver);
                Assert.AreEqual(quote.getQuoteValue(), "$"+expectedQuote);            
        }
        
        [When(@"The preparer searches the participant user with the name (.*) and confirms the documents")]
        public void WhenThePreparerSearchesTheParticipantUserAndConfirmsDocuments(string lastname, Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            UtilitiesSteps utilitiesSteps = new UtilitiesSteps();
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            utilitiesSteps.openPreparerPageAndConfirmsDocuments(driver, lastname, participant);
            searchParticipantsPage.preparerAssignAditionalState();
        }

        [Given(@"The user have entered into onboarding option to validate the referral code option")]
        public void givenTheUserHaveEnteredIntoOnboardingOptionToValidateReferralCode(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.clickOnSignUpButton();

            ElegibilityPage elegibilityPage = new ElegibilityPage(driver);

            string emailPattern = participant.emailPattern;
            email = elegibilityPage.validateRegisteredUser(driver, emailPattern);

            tileList = Utilities.tileListSeparate(participant.tile);

            TermsOfUse termsOfUse = new TermsOfUse(driver);
            termsOfUse.acceptTerms();
            termsOfUse.clickOnNextButton();

            VerifyName verifyName = new VerifyName(driver);
            verifyName.typeFirstName(participant.name);
            verifyName.typeLastName(participant.lastName);
        }

        [When(@"Is entered an invalid referral code")]
        public void WhenIsEnteredAnInvalidReferralCode(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            VerifyName verifyName = new VerifyName(driver);            
            verifyName.typeReferralCode(participant.discountCode);
            verifyName.clickOnNextButton();
        }

        [Then(@"Is validated that appear the correct message")]
        public void ThenIsValidatedAppearTheCorrectMessage()
        {            
            VerifyName verifyName = new VerifyName(driver);
            verifyName.validateReferralCode();
        }

        public int validateDiscountQuote(ParticipantData participant, int expectedQuote)
        {
            int answer;
            if(participant.discountFixed != null && !participant.discountFixed.Equals(""))
            {
                ScenarioContext.Current["discountType"] = "Discount fixed";
                answer = expectedQuote - Int32.Parse(participant.discountFixed);
                ScenarioContext.Current["discountValue"] = Int32.Parse(participant.discountFixed);
            }
            else if (participant.discountPercentage != null && !participant.discountPercentage.Equals(""))
            {
                ScenarioContext.Current["discountType"] = "Discount percentage";
                double multiplication = expectedQuote * Int32.Parse(participant.discountPercentage);                
                double discountValue = multiplication / 100;
                discountValue = Math.Round(discountValue, 0, MidpointRounding.AwayFromZero);                
                answer = expectedQuote - Convert.ToInt32(discountValue);
                ScenarioContext.Current["discountValue"] = Convert.ToInt32(discountValue);
            }
            else if (participant.discountFlat != null && !participant.discountFlat.Equals(""))
            {
                ScenarioContext.Current["discountType"] = "Discount flat";
                answer = Int32.Parse(participant.discountFlat);
                ScenarioContext.Current["discountValue"] = 0;
            }
            else
            {
                ScenarioContext.Current["discountType"] = "None";
                answer = expectedQuote;
                ScenarioContext.Current["discountValue"] = 0;
            }
            if(answer<0)
            {
                answer = 0;
            }

            return answer;
        }
    }
}