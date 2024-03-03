Feature: Validate different options and information on profile module with users previously created
	In order to validate the diffent options and information
	As a partipant user
	I want to validate the different options and information on profile module

@validateMedicalExpensesFieldWithCreatedUsers
Scenario Outline: Validate with users previously created the medical expenses field on profile module
	Given The user have entered into participant page with a created user <email> <password>
	Then Is validated and fill out all the information to validate the medical expenses field
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding | spouseNotSsn  | maritalStatus  | isB2B2CUser  | isCreatedUser |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | isMarriedDependent> | <spouseNotSsn>| <maritalStatus>| <isB2B2CUser>| Yes           |	
	
	Examples: 
	|email                               | password    | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent |  maritalStatus |
	|lf.martinez+sub_cc_10804@globant.com| Abcd1234GLB |  Yes                | No           | No                 |  Married       |

@validateEditCountryAllDocsSubmittedStatusWithCreatedUsers
Scenario Outline: Validate with user previously created the edition of country in all documents submitted status
	Given The user have entered into participant page with a created user <email> <password>
	When He enters into upload documents option with an user created to upload all required files <isRandomUploadFile>
	Then Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |isCreatedUser |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| Yes          |Yes           |
	And Is validated the country edition with all document submitted status

	Examples: 
	|email                               | password    | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|lf.martinez+sub_cc_85637@globant.com| Abcd1234GLB | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |

@validateDoesNotEditCountryAllDocsConfirmedStatusWithCreatedUsers
Scenario Outline: Validate with user previously created that he can not edit the country fields when rearch the status all documents submitted confirmed
	Given The user have entered into participant page with a created user <email> <password>
	When He enters into upload documents option with an user created to upload all required files <isRandomUploadFile>
	Then Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser  |isCreatedUser |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| Yes          |Yes           |
	When The preparer searches the participant user with the name <lastName> and confirms the documents
	| isCreatedUser |
	| Yes           |
	Then The user changes to participant app to edit the country information
	| isCreatedUser |
	| Yes           |

	Examples: 
	|email                               | password    | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|lf.martinez+sub_cc_66859@globant.com| Abcd1234GLB | Yes                 | No           | No                 | No                  | Married       | Yes              | Yes                      | No                   | No                 |