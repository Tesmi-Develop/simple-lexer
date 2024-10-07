using System.Diagnostics;

namespace SimpleLexer.Tokens;

[Token(@"[^ \w]")]
[DebuggerDisplay("{Name}:{Content}")]
public class Symbol : BaseToken
{
    public Symbol(string content) : base(content)
    {
    }
}
