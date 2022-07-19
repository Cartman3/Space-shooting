using System.Collections.Generic;
using System;


namespace cse210_05.Game.Casting
{
    // A tasty item that snakes like to eat.
    // The responsibility of Food is to select a random position and points that it's worth.
    public class Food : Actor
    {
        private int points = 0;
        private Point position;
        private Point direction;
        
        // Constructs a new instance of an Food.
        public Food()
        {

            
            Reset();
        }

        // Gets the points this food is worth.
        public void LosePoints()
        {
            points = -1;
        }
        public int GetPoints()
        {
            return points;
        }

        // Selects a random position and points that the food is worth.
        public void Reset()
        {
            Random random = new Random();
            
            int x = random.Next(Constants.COLUMNS);
            int y = random.Next(Constants.ROWS);
            Point position = new Point(x, y);
            position = position.Scale(Constants.CELL_SIZE);
            SetPosition(position);
        }

    }
}