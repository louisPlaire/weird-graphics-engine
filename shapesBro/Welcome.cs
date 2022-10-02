// See the Console Geometry documentation at https://plaireprojects.000webhostapp.com/
using cgLib;
using cgLib.Shapes;

public class Welcome
{
    public static void Main(string[] args)
    {
        Window.Init();

        Console.SetCursorPosition(0, 0);
        Console.WriteLine("This is a Welcome Script please see the documentation!");

        Vector2 position = new Vector2(50, 10);
        Vector2 size = new Vector2(10, 5);

        Rectangle rec = new Rectangle(position, size, ConsoleColor.DarkRed);
        rec.Draw();

        Console.ReadKey();
    }
}