# BDD Testing With ReqnRoll

## Project Setup

### Setup a new project

Go to the directory your projects are in and run (change the project name though):
```
mkdir SAMPLE_BDD
cd SAMPLE_BDD
dotnet new reqnroll-project
dotnet add reference ../MAIN_PROJECT
dotnet sln .. add SAMPLE_BDD.csproj
```

### Add Packages
```
dotnet add package Reqnroll.NUnit
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
```

### VSCode Setup (Optional)

Install the [Cucumber](https://marketplace.visualstudio.com/items?itemName=CucumberOpen.cucumber-official) Extension for vscode

At the top level of your repository, create ``.vscode/settings.json`` and add the suggested configuration to allow cucumber to properly detect the structure of your project (change the project path though)

```
{
    "explorer.fileNesting.enabled": true,
    "explorer.fileNesting.patterns": { 
        "*.feature": "${capture}.feature.cs"
    },
    "files.exclude": { 
        "**/obj/": true,
        "**/bin/": true,
    },
    "cucumber.glue": [ 
        "SAMPLE_BDD/StepDefinitions/**/*.cs",
    ],
    "cucumber.features": [
        "SAMPLE_BDD/Features/**/*.feature",
    ]
}
```

This should get things like autocomplete and error detection working for reqnroll.


## Writing Tests

There are two parts to reqnroll tests: features and step definitions.

Features are where you can use Gherkin syntax to write tests that look like the acceptance criteria of a user story.

The default example upon making a project is a test for a calculator

```
Feature: Calculator

Simple calculator for adding two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
```
This represents the feature part. This part is done, but it won't work as a test without a step definition.

Step definitions, as the name would suggest, define the steps within a scenario. The scenario above has 4 steps, which is recognized by reqnroll through use of the keywords Given, And, When, and Then. A step definition is needed for each.

Take the first step. All it says is that the first number is 50. We can write a step definition and set a variable to that value on the correlated step:

```
    private int num1;

    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int number)
    {
        num1 = number;
    }
```
This will now run when testing on the first step. The second and third steps are quite similar.

The final "Then" statement is when things are actually tested. ReqnRoll by default includes FluentAssertions, which just provides another way to write assertions.
First add ``using FluentAssertions;`` to the file, then we can set a step definition. 

```
    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        sum.Should().Be(result); // sum set in a previous step
    }
```

With this setup, we could also just use basic NUnit assertions for this if we wanted.

To do this, first add ``using NUnit.Framework;`` to the file. Then, the syntax is exactly the same as in Unit Testing:

```
    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        Assert.That(sum, Is.EqualTo(result)); // sum set in a previous step
    }
```

Both of these methods work. 

To run these tests, it is the same as an NUnit Test Project. Either run ``dotnet test`` or just click run in the testing tab in vscode.

## Why

This is all a lot for tests that could theoretically just be unit tests. It is situationally preferred though due to the readability of Gherkin syntax and the ability to reuse step definitions across multiple tests. Also reqnroll has some extra tools that can be helpful.
