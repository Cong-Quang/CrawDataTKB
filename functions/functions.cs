public class Functions
{
    private static Functions gi;
    public static Functions Gi()
    {
        if (gi == null) gi = new Functions();
        return gi;
    }
    public void print(string s, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(s);
    }
    public void print(string s, int x, int y,ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.WriteLine(s);
    }
}