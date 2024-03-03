Feature: Validate the typed information in "How did you hear about" list
	In order to validate the information typed in "How did you hear about list"
	As a B2C partipant user
	I want to complete the onboarding information for B2C user and after to validate the entered information

@validateTheContentOfHowDidYouHearList
Scenario Outline: Validate the typed information in "How did you hear about" list 
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  | isB2B2CUser  | otherOptionHowDidYouHearList |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>| <isB2B2CUser>|	Yes                          |
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	Then Is validated the correct update in the field text after the process

	Examples: 
	|isB2B2CUser    | name        | lastName    | tile | internalOption | input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                         | isValidationTileByParts  |
	|No             | Christopher | Jackson     | 1    | No			    | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | taxchatglbtesting1+taxchat@gmail.com | No                       |	
	