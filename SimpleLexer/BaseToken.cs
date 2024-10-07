using JetBrains.Annotations;

namespace SimpleLexer;

[PublicAPI]
public abstract class BaseToken
{
    public static string Name { get; private set; } = default!;
    public string Content { get; }

    protected BaseToken(string content)
    {
        Name = GetType().Name;
        Content = content;
    }
}