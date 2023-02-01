using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Fruit : Grid
    {
        public void setPosition()
        {
            fruitX = rng.Next(1, width - 1);
            fruitY = rng.Next(0, height - 1);
        }

        public int getX()
        {
            return fruitX;
        }
        public int getY()
        {
            return fruitY;
        }


        private Random rng = new Random();
        private int fruitX = 0;
        private int fruitY = 0;
    }
}
