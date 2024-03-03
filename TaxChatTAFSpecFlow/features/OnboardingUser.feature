﻿Feature: Onboarding user
	In order to create an EY account for enter into application taxChat
	As a partipant user
	I want to do the process to obtain an application username and password

@onboardingConfirmationEmail
Scenario Outline: Onboarding B2B2C with email confirmation
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
	And The preparer searches the participant user and validates the complexity with the email preparer, the pass preparer and the name <lastName>
	Then The user should see the correct complexity
	| complexityExpected  |
	| <complexityExpected>|

	Examples: 
	|isB2B2CUser    | name      | lastName   | tile | internalOption											| input | expectedQuote | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction  | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts | isMarriedOnBoarding|
	|Yes            | Clark     | Barkley    | 0    | No														| 0     | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Edward    | Pierce     | 1    | No														| 0     | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Janet     | Damita     | 1    | Yes														| 0     | 224           | Silver             | Yes                      | Yes            | Yes                    | Yes							  | No                          | lf.martinez+sub_pd_@globant.com | No                      | No			     |
	|Yes            | Nicholas  | Barkely    | 1    | No														| 1     | 299           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | John      | Martin     | 1    | Yes														| 1     | 324           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Mariah    | Carey      | 2    |															|	    | 224           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Thomas    | Mottola    | 3    |															| 1     | 319           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Gloria    | Fajardo    | 3    | Personal Use												| 1     | 369           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Joseph    | Adams      | 3    | Bought													| 1     | 319           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Kelly     | Clarkson   | 3    | Sold														| 1     | 419           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No			     |
	|Yes            | Simon     | Fuller     | 4    |															|       | 349           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No				 |
	|Yes            | Nicolas   | Cappola    | 5    |															| 2     | 229           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Albert    | Cappola    | 5    |															| 1     | 214           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Patricia  | Arquette   | 6    | Investment income through US								|       | 199           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Thomas    | Jane       | 6    | Foreign rental											|       | 399           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Phil      | Joanou     | 6    | Foreign mutual funds or similar investments				|       | 399           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Edward    | Allen      | 6    | Direct investment in a foreign corporation or partnership |       | 1199          | Platinum           | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Amy       | Madigan    | 6    | Form 2555                                                 |       | 699           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Beth      | Dziewion   | 6    | First year filing a US                                    |       | 249           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Wendell   | Pierce     | 7    |                                                           | 1     | 259           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Denzel	| Washington | 10   | sale or exchange                                          |       | 299           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Donald    | Trump      | 10   | purchase                                                  |       | 249           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Hilary    | Clinton    | 10   | gifts or donations                                        |       | 249           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Laura     | Bush       | 10   | mining                                                    |       | 299           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Mary      | Perry      | 10   | not reported                                              |       | 299           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Cecilia   | Abbott     | 10   | FIFO                                                      |       | 199           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Geoffrey  | Hinton     | 10   | lending arrangement                                       |       | 699           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Edward    | Pierce     | 10   | ICO SAFT STO                                              |       | 699           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No 				 |
	|Yes            | Deborah   | Unger      | 10   | CFDs                                                      |       | 699           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Michael   | Gray       | 10   | peer-to-peer                                              |       | 299           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Jhon      | Jackson    | 10   | vehicle                                                   |       | 449           | Gold               | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Jeanne    | Horn       | 9    | make contributions                                        |       | 199           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Mandel    | Patinkin   | 9    | rollover or conversion                                    |       | 224           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Vanessa   | Williams   | 9    | distribution                                              |       | 199           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Clara     | Lions      | 9    | none                                                      |       | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Katherine | Heigl      | 11   | Do you have W-2 income                                    |       | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Chyler    | Leigh      | 11   | Does your spouse have                                     |       | 199           | Bronze             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Sarah     | Drew       | 11   | Does your or your spouse's W-2 more than 3 States         |       | 199           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Mike      | Miller     | 8    | Student loan interest                                     |       | 224           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |
	|Yes            | Robert    | Thompson   | 8    | Tuition expenses											|       | 249           | Silver             | Yes                      | Yes            | Yes                    | Yes                           | No                          | lf.martinez+sub_pd_@globant.com | No                      | No  				 |