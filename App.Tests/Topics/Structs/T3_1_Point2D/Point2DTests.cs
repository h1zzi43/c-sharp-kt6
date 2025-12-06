using App.Topics.Structs.T3_1_Point2D;

namespace App.Tests.Topics.Structs.T3_1_Point2D;

public class Point2DTests
{
    [Test]
    public void Length_And_Distance_Work()
    {
        var p = new Point2D(3, 4);
        Assert.That(p.Length, Is.EqualTo(5));
        var q = new Point2D(0, 0);
        Assert.That(p.DistanceTo(q), Is.EqualTo(5));
        Assert.That(q.DistanceTo(p), Is.EqualTo(5));
    }

    [Test]
    public void Add_And_Subtract_Work()
    {
        var a = new Point2D(1.5, -2);
        var b = new Point2D(2.5, 5);
        var sum = a.Add(b);
        var diff = a.Subtract(b);
        Assert.That(sum.X, Is.EqualTo(4));
        Assert.That(sum.Y, Is.EqualTo(3));
        Assert.That(diff.X, Is.EqualTo(-1));
        Assert.That(diff.Y, Is.EqualTo(-7));
    }

    [Test]
    public void Equality_By_Value()
    {
        var a = new Point2D(1, 2);
        var b = new Point2D(1, 2);
        Assert.That(a.Equals(b), Is.True);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }
}
