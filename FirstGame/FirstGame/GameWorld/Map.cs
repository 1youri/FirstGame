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
        public Cell CurrentCell { get; set; }
        


        public Map()
        {
            Cells = CellCreation.CreateCells();
            CurrentCell = Cells[0];
        }

        public void LoadMap(ContentManager content)
        {
            foreach (Cell c in Cells)
            {
                c.LoadCell(content);
            }
        }

        public void UpdateMap(GameTime gameTime)
        {

        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            CurrentCell.DrawCell(spriteBatch);
        }
    }
}
