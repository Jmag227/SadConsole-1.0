using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RogueTutorial
{
    public class TileWall : TileBase
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default
        // and have a light gray foreground and a transparent background
        // represented by the # symbol
        public TileWall(bool blocksMovement = true, bool blocksLOS = true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
}
