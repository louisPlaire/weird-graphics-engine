

using cgLib.Output;
/// <summary>
/// Console Geometry Libray
/// </summary>
namespace cgLib
{
    /// <summary>
    /// A two dimensional vector with an x and a y coordinate.
    /// </summary>
    public class Vector2
    {
        public int x = 0, y = 0;
        public Vector2(int _x = 0, int _y = 0)
        {
            x = _x;
            y = _y;
        }
        public static Vector2 Addition(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public override string ToString()
        {
            return $"Vector2({x}, {y})";
        }
    }

    public static class Mathf
    {
        public static float Distance(Vector2 a, Vector2 b)
        {
            float distanceAB = MathF.Sqrt((b.x - a.x) * (b.x - a.x) - (b.y - a.y) * (b.y - a.y));
            return distanceAB;
        }
    }

    namespace Shapes
    {
        /// <summary>
        /// A simple rectangle with a position and a size.
        /// </summary>
        public class Rectangle
        {
            public ConsoleColor color;
            public Vector2 position = new Vector2();
            public Vector2 size = new Vector2();
            public bool isActive = true;
            public char body = '█';
            List<Vector2> positions = new List<Vector2>();

            public Rectangle(Vector2 position, Vector2 size, ConsoleColor color)
            {
                this.position = position;
                this.size = size;
                this.color = color;
            }
            /// <summary>
            /// Throw the Shape onto the screen.
            /// </summary>
            public void Draw()
            {
                isActive = true;
                if (isActive)
                {
                    positions.Clear();
                    Console.ForegroundColor = color;
                    for (int i = 0; i < size.x; i++)
                    {
                        for (int h = 0; h < size.y; h++)
                        {
                            if (position.x < 0 || position.x > Console.BufferWidth - 10 || position.y > 27 || position.y < 0)
                                goto end;
                            Console.SetCursorPosition(position.x, position.y);
                            Console.WriteLine(body);
                            if (position.x - i < 0 || position.x - i > Console.BufferWidth - 10 || position.y - h > 27 || position.y - h < 0)
                                goto end;
                            positions.Add(new Vector2(position.x - i, position.y - h));
                            Console.SetCursorPosition(position.x - i, position.y - h);
                            Console.WriteLine(body);
                        end:;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            /// <summary>
            /// Redraw the Shape.
            /// </summary>
            public void Update()
            {
                if (isActive)
                {
                    for (int i = 0; i < positions.Count; i++)
                    {
                        Console.SetCursorPosition(positions[i].x, positions[i].y);
                        if (positions[i].x < 0 || positions[i].x > Console.BufferWidth || positions[i].y > Console.BufferHeight || positions[i].y < 0)
                            goto end;
                        Console.WriteLine(' ');
                    end:;
                    }
                }
            }
            public void UpdateAndDraw()
            {
                Update();
                Draw();
            }
            /// <summary>
            /// Destroy the Shape.
            /// </summary>
            public void Destroy()
            {
                foreach (var pos in positions)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.WriteLine(' ');
                }
                isActive = false;
            }
            public Vector2 GetPosition()
            {
                Vector2 pos = new Vector2(position.x, position.y);
                return pos;
            }
            public Vector2 GetSize()
            {
                Vector2 s = new Vector2(size.x, size.y);
                return s;
            }
            public void GetBounds()
            {
                List<Vector2> bounds = new List<Vector2>();
                bounds = positions;
            }
        }

        public class Triangle
        {
            public ConsoleColor color;
            public Vector2 position = new Vector2();
            public Vector2 size = new Vector2();
            public bool isActive = true;
            public char body = '█';
            List<Vector2> positions = new List<Vector2>();

            public Triangle(Vector2 position, Vector2 size, ConsoleColor color)
            {
                this.position = position;
                this.size = size;
                this.color = color;
            }

            public void Draw()
            {
                isActive = true;
                if (isActive)
                {
                    positions.Clear();
                    Console.ForegroundColor = color;

                    
                    Console.SetCursorPosition(position.x + size.x/2, position.y - size.y);
                    Console.WriteLine(body);

                    for (int h = 0; h < size.x; h++)
                    {
                        for (int i = 0; i < size.x / 2; i++)
                        {
                            Console.SetCursorPosition(position.x + size.x / 2 + i + h, position.y - size.y + i);
                            Console.WriteLine(body);
                            Console.SetCursorPosition(position.x + size.x / 2 - i + h, position.y - size.y + i);
                            Console.WriteLine(body);
                        }
                    }
                    

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            public void Update()
            {
                if (isActive)
                {
                    for (int i = 0; i < positions.Count; i++)
                    {
                        Console.SetCursorPosition(positions[i].x, positions[i].y);
                        if (positions[i].x < 0 || positions[i].x > Console.BufferWidth || positions[i].y > Console.BufferHeight || positions[i].y < 0)
                            goto end;
                        Console.WriteLine(' ');
                    end:;
                    }
                }
            }
            public void UpdateAndDraw()
            {
                Update();
                Draw();
            }
            public void Destroy()
            {
                foreach (var pos in positions)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.WriteLine(' ');
                }
                isActive = false;
            }
            public Vector2 GetPosition()
            {
                Vector2 pos = new Vector2(position.x, position.y);
                return pos;
            }
            public Vector2 GetSize()
            {
                Vector2 s = new Vector2(size.x, size.y);
                return s;
            }
            public void GetBounds()
            {
                List<Vector2> bounds = new List<Vector2>();
                bounds = positions;
            }
        }
    }

    namespace Output
    {
        /// <summary>
        /// Display some text in the first console line.
        /// </summary>
        public class DirectOutput
        {
            public void Put(string op)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(op + "                                                                                                    ");
            }
            public void Put(int op)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(op + "                                                                                                    ");
            }
        }
    }

    namespace KeyBoardInput
    {
        /// <summary>
        /// Allows you to gather some KeyBoard Input.
        /// </summary>
        public static class Input
        {
            /// <summary>
            /// Get the current Key pressed.
            /// </summary>
            /// <returns></returns>
            public static ConsoleKey GetKey()
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                return key;
            }            
        }
        /// <summary>
        /// All the Keys avaible.
        /// </summary>
        public static class KeyCode
        {
            public static ConsoleKey
                A = ConsoleKey.A,
                B = ConsoleKey.B,
                C = ConsoleKey.C,
                D = ConsoleKey.D,
                E = ConsoleKey.E,
                F = ConsoleKey.F,
                G = ConsoleKey.G,
                H = ConsoleKey.H,
                I = ConsoleKey.I,
                J = ConsoleKey.J,
                K = ConsoleKey.K,
                L = ConsoleKey.L,
                M = ConsoleKey.M,
                N = ConsoleKey.N,
                O = ConsoleKey.O,
                P = ConsoleKey.P,
                Q = ConsoleKey.Q,
                R = ConsoleKey.R,
                S = ConsoleKey.S,
                T = ConsoleKey.T,
                U = ConsoleKey.U,
                V = ConsoleKey.V,
                W = ConsoleKey.W,
                X = ConsoleKey.X,
                Y = ConsoleKey.Y,
                Z = ConsoleKey.Z;
                


        }
    }

    

}
