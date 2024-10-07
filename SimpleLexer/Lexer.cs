using System.Reflection;
using System.Text.RegularExpressions;

namespace SimpleLexer;

public class Lexer
{
    private List<BaseToken> _tokens = [];
    private int _position;
    private string _code = "";
    private readonly Dictionary<string, Type> _tokenClasses = [];

    public Lexer()
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                var data = Attribute.GetCustomAttribute(type, typeof(TokenAttribute));
                if (data is null) continue;

                _tokenClasses[((TokenAttribute)data).RegexPattern] = type;
            }
        }
    }
    
    public List<BaseToken> Parse(string code)
    {
        _code = code;
        _tokens = [];
        _position = 0;

        while (NextToken()) {}
        return _tokens;
    }

    private BaseToken InstantiateToken(Type type, string content)
    {
        if (!type.IsAssignableTo(typeof(BaseToken)))
            throw new ArgumentException();

        var constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        return (BaseToken)constructor[0].Invoke([content]);
    }

    private Regex BuildRegex(string pattern)
    {
        return new Regex($"^{pattern}");
    }
    
    private bool NextToken()
    {
        if (_position >= _code.Length)
        {
            return false;
        }

        foreach (var (pattern, tokenType) in _tokenClasses)
        {
            var result = BuildRegex(pattern).Match(_code.Substring(_position));
            if (!result.Success) continue;
            
            var token = InstantiateToken(tokenType, result.Value);
            _tokens.Add(token);
            _position += result.Value.Length;
            return true;
        }

        _position++;
        return true;
    }
}