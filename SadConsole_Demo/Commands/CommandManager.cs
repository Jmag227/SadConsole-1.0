using System;
using Microsoft.Xna.Framework;

namespace RogueTutorial.Commands
{
    // Contains all generic actions performed on entities and tiles
    // including combat, movement, and so on.
    public class CommandManager
    {
        public CommandManager()
        {

        }

        // Move the actor BY +/- X&Y coordinates
        // returns true if the move was successful
        // and false if unable to move there
        public bool MoveActorBy(Actor actor, Point position)
        {
            return actor.MoveBy(position);
        }
    }
}
