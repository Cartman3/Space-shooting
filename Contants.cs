using System;
using Microsoft.VisualBasic;
using cse210_05.Game.Casting;

namespace cse210_05.Game
{
    // A tasty item that snakes like to eat.
    // The responsibility of Food is to select a random position and points that it's worth.
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Snake";
        public static int SNAKE_LENGTH = 1;

        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);

    }
}