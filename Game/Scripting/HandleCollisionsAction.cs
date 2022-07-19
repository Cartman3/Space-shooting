using System;
using System.Collections.Generic;
using System.Data;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    // An update action that handles interactions between the actors.
    // The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    // collides with the food, or the snake collides with its segments, or the game is over.
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool hit = false;
        private bool hit2 = false;
        // Constructs a new instance of HandleCollisionsAction.
        public HandleCollisionsAction()
        {
        }

        // <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleHeadCollisions(cast);
                //HandleBodyCollisions(cast);
                HandleGameOver(cast);
            }
        }

        private void HandleHeadCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            Score score = (Score)cast.GetFirstActor("score");
            Score score2 = (Score)cast.GetFirstActor("score2");
            List<Actor> bullets = snake.GetBullets();
            List<Actor> bullets2 = snake2.GetBullets();
            Food food = (Food)cast.GetFirstActor("food");
            List<Actor> temp = new List<Actor>();
            foreach (Actor bullet in bullets){
                
                if (head.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score.AddPoints(points);
                    
                    if (score.returnLives() == 0)
                    {
                        isGameOver = true;
                    }
                
                
                    
                }
                
                if (head2.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score2.AddPoints(points);
                    hit = true;
                    if (score2.returnLives() == 0){
                        isGameOver = true;
                    }
                    
                
                
                }
                
            }
            
            // if (hit == true)
            // {
            //     bullets.Remove(bullets[index]);
            // }
            foreach (Actor bullet in bullets2){
                if (head2.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score2.AddPoints(points);
                    hit2 = true;
                    if (score2.returnLives() == 0){
                        isGameOver = true;
                    }
                
                
                    
                }
                
                if (head.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score.AddPoints(points);
                    hit2 = true;
                    if (score.returnLives() == 0){
                        isGameOver = true;
                    }
                
                }
            }
            // if (hit2 == true)
            // {
            //     bullets2.Remove(bullets[index]);
            // }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                    //segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
                snake.getWin(isGameOver);
                snake2.getWin(isGameOver);
            }
        }
        public bool returnTrue(){
            if (isGameOver == true){
                return true;
            }
            else{
                return false;
            }
        }
        
    }
}