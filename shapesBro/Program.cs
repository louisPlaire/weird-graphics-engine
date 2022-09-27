using cgLib;
using cgLib.KeyBoardInput;
using cgLib.Output;
using cgLib.Shapes;


class Program
{
    static void Main(string[] args)
    {
        ///<summary>
        /// This is a kinda like welcome script to show you what this engine can do.
        /// </summary>


        Console.BackgroundColor = ConsoleColor.Black;
        Console.CursorVisible = false;

        bool running = true;
        Vector2 playerPos = new Vector2(4, 2);
        Vector2 playerSize = new Vector2(4, 2);



        Rectangle[] rectangles = new Rectangle[10];

        for(int i = 0; i < rectangles.Length; i++)
        {
            rectangles[i] = new Rectangle(new Vector2(i * 8, 40), new Vector2(i * 2, i), ConsoleColor.White);
        }


        while (running)
        {
            Console.SetCursorPosition(0, 0);

            foreach(Rectangle rect in rectangles)
            {
                rect.position.y -= rect.size.x / 2;
                rect.UpdateAndDraw();
                if(rect.position.y < 0)
                {
                    rect.position.y = rect.position.y + 30;
                }
            }

        }

    }
}


