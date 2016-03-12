using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.GameWorld.objects
{
    class Wall
    {
        public Rectangle Rect { get; set; }
        public SprInfo SprInf { get; set; }

        public Wall(Rectangle Rect, SprInfo SprInf)
        {
            this.Rect = Rect;
            this.SprInf = SprInf;
        }
    }

}
