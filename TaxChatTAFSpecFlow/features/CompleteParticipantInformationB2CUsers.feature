Feature: Complete participant information for B2C users
	In order to complete the entire participant information
	As a B2C partipant user
	I want to complete all the information related to participant page, including documents and profile informtation

@completeB2CUserParticipantInformation
Scenario Outline: Complete participant information for B2C user
	Given The user have entered into onboarding option
	| name   | lastName   | tile   | internalOption  | input   | emailPattern  |
	| <name> | <lastName> | <tile> | <internalOption>| <input> | <emailPattern>|
	When He fills out the fields related to tax situation
	| tile   | internalOption   | input   | isValidationSpigotGroup  | isValidationTileByParts  |
	| <tile> | <internalOption> | <input> | <isValidationSpigotGroup>| <isValidationTileByParts>|
	And He fills out the fields in user creation page so to complete participant information with the name <name> the lastname <lastName> the expectedquote <expectedQuote> and depends of user <isB2B2CUser> with the following consents
	| consentAditionalQuestion  | consentMarried  | consentFinantialReport  | consentReportableTransaction  | isMarriedOnBoarding  | isB2B2CUser  |
	| <consentAditionalQuestion>| <consentMarried>| <consentFinantialReport>| <consentReportableTransaction>| <isMarriedOnBoarding>| <isB2B2CUser>|	
	And He confirms the e-mail sent with the email, the name <name> and the lastname <lastName> for the type of user <isB2B2CUser>
	And The user have entered into participant page	
	And The user uploads the required documents depends on the type <isLicenseDriver>	
	And The user manage the profile information on the participant page and it is completed
	Then He enters into upload documents option to upload all required files <isRandomUploadFile>
	And Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  | 
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	| daughter       | Joseph              | Claus				| May,7,1972       | 515487987  | Yes             |						 |               |                     |                      |                |                   |                           |                       |                     |              |
	| parent         | Irina               | Maden				| June,7,1981      | 154678942  | No              |						 |               |                     |                      |                |                   |                           |                       |                     |              |
	| other          | Jhon                | Clark				| January,7,1969   | 193564874  | No              |						 |               |                     |                      |                |                   |                           |                       |                     |              |

	Examples: 
	|isB2B2CUser    | name        | lastName    | tile | internalOption | input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                         | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isLicenseDriver | isRandomUploadFile |
	|No             | Christopher | Jackson     | 1    | No			    | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | taxchatglbtesting1+taxchat@gmail.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | Yes             | No                 |
	|No             | Mark        | Phillips    | 1    | No			    | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | taxchatglbtesting1+taxchat@gmail.com | No                       | No                  | No           | Yes                | Yes                 | Married       | Yes              | Yes                      | No                   | No              | No                 |
	