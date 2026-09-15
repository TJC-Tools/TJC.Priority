namespace TJC.Priority.Tests.Prioritization;

public class BeforeTests
{
    [Fact]
    public void Before_ReordersPriorities()
    {
        // Arrange
        var priority1 = new Priority();
        var priority2 = new Priority();
        var priority3 = new Priority();

        // Act
        priority1.Then(priority2).Then(priority3);
        priority3.Before(priority1); // Now: priority3 -> priority1 -> priority2

        // Trace
        Trace.WriteLine($"{nameof(priority1)}: {Priority.GetPrioritiesToString(priority1)}");
        Trace.WriteLine($"{nameof(priority2)}: {Priority.GetPrioritiesToString(priority2)}");
        Trace.WriteLine($"{nameof(priority3)}: {Priority.GetPrioritiesToString(priority3)}");

        // Assert
        Assert.Equal(1, priority3.Value);
        Assert.Equal(2, priority1.Value);
        Assert.Equal(3, priority2.Value);
    }
}
