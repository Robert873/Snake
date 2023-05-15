using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        public void start()
        {
            fruit.setPosition();

            // The game loop that runs until a gameover is reach
            while (gameOver != true)
            {
                grid.draw(player.get_x(), player.get_y(), player.getTailX(), player.getTailY(), fruit.getX(), fruit.getY());
                if(Console.KeyAvailable)
                player.input();
                player.update();
                if (player.checkCollision(fruit.getX(), fruit.getY(), fruit) == true)
                    gameOver = true;
                System.Threading.Thread.Sleep(250);
            }

            Console.WriteLine("\n\nScore: "+ player.getScore());
        }


        // Initialises the game objects
        private Grid grid = new Grid();
        private Player player = new Player();
        private Fruit fruit = new Fruit();

        private bool gameOver = false;
        
        
    }
}