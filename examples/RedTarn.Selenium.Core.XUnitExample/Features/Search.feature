@Demo @Desktop @Tablet @Phone
Feature: Search
	In order to find Red Tarn Technology
	As a user of the internet
	I want to be able to search on Companies House

Scenario: Perform Companies House Search
	Given I am on the homepage
	And I have entered 'Red Tarn Technology' into the search box
	When I press search
	And I am taken to the search results page
	And I select the first item in the results list
	Then I am taken to the correct company details
