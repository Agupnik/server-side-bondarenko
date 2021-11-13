@Delete
@Regression
Feature: Delete Assignment by Id
	Story:

@Smoke
Scenario: 1. Validate Delete Assignment by Id with valid data
	Given I have logged user
	When I create Assignment by post request
	And I send delete request with created Assignment id
	Then I see OK status code

@Smoke
Scenario: 1. Validate Delete Assignment by Id as unauthorized user
	Given I have logged user
	When I create Assignment by post request
	And I send delete request with created Assignment id as unauthorized user
	Then I see Unauthorized status code