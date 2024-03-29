﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TaxChatTAFSpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Validate participant information")]
    public partial class ValidateParticipantInformationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ValidationInTheParticipantInformation.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Validate participant information", "\tIn order to validate important information of the participant information\r\n\tAs a" +
                    " partipant user\r\n\tI want to validate information and fields required in the appl" +
                    "ication", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate required list How Did Your Hear on participant information")]
        [NUnit.Framework.CategoryAttribute("completeValidateOptionalListHowDid")]
        [NUnit.Framework.TestCaseAttribute("Yes", "Christopher", "Jackson", "1", "No", "1", "299", "Silver", "Yes", "Yes", "Yes", "Yes", "No", "lf.martinez+sub_cc_@globant.com", "No", "No", "No", "No", "No", "Married", "Yes", "Yes", "No", "Yes", "No", null)]
        public virtual void ValidateRequiredListHowDidYourHearOnParticipantInformation(
                    string isB2B2CUser, 
                    string name, 
                    string lastName, 
                    string tile, 
                    string internalOption, 
                    string input, 
                    string expectedQuote, 
                    string complexityExpected, 
                    string consentAditionalQuestion, 
                    string consentMarried, 
                    string consentFinantialReport, 
                    string consentReportableTransaction, 
                    string isValidationSpigotGroup, 
                    string emailPattern, 
                    string isValidationTileByParts, 
                    string isMarriedOnBoarding, 
                    string spouseNotSsn, 
                    string isMarriedDependent, 
                    string markCompleteOptions, 
                    string maritalStatus, 
                    string hadDistributions, 
                    string directAndsameBankAccount, 
                    string checkMailedAndDirect, 
                    string isLicenseDriver, 
                    string isRandomUploadFile, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "completeValidateOptionalListHowDid"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate required list How Did Your Hear on participant information", null, @__tags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table92 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "lastName",
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table92.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", lastName),
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 8
 testRunner.Given("The user have entered into onboarding option", ((string)(null)), table92, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table93 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "isValidationSpigotGroup",
                            "isValidationTileByParts"});
                table93.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", isValidationSpigotGroup),
                            string.Format("{0}", isValidationTileByParts)});
#line 11
 testRunner.When("He fills out the fields related to tax situation", ((string)(null)), table93, "When ");
#line hidden
                TechTalk.SpecFlow.Table table94 = new TechTalk.SpecFlow.Table(new string[] {
                            "consentAditionalQuestion",
                            "consentMarried",
                            "consentFinantialReport",
                            "consentReportableTransaction",
                            "isMarriedOnBoarding"});
                table94.AddRow(new string[] {
                            string.Format("{0}", consentAditionalQuestion),
                            string.Format("{0}", consentMarried),
                            string.Format("{0}", consentFinantialReport),
                            string.Format("{0}", consentReportableTransaction),
                            string.Format("{0}", isMarriedOnBoarding)});
#line 14
 testRunner.And(string.Format("He fills out the fields in user creation page so to complete participant informat" +
                            "ion with the name {0} the lastname {1} the expectedquote {2} without selects lis" +
                            "t how_did_you_hear and depends of user {3} with the following consents", name, lastName, expectedQuote, isB2B2CUser), ((string)(null)), table94, "And ");
