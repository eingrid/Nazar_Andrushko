# Selenium

Download the project

In Visual Studio install SpecFlow.NUnit, Selenium.WebDriver and Selenium.WebDriver.FireFox

Run the project

In order to run this in command prompt use command dotnet test in the directory of the project.

To create report of the test run livingdoc test-assembly Path to Nazzar.dll(compiled SpecFlow test assembly) -t Path to TestExecution.json (test execution report)

In my case that was:

livingdoc test-assembly /home/eingird/Study/csharp/Selenium/Nazzar/bin/Debug/net6.0/Nazzar.dll -t /home/eingird/Study/csharp/Selenium/Nazzar/bin/Debug/net6.0/TestExecution.json