Feature: Validate required documents after complete profile information for B2B2C users
	In order to validate the requested documents once the profile information is completed
	As a partipant user
	I want to validate the requested documents on the participant tab

@validateRequestedDocuments
Scenario Outline: Validate requested documents on the participant information
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
	And Is validated and fill out all the information for non citizens on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  | 
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| <isB2B2CUser>|
	| daughter       | Joseph              | Claus				| May,7,1972       | 515487987  | Yes             |						 |               |                     |                      |                |                   |                           |                       |                     |              |
	| parent         | Irina               | Maden				| June,7,1981      | 154678942  | No              |						 |               |                     |                      |                |                   |                           |                       |                     |              |
	| other          | Jhon                | Clark				| January,7,1969   | 193564874  | No              |						 |               |                     |                      |                |                   |                           |                       |                     |              |

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  | complexityExpected | consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                    | isValidationTileByParts  | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|Yes            | Bernie     | Jackson    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | Yes                 | Married       | Yes              | Yes                      | No                   | No                 |			
	|Yes            | Robert     | Pattson    | 1        | No			 | 1     | 299            | Silver             | Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | No                       | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |			

@validateQuantityDocuments
Scenario Outline: Validate the quantity of requested documents on the participant information
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
	Then He enters into upload documents option and validate the documents quantity <input> <isItin>

	Examples: 
	|isB2B2CUser    | name       | lastName   | tile     | internalOption| input | expectedQuote  |consentAditionalQuestion | consentMarried | consentFinantialReport | consentReportableTransaction   | isValidationSpigotGroup     | emailPattern                        | isValidationTileByParts  | isMarriedOnBoarding | isItin |
	|Yes            | Christopher| Jackson    | 5        |   			 | 4     | 259            |Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_cc_@globant.com | Yes                      | Yes                 | No     | 
	|Yes            | John       | Martin     | 1        | Yes			 | 4     | 624            |Yes                      | Yes            | Yes                    | Yes                            | No                          | lf.martinez+sub_pd_@globant.com | Yes                      | No				    | Yes    |
