Feature:Some tests on www.liaisongroup.com

Background: 
Given the user is on the "https://www.liaisongroup.com/" dashboard 

Scenario: Search on the Workforce main page verify results are ordered by  date
    When User search for "CHC Backlog" 
    Then User should be able to see search results
    Then User should be able to sort according to date

Scenario: Navigation to the Careers page and making a search
  When User clicks Contact and then click Vacancies
  Then Careers page "https://www.liaisongroup.com/liaison-group/careers/" opens
  Then User SHould be able to direct to job search page "https://myliaison.jobs.people-first.com/jobs/search"
  
  Scenario: A user expresses their interest in attending an event via the Attending Events Form
  Given the user navigates to the "News, Insights & Events" page  
  Then  the url should be  "https://www.liaisongroup.com/news-insights-events/"
  When the user fill in the registration form with the following details
      | Field        | Value                                              |
      | FullName     | Yusuf Balkas                                          |
      | Email        | ybalkas@gmail.com                                |
      | Organisation | Alis's Tech Solutions Ltd                          |
      | Message      | Looking forward to learning more about this event. |
  And user choose an event "Virtual VAT Conference" from dropdown 
  And the user submits the form            
  Then the user should see a confirmation message saying "Your responses were successfully submitted. Thank you!"

  




    

 


  