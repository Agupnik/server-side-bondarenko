@Post
@Regression
Feature: Assignment Creation
	Story:

@Smoke
Scenario: 1. Validate Assignment creation with provided model
	Given I have logged user
	And I have current Assignment count
	When I send the assignment creation request with provided model
	Then I see increased Assignment count

Scenario: 2. Validate Assignment creation with empty task
	Given I have logged user
	When I send the assignment creation request with null value
	Then I see BadRequest status code

Scenario: 3. Validate Assignment creation with very long task description
	Given I have logged user
	When I send the assignment creation request with very long task description
	Then I see RequestEntityTooLarge status code