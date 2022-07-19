using System.Collections.Generic;
using Raylib_cs;
using cse210_05.Game.Casting;


namespace cse210_05.Game.Services
{
    // The responsibility of a KeyboardService is to indicate whether or not a key is up or down.
    public class KeyboardService
    {
        private Dictionary<string, KeyboardKey> keys
                = new Dictionary<string, KeyboardKey>();

        // Constructs a new instance of KeyboardService using the given cell size.
        public KeyboardService()
        {
            keys["w"] = KeyboardKey.KEY_W;
            keys["a"] = KeyboardKey.KEY_A;
            keys["s"] = KeyboardKey.KEY_S;
            keys["d"] = KeyboardKey.KEY_D;
            keys["i"] = KeyboardKey.KEY_I;
            keys["j"] = KeyboardKey.KEY_J;
            keys["k"] = KeyboardKey.KEY_K;
            keys["l"] = KeyboardKey.KEY_L;
            keys["shift"] = KeyboardKey.KEY_LEFT_SHIFT;
            keys["space"] = KeyboardKey.KEY_SPACE;
        }

        // Checks if the given key is currently down.
        public bool IsKeyDown(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyDown(raylibKey);
        }

        // Checks if the given key is currently up.
        public bool IsKeyUp(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyUp(raylibKey);
        }

    }
}