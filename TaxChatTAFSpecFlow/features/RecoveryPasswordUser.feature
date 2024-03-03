Feature: Validate the recovery of the password user functionality
	In order to validate the correct functioning of recovery password user module
	As a partipant
	I want to validate the recovery password process is working properly

@validateCorrectWorkingRecoveryProcess
Scenario Outline: Validate the recovery of the password user functionality
	Given The user manage the recovery password process on participant page <email> <name> <lastname>
	When The user have entered into participant page
	Then The user can enter correctly with the new password

	Examples: 
	|email                                       | name        | lastname |
	|taxchatglbtesting1+taxchat0618542@gmail.com | Christopher | Jackson  |
	#|taxchatglbtesting1+taxchat0617514@gmail.com | Christopher | Jackson  |