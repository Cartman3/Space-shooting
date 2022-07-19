using System;
using System.Collections.Generic;
using System.Linq;

namespace cse210_05.Game.Casting
{
    // A long limbless reptile.
    // The responsibility of Snake is to move itself.
    public class Snake : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private List<Actor> bullets = new List<Actor>();
        int spawn_spot = 0;
        bool isGameOver = false; 
        int time = 0;
        Point pos = new Point(0,0);
        Color snakeColor = new Color(0,0,0);
        
        // Constructs a new instance of a Snake.
        public Snake(int spawn_spot, string color)
        {
            this.spawn_spot = spawn_spot;
            PrepareBody(spawn_spot, color);
        }

        // Gets the snake's body segments.
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.ToArray());
        }

        // Gets the snake's head segment.
        public Actor GetHead()
        {
            return segments[0];
        }

        // Gets the snake's segments (including the head).
        public List<Actor> GetSegments()
        {
            return segments;
        }

        public List<Actor> GetBullets()
        {
            return bullets;
        }

        // Grows the snake's tail by the given number of segments.

        public void Shoot(int numberOfShots, Point dir)
        {
            for (int i = 0; i < numberOfShots; i++)
            {
                
                if (isGameOver != true){
                    
                    
                    Actor head = segments.First<Actor>();
                    Point velocity = head.GetVelocity();
                    Point position = head.GetPosition() ;
                    Point offset = new Point(2*Constants.CELL_SIZE,2*Constants.CELL_SIZE);
                    Point startingPos = position.Add(velocity);
                    //Point newVelo = dir.Add(velocity);
                    
                    Actor bullet = new Actor();
                    bullet.SetPosition(startingPos);
                    bullet.SetVelocity(velocity.Add(velocity));
                    bullet.SetText("f");
                    bullet.SetColor(Constants.YELLOW);
                    
                    if (bullets.Count > 5)
                    {
                        bullets.Remove(bullets[0]);
                    }
                    bullets.Add(bullet);
                    
                    
                    
                    
                    
                    
                    
                    
                    
                }
                
            }
        }
        public void RemoveBullet(int index)
        {
            
            
            bullets.Remove(bullets[index]);
        }
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                if (isGameOver != true){
                    Actor tail = segments.Last<Actor>();
                    Point velocity = tail.GetVelocity();
                    Point offset = velocity.Reverse();
                    Point position = tail.GetPosition().Add(offset);

                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText("#");
                    segment.SetColor(snakeColor);
                    segments.Add(segment);
                }
                
            }
        }

        // <inheritdoc/>
        public override void MoveNext()
        {
            
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
                
            }
            foreach (Actor bullet in bullets)
            {
                bullet.MoveNext();
                
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        // Turns the head of the snake in the given direction.
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }


        private void PrepareBody(int spawn_spot,string colors)
        {
            int x = spawn_spot;
            
            //int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                //Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                //Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                if (colors == "red"){
                    Color color = i == 0 ? Constants.RED : Constants.RED;
                    snakeColor = color;
                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText(text);
                    segment.SetColor(color);
                    segments.Add(segment);
                }
                if (colors == "green"){
                    Color color = i == 0 ? Constants.GREEN : Constants.GREEN;
                    snakeColor = color;
                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText(text);
                    segment.SetColor(color);
                    segments.Add(segment);
                }
            }
            
        }
        public void getWin(bool win){
                isGameOver = win;
            }
    }
}