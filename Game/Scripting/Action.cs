using cse210_05.Game.Casting;


namespace cse210_05.Game.Scripting 
{
    // The responsibility of action is to do something that is integral or important in the game. 
    // Thus, it has one method, Execute(...), which should be overridden by derived classes.
    public interface Action
    {
        // Executes something that is important in the game. This method should be overriden by 
        // derived classes.
        void Execute(Cast cast, Script script);
    }
}