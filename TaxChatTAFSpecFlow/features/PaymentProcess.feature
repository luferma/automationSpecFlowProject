Feature: Process the payment on the participant module
	In order to validate the payment process on the participant module
	As a partipant
	I want to validate the payment functionality works properly

@validatePaymentFunctionalityWithoutMarkSameMailingAddress
Scenario Outline: Validate payment process on participant module without mark same mailing address
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  | country   | stateSelect   | isStateSelect  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>| <country> | <stateSelect> | <isStateSelect>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then He enters into upload documents option to upload all required files <isRandomUploadFile>
	And Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	When The preparer searches the participant user with the name <lastName> and complete the process until return release state
	| isCreatedUser |
	| No            |
	And The participant user process the payment
	| isCreatedUser | country  | name   |  lastName | expectedQuote  | 
	| No            | <country>| <name> | <lastName>| <expectedQuote>|

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |	country      | stateSelect | stateCompare| isStateSelect |	
	|Yes            | Bernie     | Jackson    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 | Colombia     | Medellin    | Medellin    | No            |
	|Yes            | Allan      | Brandon    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 | United_States| New_York    | Manhattan   | Yes           |

@validatePaymentFunctionalityMarkingSameMailingAddress
Scenario Outline: Validate payment process on participant module marking same mailing address
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  | country   | stateSelect   | isStateSelect  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>| <country> | <stateSelect> | <isStateSelect>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then He enters into upload documents option to upload all required files <isRandomUploadFile>
	And Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	When The preparer searches the participant user with the name <lastName> and complete the process until return release state
	| isCreatedUser |
	| No            |
	And The participant user process the payment marking mailing address
	| isCreatedUser | country  | name   |  lastName | expectedQuote  | 
	| No            | <country>| <name> | <lastName>| <expectedQuote>|

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |	country      | stateSelect | stateCompare| isStateSelect |
	|Yes            | Jeffrey    | William    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 | Colombia     | Medellin    | Medellin    | No            |
	|Yes            | Carl       | Heighs     | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 | United_States| New_York    | Manhattan   | Yes           |