using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;


namespace cse210_05.Game.Scripting
{
    // An output action that draws all the actors.
    // The responsibility of DrawActorsAction is to draw each of the actors.
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        // Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        // <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            List<Actor> segments2 = snake2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor score2 = cast.GetFirstActor("score2");
            Food food = (Food)cast.GetFirstActor("food");
            //List<Actor> bullets = snake.GetBullets();
            List<Actor> bullets = snake.GetBullets();
            
            List<Actor> bullets2 = snake2.GetBullets();

            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score);
            videoService.DrawActor(score2);
            videoService.DrawActors(bullets);
            videoService.DrawActors(bullets2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}