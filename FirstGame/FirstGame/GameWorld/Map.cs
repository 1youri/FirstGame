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

        private bool mousedown;

        public Map()
        {
            Cells = CellCreation.CreateCells();
            CurrentCell = CellCreation.LoadFromFile("1");
            mousedown = false;
        }

        public void LoadMap(ContentManager content)
        {
            foreach (Cell c in Cells)
            {
                c.LoadCell(content);
            }
            CurrentCell.LoadCell(content);
        }

        public void UpdateMap(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            if (mouse.RightButton == ButtonState.Pressed && !mousedown && FirstGame.mapcreation == true)
            {
                CurrentCell = CellCreation.updateMapFile(CurrentCell, mouse, "1", "1");
                mousedown = true;
            }
            else if (mouse.RightButton == ButtonState.Released) mousedown = false;
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            CurrentCell.DrawCell(spriteBatch);
        }
    }
}