#line hidden
#line 17
 testRunner.And(string.Format("He confirms the e-mail sent with the email, the name {0} and the lastname {1} for" +
                            " the type of user {2}", name, lastName, isB2B2CUser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.And("The user have entered into participant page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate additional consents on participant information")]
        [NUnit.Framework.CategoryAttribute("validateAdditionalConsents")]
        [NUnit.Framework.TestCaseAttribute("No", "Jhon", "Phillips", "1", "No", "1", "299", "Bronze", "Yes", "Yes", "Yes", "Yes", "No", "taxchatglbtesting1+taxchat@gmail.com", "No", "No", "No", "No", "No", "Married", "Yes", "Yes", "No", "Yes", "No", null)]
        public virtual void ValidateAdditionalConsentsOnParticipantInformation(
                    string isB2B2CUser, 
                    string name, 
                    string lastName, 
                    string tile, 
                    string internalOption, 
                    string input, 
                    string expectedQuote, 
                    string complexityExpected, 
                    string consentAditionalQuestion, 
                    string consentMarried, 
                    string consentFinantialReport, 
                    string consentReportableTransaction, 
                    string isValidationSpigotGroup, 
                    string emailPattern, 
                    string isValidationTileByParts, 
                    string isMarriedOnBoarding, 
                    string spouseNotSsn, 
                    string isMarriedDependent, 
                    string markCompleteOptions, 
                    string maritalStatus, 
                    string hadDistributions, 
                    string directAndsameBankAccount, 
                    string checkMailedAndDirect, 
                    string isLicenseDriver, 
                    string isRandomUploadFile, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "validateAdditionalConsents"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate additional consents on participant information", null, @__tags);
#line 25
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table95 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "lastName",
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table95.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", lastName),
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 26
 testRunner.Given("The user have entered into onboarding option", ((string)(null)), table95, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table96 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "isValidationSpigotGroup",
                            "isValidationTileByParts"});
                table96.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", isValidationSpigotGroup),
                            string.Format("{0}", isValidationTileByParts)});
#line 29
 testRunner.When("He fills out the fields related to tax situation", ((string)(null)), table96, "When ");
#line hidden
                TechTalk.SpecFlow.Table table97 = new TechTalk.SpecFlow.Table(new string[] {
                            "consentAditionalQuestion",
                            "consentMarried",
                            "consentFinantialReport",
                            "consentReportableTransaction",
                            "isMarriedOnBoarding"});
                table97.AddRow(new string[] {
                            string.Format("{0}", consentAditionalQuestion),
                            string.Format("{0}", consentMarried),
                            string.Format("{0}", consentFinantialReport),
                            string.Format("{0}", consentReportableTransaction),
                            string.Format("{0}", isMarriedOnBoarding)});
#line 32
 testRunner.And(string.Format("He fills out the fields in user creation page so to complete participant informat" +
                            "ion with the name {0} the lastname {1} the expectedquote {2} selecting Yes in ad" +
                            "ditional consents and depends of user {3} with the following consents", name, lastName, expectedQuote, isB2B2CUser), ((string)(null)), table97, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Decline terms of use at the beginning of the onboarding")]
        [NUnit.Framework.CategoryAttribute("declineTermsOfUse")]
        [NUnit.Framework.TestCaseAttribute("1", "No", "1", "taxchatglbtesting1+taxchat@gmail.com", null)]
        public virtual void DeclineTermsOfUseAtTheBeginningOfTheOnboarding(string tile, string internalOption, string input, string emailPattern, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "declineTermsOfUse"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Decline terms of use at the beginning of the onboarding", null, @__tags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table98 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table98.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 42
 testRunner.Given("The user have entered into onboarding option to decline the terms of use", ((string)(null)), table98, "Given ");
#line hidden
#line 45
 testRunner.When("The user declines the terms of use", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
 testRunner.Then("The user sees the dialog window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Review password validation message and dato of birth on participant information")]
        [NUnit.Framework.CategoryAttribute("validatePasswordMessageAndDateOfBirth")]
        [NUnit.Framework.TestCaseAttribute("No", "Jhon", "Phillips", "1", "No", "1", "299", "No", "taxchatglbtesting1+taxchat@gmail.com", "No", null)]
        public virtual void ReviewPasswordValidationMessageAndDatoOfBirthOnParticipantInformation(string isB2B2CUser, string name, string lastName, string tile, string internalOption, string input, string expectedQuote, string isValidationSpigotGroup, string emailPattern, string isValidationTileByParts, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "validatePasswordMessageAndDateOfBirth"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Review password validation message and dato of birth on participant information", null, @__tags);
#line 53
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table99 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "lastName",
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table99.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", lastName),
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 54
 testRunner.Given("The user have entered into onboarding option", ((string)(null)), table99, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table100 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "isValidationSpigotGroup",
                            "isValidationTileByParts"});
                table100.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", isValidationSpigotGroup),
                            string.Format("{0}", isValidationTileByParts)});
