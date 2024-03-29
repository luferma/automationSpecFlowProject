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
    [NUnit.Framework.DescriptionAttribute("Validate required documents after complete profile information for B2B2C users")]
    public partial class ValidateRequiredDocumentsAfterCompleteProfileInformationForB2B2CUsersFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ValidateDocumentsProfileInformation.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Validate required documents after complete profile information for B2B2C users", "\tIn order to validate the requested documents once the profile information is com" +
                    "pleted\r\n\tAs a partipant user\r\n\tI want to validate the requested documents on the" +
                    " participant tab", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Validate requested documents on the participant information")]
        [NUnit.Framework.CategoryAttribute("validateRequestedDocuments")]
        [NUnit.Framework.TestCaseAttribute("Yes", "Bernie", "Jackson", "1", "No", "1", "299", "Silver", "Yes", "Yes", "Yes", "Yes", "No", "lf.martinez+sub_cc_@globant.com", "No", "Yes", "No", "No", "Yes", "Married", "Yes", "Yes", "No", "No", null)]
        [NUnit.Framework.TestCaseAttribute("Yes", "Robert", "Pattson", "1", "No", "1", "299", "Silver", "Yes", "Yes", "Yes", "Yes", "No", "lf.martinez+sub_cc_@globant.com", "No", "Yes", "No", "No", "No", "Married", "Yes", "Yes", "No", "No", null)]
        public virtual void ValidateRequestedDocumentsOnTheParticipantInformation(
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
                    string isRandomUploadFile, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "validateRequestedDocuments"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate requested documents on the participant information", null, @__tags);
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
                TechTalk.SpecFlow.Table table48 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "lastName",
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table48.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", lastName),
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 8
 testRunner.Given("The user have entered into onboarding option", ((string)(null)), table48, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table49 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "isValidationSpigotGroup",
                            "isValidationTileByParts"});
                table49.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", isValidationSpigotGroup),
                            string.Format("{0}", isValidationTileByParts)});
#line 11
 testRunner.When("He fills out the fields related to tax situation", ((string)(null)), table49, "When ");
#line hidden
                TechTalk.SpecFlow.Table table50 = new TechTalk.SpecFlow.Table(new string[] {
                            "consentAditionalQuestion",
                            "consentMarried",
                            "consentFinantialReport",
                            "consentReportableTransaction",
                            "isMarriedOnBoarding"});
                table50.AddRow(new string[] {
                            string.Format("{0}", consentAditionalQuestion),
                            string.Format("{0}", consentMarried),
                            string.Format("{0}", consentFinantialReport),
                            string.Format("{0}", consentReportableTransaction),
                            string.Format("{0}", isMarriedOnBoarding)});
#line 14
 testRunner.And(string.Format("He fills out the fields in user creation page so to complete participant informat" +
                            "ion with the name {0} the lastname {1} the expectedquote {2} and depends of user" +
                            " {3} with the following consents", name, lastName, expectedQuote, isB2B2CUser), ((string)(null)), table50, "And ");
