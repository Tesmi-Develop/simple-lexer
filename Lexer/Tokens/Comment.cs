using System.Diagnostics;

namespace Lexer.Tokens;

[Token(@"\/\*(\*(?!\/)|[^*])*\*\/")]
[DebuggerDisplay("{Name}:{Content}")]
public class Comment : BaseToken
{
    public Comment(string content) : base(content)
    {
    }
}
