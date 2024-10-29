namespace TJC.Priority.Tests.Prioritization;

[TestClass]
public class ThenTests
{
    [TestMethod]
    public void Then_SetsPrioritiesInOrder()
    {
        // Arrange
        var priority1 = new Priority();
        var priority2 = new Priority();
        var priority3 = new Priority();

        // Act
        priority1.Then(priority2).Then(priority3);

        // Trace
        Trace.WriteLine($"{nameof(priority1)}: {Priority.GetPrioritiesToString(priority1)}");
        Trace.WriteLine($"{nameof(priority2)}: {Priority.GetPrioritiesToString(priority2)}");
        Trace.WriteLine($"{nameof(priority3)}: {Priority.GetPrioritiesToString(priority3)}");

        // Assert
        Assert.AreEqual(1, priority1.Value);
        Assert.AreEqual(2, priority2.Value);
        Assert.AreEqual(3, priority3.Value);
    }
}
