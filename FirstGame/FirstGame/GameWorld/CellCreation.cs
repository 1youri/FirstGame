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
    class CellCreation
    {


        public static List<Cell> CreateCells()
        {
            List<Cell> CellList = new List<Cell>()
            {
                new Cell(
                    new objects.Wallobj(
                        new List<objects.Wall>()    //WoodWalls
                        {
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(5,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(6,5)))
                        }),
                    new objects.Wallobj(
                        new List<objects.Wall>()    //StoneWalls
                        {
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), new Rectangle(500, 200, 64, 64)))
                        }))
            };
            return CellList;
            
        }
    }
}
