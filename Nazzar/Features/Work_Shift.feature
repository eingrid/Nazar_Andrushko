Feature: OrangeTests
	Testing OrangeHRM Work Shifts
	
  Scenario: Add/Delete Work Shifts
    #Adding New Record 
    Given I am on Work Shifts page
    When I click Add Button
    And I enter Shift Name, choose work hours, choose available eployees
    And I click Save button to save Work Shift
    Then I am transfered to page with records and I see my record

    #Deleting Record
    When I click in checkbox on the left of Shift Name
    And I click Delete Button
    And I click Ok Button in dialog box
    Then I am observing Work Shift table without my record

