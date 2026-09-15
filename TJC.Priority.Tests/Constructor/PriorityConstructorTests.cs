namespace TJC.Priority.Tests;

public class PriorityConstructorTests
{
    [Fact]
    public void ConstructPriority_ValueDefaultIsZero()
    {
        // Arrange
        var priority1 = new Priority();
        var priority2 = new Priority();
        var priority3 = new Priority();

        // Trace
        Trace.WriteLine($"{nameof(priority1)}: {Priority.GetPrioritiesToString(priority1)}");
        Trace.WriteLine($"{nameof(priority2)}: {Priority.GetPrioritiesToString(priority2)}");
        Trace.WriteLine($"{nameof(priority3)}: {Priority.GetPrioritiesToString(priority3)}");

        // Assert
        Assert.Equal(0, priority1.Value);
        Assert.Equal(0, priority2.Value);
        Assert.Equal(0, priority3.Value);
    }
}
