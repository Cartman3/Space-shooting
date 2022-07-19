using System.Collections.Generic;
using System.Reflection.Metadata;
using Raylib_cs;
using cse210_05.Game.Casting;


namespace cse210_05.Game.Services
{
    /// The responsibility of the class of objects is to draw the game state on the screen. 
    
    public class VideoService
    {
        private bool debug = false;

        // Constructs a new instance of KeyboardService using the given cell size.
        public VideoService(bool debug)
        {
            this.debug = debug;
        }

        // Closes the window and releases all resources.
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        // Clears the buffer in preparation for the next rendering. This method should be called at
        // the beginning of the game's output phase.
        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            if (debug)
            {
                DrawGrid();
            }
        }

        // Draws the given actor's text on the screen.
        public void DrawActor(Actor actor)
        {
            string text = actor.GetText();
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            int fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        // Draws the given list of actors on the screen.
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

        public void DrawBullets(List<Food> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }
        
        // Copies the buffer contents to the screen. This method should be called at the end of
        // the game's output phase.
        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        // Whether or not the window is still open.
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        // Opens a new window with the provided title.
        public void OpenWindow()
        {
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        // Draws a grid on the screen.
        private void DrawGrid()
        {
            for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, Constants.MAX_X, y, Raylib_cs.Color.GRAY);
            }
        }

        // Converts the given color to it's Raylib equivalent.
        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetRed();
            int g = color.GetGreen();
            int b = color.GetBlue();
            int a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }

    }
}