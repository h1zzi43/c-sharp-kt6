using App.Topics.Enums.T5_1_OrderStatus;

namespace App.Tests.Topics.Enums.T5_1_OrderStatus;

public class OrderWorkflowTests
{
    [Test]
    public void CanTransition_Basic()
    {
        Assert.That(OrderWorkflow.CanTransition(OrderStatus.New, OrderStatus.Paid), Is.True);
        Assert.That(OrderWorkflow.CanTransition(OrderStatus.Paid, OrderStatus.Shipped), Is.True);
        Assert.That(OrderWorkflow.CanTransition(OrderStatus.Shipped, OrderStatus.Delivered), Is.True);
        Assert.That(OrderWorkflow.CanTransition(OrderStatus.New, OrderStatus.Cancelled), Is.True);
        Assert.That(OrderWorkflow.CanTransition(OrderStatus.Delivered, OrderStatus.Paid), Is.False);
        Assert.That(OrderWorkflow.CanTransition(OrderStatus.Cancelled, OrderStatus.Paid), Is.False);
    }

    [Test]
    public void Next_Works_And_Throws_On_Terminals()
    {
        Assert.That(OrderWorkflow.Next(OrderStatus.New), Is.EqualTo(OrderStatus.Paid));
        Assert.That(OrderWorkflow.Next(OrderStatus.Paid), Is.EqualTo(OrderStatus.Shipped));
        Assert.That(OrderWorkflow.Next(OrderStatus.Shipped), Is.EqualTo(OrderStatus.Delivered));
        Assert.Throws<InvalidOperationException>(() => OrderWorkflow.Next(OrderStatus.Delivered));
        Assert.Throws<InvalidOperationException>(() => OrderWorkflow.Next(OrderStatus.Cancelled));
    }

    [Test]
    public void Parse_Is_Case_Insensitive()
    {
        Assert.That(OrderWorkflow.Parse("new"), Is.EqualTo(OrderStatus.New));
        Assert.That(OrderWorkflow.Parse("PAID"), Is.EqualTo(OrderStatus.Paid));
        Assert.That(OrderWorkflow.Parse("Shipped"), Is.EqualTo(OrderStatus.Shipped));
        Assert.That(OrderWorkflow.Parse("delivered"), Is.EqualTo(OrderStatus.Delivered));
        Assert.That(OrderWorkflow.Parse("Cancelled"), Is.EqualTo(OrderStatus.Cancelled));
        Assert.Throws<ArgumentNullException>(() => OrderWorkflow.Parse(null!));
        Assert.Throws<ArgumentException>(() => OrderWorkflow.Parse("unknown"));
    }
}
