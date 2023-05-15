using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Grid
    {
        // Prints the grid and game objects on screen
        public void draw(int player_x, int player_y, int[] tail_x, int[] tail_y, int fruit_x, int fruit_y)
        {
            Console.SetCursorPosition(0, 0);

            // Top barrier
            for (int top = 0; top < width; top++)
                Console.Write("#");
            Console.WriteLine();

            bool printed = false;

            for (int i = 0; i<height; i++)
            {

                for(int j = 0; j<width; j++)
                {
                    printed = false;

                    // The snake's head
                    if (j == player_x && i == player_y)
                        Console.Write('O');
                    
                    // Left side barrier
                    else if (j == 0)
                        Console.Write('#');

                    // Right side barrier
                    else if (j == width - 1)
                        Console.Write('#');
                    else
                    {
                        // The snake's body
                        for (int k = 0; k < tail_x.Length; k++)
                        {
                            if (tail_x[k] == 0)
                                break;
                            if (j == tail_x[k] && i == tail_y[k])
                            {
                                Console.Write('o');
                                printed = true;
                            }

                        }

                        // The fruit item
                        if (j == fruit_x && i == fruit_y)
                        {
                            Console.Write('F');
                            printed = true;
                        }

                        if (printed == false)
                            Console.Write(' ');
                    }

                }
                Console.WriteLine();
            }

            // Bottom barrier
            for (int bottom = 0; bottom < width; bottom++)
                Console.Write("#");

            Console.WriteLine();
        }

        // The size of the grid
        protected const int width = 16;
        protected const int height = 16;
    }
}
