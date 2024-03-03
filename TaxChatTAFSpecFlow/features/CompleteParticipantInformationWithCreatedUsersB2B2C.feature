Feature: Complete participant information with users previously created for B2B2C
	In order to complete the entire participant information
	As a partipant user
	I want to upload all the required files and fill out the profile information on particpant page

@completeParticipantInformationWithCreatedUsers
Scenario Outline: Complete participant information with users previously created for B2B2C users
	Given The user have entered into participant page with a created user <email> <password>
	When He enters into upload documents option with an user created to upload all required files <isRandomUploadFile>	
	Then Is validated and fill out all the information on the profile section
	| typeDependent  | firstNameDependent  | lastNameDependent  | dateOfBirth      | ssn        | dependentNotSsn | isMarriedOnBoarding  | spouseNotSsn  | isMarriedDependent  | markCompleteOptions  | maritalStatus  | hadDistributions  | directAndsameBankAccount  | checkMailedAndDirect  | isRandomUploadFile  | isB2B2CUser | isCreatedUser |
	| son            | Jhon                | Kent				| December,7,1962  | 123456789  | Yes             | <isMarriedOnBoarding>| <spouseNotSsn>| <isMarriedDependent>| <markCompleteOptions>| <maritalStatus>| <hadDistributions>| <directAndsameBankAccount>| <checkMailedAndDirect>| <isRandomUploadFile>| Yes         | Yes           |

	Examples: 
	|email                                  | password    | isMarriedOnBoarding | spouseNotSsn | isMarriedDependent | markCompleteOptions | maritalStatus | hadDistributions                | directAndsameBankAccount | checkMailedAndDirect | isRandomUploadFile |		
	|lf.martinez+taxchat10139@globant.com   | Abcd1234GLB | Yes                 | No           | No                 | Yes                 | Married       | Yes                             | Yes                      | No                   | No                 |
	|lf.martinez+taxchat37174@globant.com   | Abcd1234GLB | Yes                 | No           | No                 | Yes                 | Widowed       | I_did_not_have_any_distributions| No                       | No                   | No                 |
	|lf.martinez+taxchat61197@globant.com   | Abcd1234GLB | Yes                 | No           | No                 | No                  | Divorced      | No                              | No                       | No                   | No				 |
	|lf.martinez+taxchat22434@globant.com   | Abcd1234GLB | Yes                 | No           | No                 | No                  | Divorced      | No                              | No                       | Yes                  | No                 |	
	|lf.martinez+taxchat71026@globant.com   | Abcd1234GLB | Yes                 | No           | No                 | No                  | Married       | Yes                             | No                       | No                   | No                 |
	|lf.martinez+taxchat14270@globant.com   | Abcd1234GLB | Yes                 | No           | No                 | No                  | No_change     | No                              | No                       | No                   | No                 |
	|lf.martinez+taxchat61981@globant.com   | Abcd1234GLB | No                  | No           | Yes                | Yes                 | Married       | Yes                             | No                       | No                   | No                 |
	|lf.martinez+taxchat71909@globant.com   | Abcd1234GLB | Yes				    | No           | Yes                | No                  | No_change     | No                              | No                       | No                   | Yes                |
	|lf.martinez+taxchat97944@globant.com   | Abcd1234GLB | No                  | No           | Yes                | No                  | No_change     | No                              | No                       | No                   | No                 |			
	|lf.martinez+taxchat89582@globant.com   | Abcd1234GLB | No                  | No           | Yes                | No                  | No_change     | No                              | No                       | No                   | No                 |
	|lf.martinez+taxchat08078@globant.com   | Abcd1234GLB | No                  | No           | Yes                | No                  | No_change     | No                              | No                       | No                   | No                 |
	|lf.martinez+taxchat29095@globant.com   | Abcd1234GLB | No                  | No           | Yes                | No                  | No_change     | No                              | No                       | No                   | No                 |	
	|lf.martinez+taxchat48233@globant.com   | Abcd1234GLB | No                  | No           | Yes                | No                  | No_change     | No                              | No                       | No                   | No                 |