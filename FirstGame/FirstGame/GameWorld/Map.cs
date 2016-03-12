using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FirstGame.GameWorld
{
    class Map
    {
        public List<Cell> Cells { get; set; }
        public GameWorld.objects.Wallobj Wall { get; set; }


        public Map()
        {
            Cells = new List<Cell>();
            Wall = new objects.Wallobj();
        }

        public void LoadMap(ContentManager content)
        {
            Wall.Sprite = content.Load<Texture2D>("objects\\wall1.png");
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            foreach (objects.Wall w in Wall.Walls)
            {
                spriteBatch.Draw(Wall.Sprite, w.SprInf.DestinationRect, w.SprInf.SourceRect, Color.White, 0, w.SprInf.Origin, SpriteEffects.None, 0);
            }
        }
    }
}
