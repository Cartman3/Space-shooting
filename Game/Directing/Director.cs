using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Scripting;
using cse210_05.Game.Services;


namespace cse210_05.Game.Directing
{
    // A person who directs the game.
    // The responsibility of a Director is to control the sequence of play.
    public class Director
    {
        private VideoService videoService = null;

        // Constructs a new instance of Director using the given KeyboardService and VideoService.
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
        }

        // Starts the game by running the main game loop for the given cast and script.
        public void StartGame(Cast cast, Script script)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                ExecuteActions("input", cast, script);
                ExecuteActions("update", cast, script);
                ExecuteActions("output", cast, script);
            }
            videoService.CloseWindow();
        }

        // Calls execute for each action in the given group.
        private void ExecuteActions(string group, Cast cast, Script script)
        {
            List<Action> actions = script.GetActions(group);
            foreach(Action action in actions)
            {
                action.Execute(cast, script);
            }
        }
    }
}