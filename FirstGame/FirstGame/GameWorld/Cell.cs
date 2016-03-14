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
    class Cell
    {
        public objects.Wallobj WallWood { get; set; }
        public objects.Wallobj WallStone { get; set; }
        
        public Cell(objects.Wallobj WallWood, objects.Wallobj WallStone)
        {
            this.WallWood = WallWood;
            this.WallStone = WallStone;
        }

        public void LoadCell(ContentManager content)
        {
            WallWood.Sprite = content.Load<Texture2D>("objects\\wall1.png");
            WallStone.Sprite = content.Load<Texture2D>("objects\\wall2.png");
        }



        public void DrawCell(SpriteBatch spriteBatch)
        {
            foreach (objects.Wall w in WallWood.Walls)
            {
                spriteBatch.Draw(WallWood.Sprite, w.SprInf.DestinationRect, w.SprInf.SourceRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);
            }
            foreach (objects.Wall w in WallStone.Walls)
            {
                spriteBatch.Draw(WallStone.Sprite, w.SprInf.DestinationRect, w.SprInf.SourceRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);
            }
        }
    }
}
