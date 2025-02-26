using Reqnroll;
using NUnit.Framework;

namespace BDD_Tests.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef
    private int num1;
    private int num2;
    private int sum;


    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.reqnroll.net/doc-sharingdata
        // To use the multiline text or the table argument of the scenario,
        // additional string/DataTable parameters can be defined on the step definition
        // method. 
        num1 = number;
        // throw new PendingStepException();
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        num2 = number;
        // throw new PendingStepException();
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //TODO: implement act (action) logic
        sum = num1 + num2;
        // throw new PendingStepException();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        //TODO: implement assert (verification) logic
        Assert.That(sum, Is.EqualTo(result));
        // throw new PendingStepException();
    }
}
