using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent.Attacks
{
    class insBullet
    {
        public entProp.Location Loc { get; set; }
        public SprInfo SprInf { get; set; }
        public bool Collision { get; set; }
        public bool Break { get; set; }

        public insBullet(entProp.Location Loc, Vector2 Direction, SprInfo SprInf)
        {
            this.Loc = Loc;
            this.Loc.Direction = Direction;
            this.SprInf = SprInf;
            Collision = false;
            Break = false;
        }

    }
}
