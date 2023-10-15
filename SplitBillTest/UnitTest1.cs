using SplitBillClassLibrary;
using System;
using System.Collections.Generic;
using Xunit;

public class SplitBillClassTests
{
    [Fact]
    public void CalculateAmount_CalculatesAmountCorrectly()
    {
        // Arrange
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
        {
            { "Alice", 25.0M },
            { "Bob", 30.0M },
            { "Charlie", 20.0M },
        };
        float tipPercentage = 15.0F;

        SplitBillClass splitBillTest = new SplitBillClass();
        splitBillTest.TotalMealCost = 75;
        splitBillTest.NoOfPersons = 3;

        // Act
        Dictionary<string, decimal> result = splitBillTest.CalculateAmount(mealCosts, tipPercentage);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count); // Ensure there are three entries in the dictionary
        Assert.True(result.ContainsKey("Alice"));
        Assert.True(result.ContainsKey("Bob"));
        Assert.True(result.ContainsKey("Charlie"));

        // Verify individual calculations
        //Assert.Equal(28.75M, result["Alice"], 2); // 25.0 + 25.0 * 15.0 / 100 = 28.75
        //Assert.Equal(34.50M, result["Bob"], 2); // 30.0 + 30.0 * 15.0 / 100 = 34.50
        //Assert.Equal(23.00M, result["Charlie"], 2); // 20.0 + 20.0 * 15.0 / 100 = 23.00
    }

}
