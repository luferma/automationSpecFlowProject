Feature: Validate different options and information on profile module
	In order to validate the diffent options and information
	As a partipant user
	I want to validate the different options and information on profile module

@validateChangeComplexityBuySellOrHouse
Scenario Outline: Validate complexity when is selected the buy or sell house option in about me section
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then He enters into upload documents option to upload all required files <isRandomUploadFile>
	And Is validated and fill out all the information to validate the complexity for the option buy or sell a house
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	When The preparer searches the participant user and validates the complexity with the email preparer, the pass preparer and the name <lastName>
	Then The user should see the correct complexity
	| complexityExpected  |
	| <complexityExpected>|
	
	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|Yes            | Bernie     | Jackson    | 1        | No			 | 0     | 199            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |				

@validateMedicalExpensesField
Scenario Outline: Validate medical expenses field on profile module
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page	
	Then Is validated and fill out all the information to validate the medical expenses field
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding | spouseNotSsn  | maritalStatus  | isB2B2CUser  |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | isMarriedDependent> | <spouseNotSsn>| <maritalStatus>| <isB2B2CUser>|	
	
	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent |  maritalStatus |
	|Yes            | Bernie     | Jackson    | 1        | No			 | 0     | 199            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 |  Married       |

@validateEditCountryAllDocsSubmittedStatus
Scenario Outline: Validate the edition of country in all documents submitted status
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then He enters into upload documents option to upload all required files <isRandomUploadFile>
	And Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	And Is validated the country edition with all document submitted status

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |
	|Yes            | Bernie     | Jackson    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |

@validateDoesNotEditCountryAllDocsConfirmedStatus
Scenario Outline: Validate that the user can not edit the country fields when rearch the status all documents submitted confirmed
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then He enters into upload documents option to upload all required files <isRandomUploadFile>
	And Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	When The preparer searches the participant user with the name <lastName> and confirms the documents
	| isCreatedUser |
	| No            |
	Then The user changes to participant app to edit the country information
	| isCreatedUser |
	| No           |

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|Yes            | Bernie     | Jackson    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |