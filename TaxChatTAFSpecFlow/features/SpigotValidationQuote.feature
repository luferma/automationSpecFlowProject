Feature: Spigot group quote validation
	In order to validate the quote of every spigot group
	As a partipant user
	I want to validate the spigot group quote selecting all the tiles by SpigotGroup and enter the email pattern related

@spigotGroupValidationQuote
Scenario Outline: Spigot group quote validation
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  | isValidationSpigotGroup  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>| <isValidationSpigotGroup>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isValidationSpigotGroup  | isValidationTileByParts  | isMarriedOnBoarding  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isValidationSpigotGroup>| <isValidationTileByParts>| <isMarriedOnBoarding>|

	Examples: 
	|isB2B2CUser     | name      | lastName  | tile    | internalOption | input | expectedQuote | complexityExpected | consentAditionalQuestion | consentMarried |	consentFinantialReport | consentReportableTransaction | isValidationSpigotGroup | emailPattern                    | isValidationTileByParts | isMarriedOnBoarding |							
	|Yes            | Edward    | Pierce    | 1       | No			    | 1     | 5144          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat+sub_cc_@globant.com     | No                      | No				  |
	|Yes            | Janet     | Damita    | 1       | No				| 1     | 5244          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat@jpmchase.com			  | No                      | No				  |
	|Yes            | John      | Martin    | 1       | No			    | 1     | 5124          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat@anes.upmc.edu           | No                      | No				  |
	|Yes            | Mariah    | Carey     | 1       | No			    | 1     | 5144          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat@henkel.com              | No                      | No				  |
	|Yes            | Thomas    | Mottola   | 1       | No			    | 1     | 5144          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat@pfizer.com              | No                      | No				  |
	|Yes            | Gloria    | Fajardo   | 1       | No			    | 1     | 5144          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat+sub_pd_@iinteractive.com| No                      | No				  |
	|Yes            | Joseph    | Adams     | 1       | No			    | 1     | 4957          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat+con_st@hotmail.com      | No                      | No				  |
	|Yes            | Kelly     | Clarkson  | 1       | No			    | 1     | 5124          | Bronze             | No                       | No             | No                      | No                           | Yes                     | taxchat@bestbuy.com             | No                      | No				  |
	|Yes            | Simon     | Fuller    | 1,2,3,11| No			    | 1     | 545           | Bronze             | No                       | No             | No                      | No                           | No                      | taxchat@hsbcX0lvf.com           | Yes                     | No				  |
	