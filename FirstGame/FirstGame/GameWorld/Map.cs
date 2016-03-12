using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.GameWorld
{
    class Map
    {
        public List<Cell> Cells { get; set; }
        public List<objects.Wall> Walls { get; set; }

        public Map()
        {
            Cells = new List<Cell>();
            Walls = new List<objects.Wall>()
            {
                new objects.Wall(new Rectangle(200,200,50,50),new SprInfo(new Rectangle(0,0,0,0),new Rectangle(0,0,50,50),new Vector2(25,25)))
            };
        }

        public void drawMap(SpriteBatch spriteBatch)
        {

        }
    }
}
