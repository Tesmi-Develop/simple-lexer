using System.Diagnostics;

namespace SimpleLexer.Tokens;

[Token("[_a-zA-Z][_a-zA-Z0-9]{0,30}")]
[DebuggerDisplay("{Name}:{Content}")]
public class Identifier : BaseToken
{
    public Identifier(string content) : base(content)
    {
    }
}