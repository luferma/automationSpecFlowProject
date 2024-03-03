Feature: Validate the correct connection with CCH
	In order to validate the correct connection with CCH
	As a partipant user
	I want to validate the correct connection with CCH entering to my profile module on participant application and verifying the correct update of every section

@ValidateCorrectCCHConnection
Scenario Outline: Validate that the connection with CCH is successful
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
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  | isCCHValidation |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>| Yes             |
	And The preparer searches the participant user and validates the CCH connection with the user <lastName>
	| isCreatedUser |
	| No            |

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                        | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|Yes            | Bernie     | Jackson    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |
	