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
    class Enemy
    {
        public entProp.Location Loc { get; set; }
        public SprInfo SprInf { get; set; }
        public entProp.Location Destination { get; set; }
        public Vector2 MoveVector { get; set; }
        public Vector2 destVector { get; set; }
        public int UpdateSpeed { get; set; }
        public int UpdateTime { get; set; }
        public bool foundPlayer { get; set; }
        public bool seesPlayer { get; set; }
        public bool Update { get; set; }

        public Enemy(entProp.Location Loc, int updateSpeed)
        {
            this.UpdateSpeed = updateSpeed;
            this.Loc = Loc;
            this.SprInf = new SprInfo(new Rectangle(0, 0, 64, 32), new Vector2(18, 16), new Rectangle(Loc.rX, Loc.rY, 64, 32));
            this.Destination = new entProp.Location(Loc.rX, Loc.rY, 0);
            destVector = new Vector2(1, 1);
            foundPlayer = false;
            Update = true;
            seesPlayer = false;
        }
    }
}
