// Тема 2, Задача T2.1_DualFormatter
// Явная реализация интерфейсов для разных форматов сериализации.

using System.Text;

namespace App.Topics.ExplicitInterface.T2_1_DualFormatter;

public interface IJsonSerializable
{
    string Serialize();
}

public interface IXmlSerializable
{
    string Serialize();
}

public sealed class Report : IJsonSerializable, IXmlSerializable
{
    private readonly string _title;
    private readonly int _value;

    public Report(string title, int value)
    {
        if (title == null)
            throw new ArgumentNullException(nameof(title));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        _title = title;
        _value = value;
    }

    string IJsonSerializable.Serialize()
    {
        return $"{{\"title\":\"{EscapeJson(_title)}\",\"value\":{_value}}}";
    }

    string IXmlSerializable.Serialize()
    {
        return $"<Report><Title>{EscapeXml(_title)}</Title><Value>{_value}</Value></Report>";
    }

    public override string ToString()
    {
        return $"Report: {_title}, value={_value}";
    }

    private static string EscapeJson(string input)
    {
        return input
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\b", "\\b")
            .Replace("\f", "\\f")
            .Replace("\n", "\\n")
            .Replace("\r", "\\r")
            .Replace("\t", "\\t");
    }

    private static string EscapeXml(string input)
    {
        var sb = new StringBuilder();
        foreach (char c in input)
        {
            if (c == '<')
                sb.Append("&lt;");
            else if (c == '>')
                sb.Append("&gt;");
            else if (c == '&')
                sb.Append("&amp;");
            else if (c == '"')
                sb.Append("&quot;");
            else if (c == '\'')
                sb.Append("&apos;");
            else
                sb.Append(c);
        }
        return sb.ToString();
    }
}
