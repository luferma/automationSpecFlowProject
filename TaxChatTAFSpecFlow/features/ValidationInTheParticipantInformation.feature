Feature: Validate participant information 
	In order to validate important information of the participant information
	As a partipant user
	I want to validate information and fields required in the application

@completeValidateOptionalListHowDid
Scenario Outline: Validate required list How Did Your Hear on participant information
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> without selects list how_did_you_hear and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>|	
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page

	Examples: 
	|isB2B2CUser    | name        | lastName   | tile     | internalOption | input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                             | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isLicenseDriver | isRandomUploadFile |	
	|Yes            | Christopher | Jackson    | 1        | No			   | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com      | No                       | No                  | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | Yes             | No                 |	

@validateAdditionalConsents
Scenario Outline: Validate additional consents on participant information
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> selecting Yes in additional consents and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>|		

	Examples: 
	|isB2B2CUser    | name        | lastName   | tile     | internalOption | input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                             | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isLicenseDriver | isRandomUploadFile |
	|No             | Jhon        | Phillips   | 1        | No			   | 1     | 299            | Bronze             | Yes                      | Yes            | Yes                    | Yes                            | No                          | taxchatglbtesting1+taxchat@gmail.com | No                       | No                  | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | Yes             | No                 |
	
@declineTermsOfUse
Scenario Outline: Decline terms of use at the beginning of the onboarding
	Given The user have entered into onboarding option to decline the terms of use
	| tile   | internalOption  | input   | emailPattern  |
	| <tile> | <internalOption>| <input> | <emailPattern>|
	When The user declines the terms of use
	Then The user sees the dialog window

	Examples: 
	| tile     | internalOption | input | emailPattern                             |
	| 1        | No			    | 1     | taxchatglbtesting1+taxchat@gmail.com |

@validatePasswordMessageAndDateOfBirth
Scenario Outline: Review password validation message and dato of birth on participant information
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	Then He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> verifying the password validation message and date of birth

	Examples: 
	|isB2B2CUser    | name        | lastName   | tile     | internalOption | input | expectedQuote  | isValidationSpigotGroup     | emailPattern                             | isValidationTileByParts  |
	|No             | Jhon        | Phillips   | 1        | No			   | 1     | 299            | No                          | taxchatglbtesting1+taxchat@gmail.com | No                       |

@validateConsentedStatus
Scenario Outline: Review the consented status user after of apply the back ground check
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
	And The user uploads the required documents depends on the type <isLicenseDriver>	
	And The user manage the profile information on the participant page for reach the consented status
	When The preparer user enters into preparer application and validate consented status <lastName>
	Then The preparer should see the correct status "Consented"
	
	Examples: 
	|isB2B2CUser    | name        | lastName    | tile | internalOption | input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                             | isValidationTileByParts  | isMarriedOnBoarding | isLicenseDriver | isRandomUploadFile |
	|No             | Christopher | Jackson     | 1    | No			    | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | taxchatglbtesting1+taxchat@gmail.com | No                       | No                  | Yes             | No                 |	


	