using System;


namespace cse210_05.Game.Casting
{
    // A tasty item that snakes like to eat.
    // The responsibility of Food is to select a random position and points that it's worth.
    public class Score : Actor
    {
        private int points = 0;

        // Constructs a new instance of an Food.
        public Score(Point position)
        {
            AddPoints(3);
            SetPosition(position);
        }

        // Adds the given points to the score.
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Lives: {this.points}");
        }
        public int returnLives(){
            return points;
        }
    }
}