#line 57
 testRunner.When("He fills out the fields related to tax situation", ((string)(null)), table100, "When ");
#line hidden
#line 60
 testRunner.Then(string.Format("He fills out the fields in user creation page so to complete participant informat" +
                            "ion with the name {0} the lastname {1} the expectedquote {2} and depends of user" +
                            " {3} verifying the password validation message and date of birth", name, lastName, expectedQuote, isB2B2CUser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Review the consented status user after of apply the back ground check")]
        [NUnit.Framework.CategoryAttribute("validateConsentedStatus")]
        [NUnit.Framework.TestCaseAttribute("No", "Christopher", "Jackson", "1", "No", "1", "299", "Silver", "Yes", "Yes", "Yes", "Yes", "No", "taxchatglbtesting1+taxchat@gmail.com", "No", "No", "Yes", "No", null)]
        public virtual void ReviewTheConsentedStatusUserAfterOfApplyTheBackGroundCheck(
                    string isB2B2CUser, 
                    string name, 
                    string lastName, 
                    string tile, 
                    string internalOption, 
                    string input, 
                    string expectedQuote, 
                    string complexityExpected, 
                    string consentAditionalQuestion, 
                    string consentMarried, 
                    string consentFinantialReport, 
                    string consentReportableTransaction, 
                    string isValidationSpigotGroup, 
                    string emailPattern, 
                    string isValidationTileByParts, 
                    string isMarriedOnBoarding, 
                    string isLicenseDriver, 
                    string isRandomUploadFile, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "validateConsentedStatus"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Review the consented status user after of apply the back ground check", null, @__tags);
#line 67
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table101 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "lastName",
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table101.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", lastName),
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 68
 testRunner.Given("The user have entered into onboarding option", ((string)(null)), table101, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table102 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "isValidationSpigotGroup",
                            "isValidationTileByParts"});
                table102.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", isValidationSpigotGroup),
                            string.Format("{0}", isValidationTileByParts)});
#line 71
 testRunner.When("He fills out the fields related to tax situation", ((string)(null)), table102, "When ");
#line hidden
                TechTalk.SpecFlow.Table table103 = new TechTalk.SpecFlow.Table(new string[] {
                            "consentAditionalQuestion",
                            "consentMarried",
                            "consentFinantialReport",
                            "consentReportableTransaction",
                            "isMarriedOnBoarding"});
                table103.AddRow(new string[] {
                            string.Format("{0}", consentAditionalQuestion),
                            string.Format("{0}", consentMarried),
                            string.Format("{0}", consentFinantialReport),
                            string.Format("{0}", consentReportableTransaction),
                            string.Format("{0}", isMarriedOnBoarding)});
#line 74
 testRunner.And(string.Format("He fills out the fields in user creation page so to complete participant informat" +
                            "ion with the name {0} the lastname {1} the expectedquote {2} and depends of user" +
                            " {3} with the following consents", name, lastName, expectedQuote, isB2B2CUser), ((string)(null)), table103, "And ");
#line hidden
#line 77
 testRunner.And(string.Format("He confirms the e-mail sent with the email, the name {0} and the lastname {1} for" +
                            " the type of user {2}", name, lastName, isB2B2CUser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 78
 testRunner.And("The user have entered into participant page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
 testRunner.And(string.Format("The user uploads the required documents depends on the type {0}", isLicenseDriver), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 80
 testRunner.And("The user manage the profile information on the participant page for reach the con" +
                        "sented status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 81
 testRunner.When(string.Format("The preparer user enters into preparer application and validate consented status " +
                            "{0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 82
 testRunner.Then("The preparer should see the correct status \"Consented\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
