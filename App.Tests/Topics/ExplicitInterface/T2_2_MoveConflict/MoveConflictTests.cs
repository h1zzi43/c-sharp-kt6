using App.Topics.ExplicitInterface.T2_2_MoveConflict;

namespace App.Tests.Topics.ExplicitInterface.T2_2_MoveConflict;

[Category("*")]
public class MoveConflictTests
{
    [Test]
    public void Explicit_Move_Works_Separately()
    {
        var cursor = new Cursor();
        Assert.That(cursor.X, Is.EqualTo(0));

        ((ILeft)cursor).Move(5);
        Assert.That(cursor.X, Is.EqualTo(-5));

        ((IRight)cursor).Move(10);
        Assert.That(cursor.X, Is.EqualTo(5));
    }
}
