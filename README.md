# Step-by-step guide for LivingDoc Generator

The LivingDoc Generator enables you to generate living documentation in HTML format with no external dependencies.

Step 1 - Installation

1- Setup the SpecFlow.Plus.LivingDoc Plugin for your SpecFlow project (if you have created the project using the SpecFlow Visual Studio project template, this dependency should already be there).

> Note: This plugin is only required if you want to generate living documentation with test results, otherwise you can skip this plugin installation and only install the command line tool below. In this example we will be generating LivingDoc with test results.

2- Next, open a command prompt and run the following command to install the CLI tool, this is a mandatory installation:

  dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
  
  
  Step 2 - Generate LivingDoc
  
  
  1- Navigate to the path where your SpecFlow project is located. In this example, the solution was set up in the C:\work folder:
  
    cd C:\webautomationtask\WebAutomationTask\WebAutomationTask\bin\Debug\netcoreapp3.1
    
    
 2- Now you can run the LivingDoc CLI by using the below command to generate the report.
 
 livingdoc test-assembly C:\webautomationtask\WebAutomationTask\WebAutomationTask\bin\Debug\netcoreapp3.1\WebAutomationTask.dll -t C:\webautomationtask\WebAutomationTask\WebAutomationTask\bin\Debug\netcoreapp3.1\TestExecution.json
 
 
 Step 3 - Viewing LivingDoc
 
 1- The command-line tool will generate an HTML file titled LivingDoc.html in the same folder as the output directory of the SpecFlow project. You can manually navigate to this folder and open this file in your favorite browser or use the command-line tool to do it:
 
 C:\webautomationtask\WebAutomationTask\WebAutomationTask\bin\Debug\netcoreapp3.1\LivingDoc.html
 
 
 Here is Executed LivingDoc file for this Task:
 
  
  
