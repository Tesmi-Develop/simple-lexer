using System.Diagnostics;

namespace SimpleLexer.Tokens;

[Token(@"\/\*(\*(?!\/)|[^*])*\*\/")]
[DebuggerDisplay("{Name}:{Content}")]
public class Comment : BaseToken
{
    public Comment(string content) : base(content)
    {
    }
}
