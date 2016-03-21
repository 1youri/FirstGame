using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.GameWorld.objects
{
    public class Wallobj
    {
        public List<Wall> Walls { get; set; }
        public Texture2D Sprite { get; set; }

        public Wallobj(List<Wall> Walls)
        {
            this.Walls = Walls;
        }

    }
}
