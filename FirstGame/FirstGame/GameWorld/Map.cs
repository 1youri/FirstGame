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
        public objects.Wallobj Wall1 { get; set; }


        public Map()
        {
            Cells = new List<Cell>();
            Wall1 = new objects.Wallobj();
        }

        public void LoadMap(ContentManager content)
        {
            Wall1.Sprite = content.Load<Texture2D>("objects\\wall1.png");
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            foreach (objects.Wall w in Wall1.Walls)
            {
                spriteBatch.Draw(Wall1.Sprite, w.SprInf.DestinationRect, w.SprInf.SourceRect, Color.White, 0, new Vector2(0,0), SpriteEffects.None, 0);
            }
        }
    }
}
