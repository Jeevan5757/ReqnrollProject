Feature: Login Functionality
  As a registered user
  I want to log into the application
  So that I can access my account

@login
Scenario: Login should succeed with valid credentials
	Given user is on the login page
	When user enters valid username and password
	Then user should be redirected to the dashboard

@addToCart
Scenario: Verify item can be added to cart
	Given user is logged in
	When user adds "IPHONE 13 PRO" and "ZARA COAT 3" item to the cart
	Then the product should be added to the cart

@cartPage
Scenario: verify cart page displays added items
	Given user has following item in the cart
	| productName   |
	| iphone 13 pro |
	| ZARA COAT 3   |
	Then verify cart page displays the added item

#Scenario: Verify checkout page items displaying from cart
#	Given user is logged in
#	And  user adds an item to the cart
#	Then cart page displays the added item
#	When user proceeds to checkout
#	Then checkout page displays the items from the cart
#
#Scenario: Verify order confirmation after checkout
#Given user is logged in
#	And  user adds an item to the cart
#	Then cart page displays the added item
#	When user proceeds to checkout
#	Then order confirmation page should be displayed after successful checkout


