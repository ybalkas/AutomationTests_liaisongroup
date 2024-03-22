Feature:Some tests on www.liaisongroup.com

Background: 
Given the user is on the "https://www.liaisongroup.com/" page

Scenario: A user expresses their interest in attending an event via the Attending Events Form

  Given the user navigates to the "News, Insights & Events" on the website  
  Then  the url should be  "https://www.liaisongroup.com/contact/#eventContactForm"
  When the user fills in their name "Full Name" with "John Doe"
  And the user fills in their email "Email" with "johndoe@example.com"
  And the user fills in their organisatio "Organisation" with "John's Tech Solutions"
  And the user selects an event from the "Select Event" dropdown
  And the user fills in the "Message" field with "Looking forward to learning more about this event."
  And the user submits the form            
  Then the user should see a confirmation message saying "Your responses were successfully submitted. Thank you!"
  And an email should be sent to "johndoe@example.com" confirming the submission and providing next steps

