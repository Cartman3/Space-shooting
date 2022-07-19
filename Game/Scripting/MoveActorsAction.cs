using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;


namespace cse210_05.Game.Scripting
{
    // An update action that moves all the actors.
    // The responsibility of MoveActorsAction is to move all the actors.

    public class MoveActorsAction : Action
    {
        // Constructs a new instance of MoveActorsAction.
        public MoveActorsAction()
        {
        }

        // <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
                
            }
        }
    }
}