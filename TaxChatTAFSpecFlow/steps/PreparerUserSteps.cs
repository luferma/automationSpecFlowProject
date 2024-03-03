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
    public class PreparerUserSteps
    {
        public IWebDriver driver;                
        public string email;
        public string password;
        public List<string> listTexts;
        private List<string> status;
        private List<string> complexity;
        public PreparerUserSteps(IWebDriver _driver) => driver = _driver;        

        [When(@"The preparer searches the participant user with the name (.*) and complete the process until return release state")]
        public void thenThePreparerCompleteTheReturnReleasedProcess(string lastname, Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            UtilitiesSteps utilitiesSteps = new UtilitiesSteps();
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            utilitiesSteps.openPreparerPageAndConfirmsDocuments(driver, lastname, participant);
            searchParticipantsPage.preparerAssignAditionalState();
            searchParticipantsPage.manualReturnRelease();
        }

        [When(@"The preparer user enters into preparer application and validate consented status (.*)")]
        public void WhenThePreparerSearchesTheParticipantUserAndValidatesTheBackGroundCheck(string lastname)
        {
            status = UtilitiesSteps.openPreparerPageAndReviewComplexity(driver, lastname, "Yes");
        }

        [Then(@"The preparer should see the correct status (.*)")]
        public void ThenThePreparerShouldSeeTheCorrectStatus(string expectedStatus)
        {
            expectedStatus = expectedStatus.Replace("\"", "");
            Assert.AreEqual(expectedStatus, status[0]);
        }

        [When(@"The preparer searches the participant user and validates the complexity with the email preparer, the pass preparer and the name (.*)")]
        public void WhenThePreparerSearchesTheParticipantUserAndValidatesTheComplexity(string lastname)
        {
            complexity = UtilitiesSteps.openPreparerPageAndReviewComplexity(driver, lastname, "No");
        }
        
        [Then(@"The user should see the correct complexity")]
        public void ThenTheUserShouldSeeTheCorrectlyComplexity(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            int quoteValidate = (int)ScenarioContext.Current["quoteValidate"];
            ScenarioContext.Current["complexityValidate"] = participant.complexityExpected;
            Assert.AreEqual(participant.complexityExpected, complexity[0]);
            Assert.AreEqual(quoteValidate.ToString(), complexity[1].Replace(",", ""));
            Assert.AreEqual(quoteValidate.ToString(), complexity[2].Replace(",", ""));
        }

        [Then(@"The preparer searches the participant user and validates the CCH connection with the user (.*)")]
        public void thenThePreparerValidateCchConnection(string lastname, Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            UtilitiesSteps utilitiesSteps = new UtilitiesSteps();            
            utilitiesSteps.openPreparerPageAndValidateCchProcess(driver, lastname, participant);
        }

        [When(@"The user have entered into preparer page and validate the information for the country and state")]
        public void WhenTheUserEntersIntoParticipantPageToValidateStateAndCountry(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();            
            UtilitiesSteps.commonStepsPreparer(driver, participant);
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            searchParticipantsPage.preparerValidateCountryAndStateValidation(participant);
        }

        [Then(@"The preparer searches the participant user and validates the taxpayer name in the consent section")]
        public void ThenThePreparerSearchesTheParticipantUserAndValidatesTheTaxpayerNameInConsentSection(Table table)
        {
            ParticipantData participant = table.CreateInstance<ParticipantData>();
            string email = (string)ScenarioContext.Current["email"];
            SearchParticipantsPage searchParticipantsPage = new SearchParticipantsPage(driver);
            ConfigPreparerPage configPreparerPage = new ConfigPreparerPage(driver);            
            participant.isCreatedUser = "No";
            participant.email = email;            
            UtilitiesSteps.commonStepsPreparer(driver, participant);
            searchParticipantsPage.preparerSearchsAndValidatesConsentName(participant);
            configPreparerPage.openConfigPageAndValidatesName(participant);
        }        
    }
}
