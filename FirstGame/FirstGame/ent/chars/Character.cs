using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FirstGame.ent.chars
{
    public abstract class Character : Entity
    {
        public entProp.Location Destination { get; set; }
        public Vector2 MoveVector { get; set; }
        public Vector2 destVector { get; set; }
    }
}
