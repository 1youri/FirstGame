using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.GameWorld.objects
{
    public class Wall : IWall
    {
        public SprInfo SprInf { get; set; }

        public Wall(SprInfo SprInf)
        {
            this.SprInf = SprInf;
        }
    }

}
