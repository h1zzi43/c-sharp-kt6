using App.Topics.ExplicitInterface.T2_1_DualFormatter;

namespace App.Tests.Topics.ExplicitInterface.T2_1_DualFormatter;

public class DualFormatterTests
{
    [Test]
    public void Constructor_Validates_Title()
    {
        Assert.Throws<ArgumentException>(() => new Report("", 1));
        Assert.Throws<ArgumentNullException>(() => new Report(null!, 1));
    }

    [Test]
    public void Explicit_Serializations_Are_Different()
    {
        var report = new Report("Q1", 42);
        var json = ((IJsonSerializable)report).Serialize();
        var xml = ((IXmlSerializable)report).Serialize();
        Assert.That(json, Does.Contain("Q1").And.Contain("42").And.Contain("{").And.Contain("}"));
        Assert.That(xml, Does.Contain("Q1").And.Contain("42").And.Contain("<").And.Contain(">").And.Not.Contain("{"));
        Assert.That(report.ToString(), Does.Contain("Report").And.Contain("Q1").And.Contain("42"));
    }
}
