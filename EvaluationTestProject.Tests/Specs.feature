Feature: Blog sorting

Scenario: Get the oldest blog
	Given I want to know the oldest blog from the following list of blogs
	| BlogId | CreationDate |
	| 1      | 2014-01-01   |
	| 2      | 2013-01-01   |
	| 3      | 2000-01-01   |
	Then the result should be blog id 3
