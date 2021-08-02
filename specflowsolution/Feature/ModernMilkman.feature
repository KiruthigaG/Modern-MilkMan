Feature: ModernMilkman
	Simple calculator for adding two numbers

@Browser:Chrome
#Verify the postcode text box
Scenario: Check the postcode
	Given I navigate to the website
	#Check for invalid postcode
	Given I enter the "636 008" postcode
	Then I click "Find" button
    Then an alert appears with the message "Not a valid postcode"
	Then I click "OK" button
	#Check for postcode that does not have delivery option
	Given I enter the "CV2 4BX" postcode
	Then I click "Find" button
    Then the header is "Coming soon to a neighbourhood near you"
	#Check a valid postcode for delivery
	When I click the home image
	Given I enter the "LS20 8JN" postcode
	Then I click "Find" button
    Then the header is "Great news"
	Then I close the MilkMan Page

#Fill in the sign up page
Scenario: Fill the Signup form
	Given I navigate to the website
	Given I click the "signin" logo
	When I click the "Sign Up" link
	Then I click "Get started" button
	Then I see the field validation message "Please enter your phone number" on "Mobile number" field
	Then I see the field validation message "Please enter the postcode" on "Postcode" field
	When I enter "0132" into "Mobile number" field
	Then I see the field validation message "Please enter the valid phone number" on "Mobile number" field
	When I enter "07500860132" into "Mobile number" field
	Then I enter "LS208JN" into "Postcode" field
	Then I click "Get started" button
    When I enter "Kiruthiga" into "First name" field
	Then I enter "Stalin" into "Last name" field
	Then I enter "kg@gmail.com" into "Email address" field
	Then the "07500860132" appears in the "Mobile number" field
	Then I enter "1234" into "Create a password" field
	When I select "Instagram" from "Where did you hear about us?" field
	Then I see the field validation message "Please enter valid email address" on "Email address" field
	Then I see the field validation message "Password should be of minimum 6 characters" on "Create a password" field
	Then I enter "krithiarun3086@gmail.com" into "Email address" field
	Then I enter "1234567" into "Create a password" field
	Then I click checkbox for "marketing"
	Then I click checkbox for "terms"
	#The element for the checkbox is not interactable, i am not able to access the element
	Then I click "Create my account" button


Scenario: Update email address
	Given I navigate to the website
	Given I click the "signin" logo
	When I enter "07500860132" into "Mobile number" field
	Then I enter "1234567" into "Password" field
	Then I click "Login" button
	When I click the useraccount logo
	When I click "My account" link from the list
	When I click "Account details" from the list
	Then I enter "krithiarun3086@yahoo.com" into "Email address" field
	Then I click "Save" button
	Then an alert appears with the message "Your account has been updated."
	Then I click "OK" button
	Then I close the MilkMan Page
	