#line hidden
#line 17
 testRunner.And(string.Format("He confirms the e-mail sent with the email, the name {0} and the lastname {1} for" +
                            " the type of user {2}", name, lastName, isB2B2CUser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.And("The user have entered into participant page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.Then(string.Format("He enters into upload documents option to upload all required files {0}", isRandomUploadFile), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table51 = new TechTalk.SpecFlow.Table(new string[] {
                            "typeDependent",
                            "firstNameDependent",
                            "lastNameDependent",
                            "dateOfBirth",
                            "ssn",
                            "dependentNotSsn",
                            "isMarriedOnBoarding",
                            "spouseNotSsn",
                            "isMarriedDependent",
                            "markCompleteOptions",
                            "maritalStatus",
                            "hadDistributions",
                            "directAndsameBankAccount",
                            "checkMailedAndDirect",
                            "isRandomUploadFile",
                            "isB2B2CUser"});
                table51.AddRow(new string[] {
                            "son",
                            "Jhon",
                            "Kent",
                            "December,7,1962",
                            "123456789",
                            "Yes",
                            string.Format("{0}", isMarriedOnBoarding),
                            string.Format("{0}", spouseNotSsn),
                            string.Format("{0}", isMarriedDependent),
                            string.Format("{0}", markCompleteOptions),
                            string.Format("{0}", maritalStatus),
                            string.Format("{0}", hadDistributions),
                            string.Format("{0}", directAndsameBankAccount),
                            string.Format("{0}", checkMailedAndDirect),
                            string.Format("{0}", isRandomUploadFile),
                            string.Format("{0}", isB2B2CUser)});
                table51.AddRow(new string[] {
                            "daughter",
                            "Joseph",
                            "Claus",
                            "May,7,1972",
                            "515487987",
                            "Yes",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table51.AddRow(new string[] {
                            "parent",
                            "Irina",
                            "Maden",
                            "June,7,1981",
                            "154678942",
                            "No",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table51.AddRow(new string[] {
                            "other",
                            "Jhon",
                            "Clark",
                            "January,7,1969",
                            "193564874",
                            "No",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
#line 20
 testRunner.And("Is validated and fill out all the information for non citizens on the profile sec" +
                        "tion", ((string)(null)), table51, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate the quantity of requested documents on the participant information")]
        [NUnit.Framework.CategoryAttribute("validateQuantityDocuments")]
        [NUnit.Framework.TestCaseAttribute("Yes", "Christopher", "Jackson", "5", "", "4", "259", "Yes", "Yes", "Yes", "Yes", "No", "lf.martinez+sub_cc_@globant.com", "Yes", "Yes", "No", null)]
        [NUnit.Framework.TestCaseAttribute("Yes", "John", "Martin", "1", "Yes", "4", "624", "Yes", "Yes", "Yes", "Yes", "No", "lf.martinez+sub_pd_@globant.com", "Yes", "No", "Yes", null)]
        public virtual void ValidateTheQuantityOfRequestedDocumentsOnTheParticipantInformation(
                    string isB2B2CUser, 
                    string name, 
                    string lastName, 
                    string tile, 
                    string internalOption, 
                    string input, 
                    string expectedQuote, 
                    string consentAditionalQuestion, 
                    string consentMarried, 
                    string consentFinantialReport, 
                    string consentReportableTransaction, 
                    string isValidationSpigotGroup, 
                    string emailPattern, 
                    string isValidationTileByParts, 
                    string isMarriedOnBoarding, 
                    string isItin, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "validateQuantityDocuments"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate the quantity of requested documents on the participant information", null, @__tags);
#line 33
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
                TechTalk.SpecFlow.Table table52 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "lastName",
                            "tile",
                            "internalOption",
                            "input",
                            "emailPattern"});
                table52.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", lastName),
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", emailPattern)});
#line 34
 testRunner.Given("The user have entered into onboarding option", ((string)(null)), table52, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table53 = new TechTalk.SpecFlow.Table(new string[] {
                            "tile",
                            "internalOption",
                            "input",
                            "isValidationSpigotGroup",
                            "isValidationTileByParts"});
                table53.AddRow(new string[] {
                            string.Format("{0}", tile),
                            string.Format("{0}", internalOption),
                            string.Format("{0}", input),
                            string.Format("{0}", isValidationSpigotGroup),
                            string.Format("{0}", isValidationTileByParts)});
#line 37
 testRunner.When("He fills out the fields related to tax situation", ((string)(null)), table53, "When ");
#line hidden
                TechTalk.SpecFlow.Table table54 = new TechTalk.SpecFlow.Table(new string[] {
                            "consentAditionalQuestion",
                            "consentMarried",
                            "consentFinantialReport",
                            "consentReportableTransaction",
                            "isMarriedOnBoarding"});
                table54.AddRow(new string[] {
                            string.Format("{0}", consentAditionalQuestion),
                            string.Format("{0}", consentMarried),
                            string.Format("{0}", consentFinantialReport),
                            string.Format("{0}", consentReportableTransaction),
                            string.Format("{0}", isMarriedOnBoarding)});
#line 40
 testRunner.And(string.Format("He fills out the fields in user creation page so to complete participant informat" +
                            "ion with the name {0} the lastname {1} the expectedquote {2} and depends of user" +
                            " {3} with the following consents", name, lastName, expectedQuote, isB2B2CUser), ((string)(null)), table54, "And ");
#line hidden
#line 43
 testRunner.And(string.Format("He confirms the e-mail sent with the email, the name {0} and the lastname {1} for" +
                            " the type of user {2}", name, lastName, isB2B2CUser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
 testRunner.And("The user have entered into participant page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.Then(string.Format("He enters into upload documents option and validate the documents quantity {0} {1" +
                            "}", input, isItin), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
