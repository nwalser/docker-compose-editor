namespace Sapphire.Data.Validation;

public class Issue(IssueType type, string message)
{
    public IssueType Type { get; set; } = type;
    public string Message { get; set; } = message;
}