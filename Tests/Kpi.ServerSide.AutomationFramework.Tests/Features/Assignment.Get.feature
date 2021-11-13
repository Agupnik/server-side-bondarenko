@Get
@Regression
Feature: Get Assignment by Id
	Story:

@Smoke
Scenario: 1. Validate Get Assignment by id with valid data
	Given I have logged user
	When I create Assignment by post request
	Then I see returned Assignment details which are equal with created

@Smoke
Scenario: 1. Validate Get Assignment by id as unauthorized user
	Given I have logged user
	When I create Assignment by post request
	And I send get request with created Assignment id as unauthorized user
	Then I see Unauthorized status code