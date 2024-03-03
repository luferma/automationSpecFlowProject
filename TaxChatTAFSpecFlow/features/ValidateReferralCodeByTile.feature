Feature: Validate the correct functionality of referral code for fixed, percentage or flat type by tile
	In order to validate the referral code functionality
	As a partipant user
	I want to validate the referral code functionality for fixed and percentage type
	
@invalidReferralCode
Scenario Outline: Validate when is enter an invalid referral code
	Given The user have entered into onboarding option to validate the referral code option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When Is entered an invalid referral code
	| discountCode   |
	| <discountCode> |
	Then Is validated that appear the correct message

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | isValidationSpigotGroup | emailPattern                             | isValidationTileByParts | discountCode|
	|Yes            | Bernie     | Jackson    | 1        | No			 | 0     | 199            |  No                     | taxchatglbtesting1+sub_pd_@gmail.com     | No                      | TAXCHAT202  |

@validateReferralCodeByTile
Scenario Outline: Validate the correct application of discount when user enters a referral code by selected tile
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  | discountCode  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>| <discountCode>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isValidationSpigotGroup  | isValidationTileByParts  | isMarriedOnBoarding  | discountFixed  | discountPercentage  | discountFlat  | showQuotePage  | 
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isValidationSpigotGroup>| <isValidationTileByParts>| <isMarriedOnBoarding>| <discountFixed>| <discountPercentage>| <discountFlat>| <showQuotePage>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	And The preparer searches the participant user and validates the complexity with the email preparer, the pass preparer and the name <lastName>
	Then The user should see the correct complexity
	| complexityExpected  |
	| <complexityExpected>|

	Examples: 
	|isB2B2CUser    | name      | lastName   | tile | internalOption											| input | expectedQuote | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction  | isValidationSpigotGroup     | emailPattern                         | isValidationTileByParts | isMarriedOnBoarding | discountCode   | discountFixed | discountPercentage | discountFlat | showQuotePage | 
	|Yes            | Edward    | Pierce     | 1    | No														| 0     | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com      | No                      | No				   | Globant2020    | 20            |                    |              |               |
	|Yes            | Mariah    | Carey      | 2    |															|	    | 224           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com      | No                      | No			       | PP2025         |               | 25                 |              |               |
	|Yes            | Thomas    | Mottola    | 3    |															| 1     | 319           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | No                      | No				   | Championed2020 | 66            |                    |              |               |
	|Yes            | Simon     | Fuller     | 4    |															|       | 349           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | No                      | No				   | PP2035         |               | 30                 |              |               |
	|Yes            | Nicolas   | Cappola    | 5    |															| 2     | 229           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | No                      | No				   | FLAT2022       |               |                    | 50           |               |
	|Yes            | Patricia  | Arquette   | 6    | Investment income through US								|       | 199           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | No                      | No				   | Championed2020 | 66            |                    |              |               |
	|Yes            | Donald    | Trump      | 10   | purchase													|       | 249           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | No                      | No				   | FLAT2022       |               |                    | 50           |               |
	|Yes            | Edward    | Allen      | 6    | Direct investment in a foreign corporation or partnership |       | 1199          | Platinum           | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | No                      | No				   | Globant2020    | 1000          |                    |              |               |
	|Yes            | Janet     | Damita     | 4,5,6| No                                                        | 1     | 2314          | Platinum           | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | Yes                     | No				   | Globant2020    | 1000          |                    |              |               |
	|Yes            | John      | Martin     | 1,2,3| No                                                        | 1     | 619           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+champ_cc_@globant.com    | Yes                     | No				   | Globant2020    | 1000          |                    |              | No            |

@validateReferralCodeByTileForB2CUsers
Scenario Outline: Validate the correct application of discount when user enters a referral code by selected tile for B2C users
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  | discountCode  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>| <discountCode>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isValidationSpigotGroup  | isValidationTileByParts  | isMarriedOnBoarding  | discountFixed  | discountPercentage  | discountFlat  | showQuotePage  | 
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isValidationSpigotGroup>| <isValidationTileByParts>| <isMarriedOnBoarding>| <discountFixed>| <discountPercentage>| <discountFlat>| <showQuotePage>|
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page
	And The user uploads the required documents depends on the type <isLicenseDriver>
	And The user manage the profile information on the participant page and it is completed
	And The preparer searches the participant user and validates the complexity with the email preparer, the pass preparer and the name <lastName>
	Then The user should see the correct complexity
	| complexityExpected  |
	| <complexityExpected>|

	Examples: 
	|isB2B2CUser    | name      | lastName   | tile | internalOption| input | expectedQuote | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction  | isValidationSpigotGroup     | emailPattern                         | isValidationTileByParts | isMarriedOnBoarding| discountCode    | discountFixed | discountPercentage | discountFlat | showQuotePage | isLicenseDriver |   
	|No             | Edward    | Pierce     | 1    | No			| 0     | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | taxchatglbtesting1+taxchat@gmail.com | No                      | No				  | PP2040          |               | 40                 |              |               | No              |
	