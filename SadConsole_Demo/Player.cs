using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RogueTutorial
{
    // Creates a new player
    // Default glyph is @
    public class Player : Actor
    {
        public Player(Color foreground, Color background) : base(foreground, background, '@')
        {

        }
    }
}
