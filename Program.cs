using cse210_05.Game.Casting;
using cse210_05.Game.Directing;
using cse210_05.Game.Scripting;
using cse210_05.Game.Services;


namespace cse210_05
{
    class Program
    {
        // Starts the program using the given arguments.
        
        static void Main(string[] args)
        {
            
            // create the cast
            
            Point position2 = new Point(800,600);
            Point position = new Point(50,600);
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("snake", new Snake(300, "green"));
            cast.AddActor("snake2", new Snake(600, "red"));
            cast.AddActor("score", new Score(position));
            cast.AddActor("score2", new Score(position2));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
            
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}