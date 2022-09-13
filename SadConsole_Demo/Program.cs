using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace RogueTutorial
{
    class GameLoop
    {

        public const int Width = 80;
        public const int Height = 25;

        private static TileBase[] _tiles; // an array of TileBase that contains all of the tiles for a map
        private const int _roomWidth = 10; // demo room width
        private const int _roomHeight = 20; // demo room height

        private static Player player;

        static void Main(string[] args)
        {
            // Setup the engine and creat the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            CheckKeyboard();
        }

        private static void Init()
        {
            //Build the room's walls then carve out some floors
            CreateWalls();
            CreateFloors();

            // Any custom loading and prep. We will use a sample console for now

            //Console startingConsole = new Console(Width, Height);
            //startingConsole.FillWithRandomGarbage();
            //startingConsole.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
            //startingConsole.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);
            Console startingConsole = new ScrollingConsole(Width, Height, Global.FontDefault, new Rectangle(0, 0, Width, Height), _tiles);

            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;

            //create an instance of a player
            CreatePlayer();

            // add the player Entity to our only console
            // so it will display on screen
            startingConsole.Children.Add(player);
        }

        // Scans the SadConsole's Global KeyboardState and triggers behaviour
        // based on the button pressed.
        private static void CheckKeyboard()
        {
            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Keyboard movement for Player character: Up arrow
            // Decrement player's Y coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                player.MoveBy(new Point(0, -1));
            }

            // Keyboard movement for Player character: Down arrow
            // Increment player's Y coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                player.MoveBy(new Point(0, 1));
            }

            // Keyboard movement for Player character: Left arrow
            // Decrement player's X coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                player.MoveBy(new Point(-1, 0));
            }

            // Keyboard movement for Player character: Right arrow
            // Increment player's X coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                player.MoveBy(new Point(1, 0));
            }
        }

        // Create a player using the Player class
        // and set its starting position
        private static void CreatePlayer()
        {
            player = new Player(Color.Yellow, Color.Transparent);
            player.Position = new Point(5, 5);
        }

        // Carve out a rectangular floor using the TileFloors class
        private static void CreateFloors()
        {
            //Carve out a rectangle of floors in the tile array
            for (int x = 0; x < _roomWidth; x++)
            {
                for (int y = 0; y < _roomHeight; y++)
                {
                    // Calculates the appropriate position (index) in the array
                    // based on the y of tile, width of map, and x of tile
                    _tiles[y * Width + x] = new TileFloor();
                }
            }
        }

        // Flood the map using the TileWall class
        private static void CreateWalls()
        {
            // Create an empty array of tiles that is equal to the map size
            _tiles = new TileBase[Width * Height];

            //Fill the entire tile array with floors
            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new TileWall();
            }
        }

         // IsTileWalkable checks
        // to see if the actor has tried
        // to walk off the map or into a non-walkable tile
        // Returns true if the tile location is walkable
        // false if tile location is not walkable or is off-map

        public static bool IsTileWalkable(Point location)
        {
            // first make sure that actor isn't trying to move
            // off the limits of the map
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;
            // then return whether the tile is walkable
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }
        









    }
}