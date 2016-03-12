using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.GameWorld.objects
{
    class Wallobj
    {
        public List<Wall> Walls { get; set; }
        public Texture2D Sprite { get; set; }

        public Wallobj()
        {
            Walls = new List<Wall>()
            {
                new Wall(new Rectangle(200,200,50,50),new SprInfo(new Rectangle(0,0,32,32),new Rectangle(200,200,50,50),new Vector2(25,25)))
            };
        }

    }
}
