namespace SimpleLexer;

internal class Program {

    public static void Main()
    {
        const string path = "Content.txt";
        
        if (!File.Exists(path))
        {
            Console.WriteLine("Not found File");
            return;
        }

        var content = File.ReadAllText(path);
        var lexer = new Lexer();

        var tokens = lexer.Parse(content);
    }
}