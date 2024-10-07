namespace SimpleLexer;

[AttributeUsage(AttributeTargets.Class)]
public class TokenAttribute : Attribute
{
    public string RegexPattern { get; private set; }

    public TokenAttribute(string pattern)
    {
        RegexPattern = pattern;
    }
}
