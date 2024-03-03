Feature: Validate the Taxpayer's name in the consents on preparer application
	In order to validate the Taxpayer's name in the consents on preparer application
	As a preparer user
	I want to validate the consent information on preparer application

@validateTheConsentInformationOnPreparerApplication
Scenario Outline: Validate the Taxpayer's name in the consents on preparer application
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isValidationSpigotGroup  | isValidationTileByParts  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isValidationSpigotGroup>| <isValidationTileByParts>| <isMarriedOnBoarding>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then The preparer searches the participant user and validates the taxpayer name in the consent section
	| name   | lastName   |
	| <name> | <lastName> |

	Examples: 
	|isB2B2CUser    | name        | lastName   | tile     | internalOption | input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isLicenseDriver | isRandomUploadFile |	
	|Yes            | Christopher | Jackson    | 1        | No			   | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | No                  | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | Yes             | No                 |		