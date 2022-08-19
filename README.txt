{ Sauce Demo Test Automation }

- Clone the repository from

- Open the "SauceDemoTestAutomation" solution file (.sln)

- This Automation project uses Google Chrome as it's main web browser and 
  will require it to be installed on the host machine

- To access and run the automation scripts, please open the test explorer (Ctrl+E, T)
  which can be found under the "View" tab. 

- Each test is grouped based on the type of user 
  (standard user (SU), locked out user, problem user (PU), performance glitch user (PGU)).

- Each test can be run as a single unit test by highlighting the respective test under each group and clicking the
  play or "Run" (Ctrl + R,T) button under the Test Explorer column.

- Tests can also be run concurrently by pressing the run all button under the Test Explorer column, or by
  right clicking on the desired group and selecting "Run".

- Some classes inherit the "Setup" and "Teardown" attributes from the "Base Test" class as a means of reducing code repitition.

- At the end of each test, an HTML file is generated in the "HTMLReports" folder outlining the results 
  of the test. The html file provides the log information of what took place during the test 
  and whether the test was a pass or fail.

*** TO CREATE THE HTML REPORT ****
- To create and access the HTML file, please change the directory path in line 26 from the "Base Test" class:
  "C:\Users\Donovans\SauceDemoTestAutomation\SauceDemoTestAutomation\HtmlReports\ReportLog.html"  
  to the directory path on the host machine where the HTMLReports folder is stored.

- You can right-click on the HtmlReports folder in the solution, click "Open Folder in File Explorer" 
  and then copy the new path from the directory into the source code.

- Additionally change any instances of the above directory path to the new path.
  > Line 26 in the Inventory class
  > Line 271 in the Inventory class
  > Line 515 in the Inventory class