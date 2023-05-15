using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Player : Grid
    {

        // Handles the user input
        public void input()
        {
            var kp = Console.ReadKey();

            if (kp.Key == ConsoleKey.W && dir != Direction.down)
            {
                dir = Direction.up;
            }
            else if (kp.Key == ConsoleKey.S && dir != Direction.up)
            {
                dir = Direction.down;
            }

            else if (kp.Key == ConsoleKey.D && dir != Direction.left)
            {
                dir = Direction.right;
            }

            else if (kp.Key == ConsoleKey.A && dir != Direction.right)
            {
                dir = Direction.left;
            }
        }

        // Updates the player position and calls updateTail
        public void update()
        {
            prevTailX = x;
            prevTailY = y;

            switch (dir)
            {
                case Direction.up:
                    y--;
                    break;
                case Direction.down:
                    y++;
                    break;
                case Direction.left:
                    x--;
                    break;
                case Direction.right:
                    x++;
                    break;
            }

            updateTail();
        }

        // Updates the position of the tail of the snake
        private void updateTail()
        {
            int tempX = 0;
            int tempY = 0;


            if (dir != Direction.stop)
            {
                tailX[0] = x;
                tailY[0] = y;

                for (int i = 1; i < tailSize; i++)
                {
                    
                        tempX = tailX[i];
                        tempY = tailY[i];

                        tailX[i] = prevTailX;
                        tailY[i] = prevTailY;

                        prevTailX = tempX;
                        prevTailY = tempY;

                    
                }
            }
        }

        // Checks if the snake colides with the walls or collects fruit
        public bool checkCollision(int fruitX, int fruitY, Fruit fruit)
        {
            if (x == fruitX && y == fruitY)
            {
                tailSize++;
                score++;
                fruit.setPosition();
            }

            if (x == -1 || x == width  || y == -2 || y == height + 1)
                return true;

            for(int i = 1; i<tailSize; i++)
            {
                if (x == tailX[i] && y == tailY[i])
                    return true;
            }

            return false;

        }

        // Getters
        public int get_x()
        {
            return x;
        }

        public int get_y()
        {
            return y;
        }

        public int[] getTailX()
        {
            return tailX;
        }
        public int[] getTailY()
        {
            return tailY;
        }

        public int getScore()
        {
            return score;
        }

        // Variables
        private int x = 6;
        private int y = 6;

        private int[] tailX = new int[100];
        private int[] tailY = new int[100];

        private int prevTailX;
        private int prevTailY;
        private int tailSize = 4;

        private int score = 0;

        private enum Direction
        {
            stop,
            up,
            down,
            left,
            right
        }

        private Direction dir = Direction.stop;
    }
}
