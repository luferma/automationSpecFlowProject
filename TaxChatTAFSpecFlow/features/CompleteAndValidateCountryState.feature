Feature: Validate the fields country and state for the participant
	In order to validate the fields country and state on participant application
	As a partipant user
	I want to validate the correct entry of the fields country and state

@validateCountryUnitedStatesAndState
Scenario Outline: Validate the correct entry of country and state
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
	Then Is validated the correct entry of country and state fields on the profile section
	| country   | stateCompare   | isStateSelect  | 
	| <country> | <stateCompare> | <isStateSelect> |

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | isRandomUploadFile | country      | stateSelect | stateCompare| isStateSelect |
	|Yes            | Bernie     | Jackson    | 1        | No			 | 0     | 199            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No                 | United_States| New_York    | NY          | Yes           |
	|Yes            | Richard    | Hendrinks  | 1        | No			 | 0     | 199            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No                 | Colombia     | Medellin    | Medellin    | No            |

@validateStateListForOthersCountries
Scenario Outline: Validate the state list depends on country selected
	Given The user have entered into participant page with a created user <email> <password>
	When Are validated the countries with related states
	| country          | stateSelect    | isCountryUs  | 
	| United_States    | NY             | Yes          |
	| Canada           | Quebec         | No           |
	| China            | Jura           | No           |
	| India            | Delhi          | No           |
	| Belgium          | Brussels       | No           |
	| Germany          | Berlin         | No           |
	| Japan            | Tokyo          | No           |
	| <country>        | <stateSelect>  | <isCountryUs>|
	And The user have entered into preparer page and validate the information for the country and state
	| country          | stateSelect    | email   | isCreatedUser | isCountryUs  | 
	| <country>        | <stateSelect>  | <email> | Yes           | <isCountryUs>|

	Examples: 	
	|email                                 | password    | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile | country      | stateSelect | isCountryUs |
	|lf.martinez+taxchat361@globant.com    | Abcd1234GLB | Yes                 | No           | No                 | Yes                 | Married       | Yes              | Yes                      | No                   | No                 | United_States| NY          | Yes         |
	|lf.martinez+taxchat589@globant.com    | Abcd1234GLB | Yes                 | No           | No                 | Yes                 | Married       | Yes              | Yes                      | No                   | No                 | Canada       | Quebec      | No          |