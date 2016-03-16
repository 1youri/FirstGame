using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace FirstGame.GameWorld
{
    class CellCreation
    {
        public static Cell updateMapFile(Cell CurrentCell, MouseState mouse, string Block, string filename)
        {
            string[] filedata = File.ReadAllLines("maps\\" + filename + ".YMF");
            int X = (int)Math.Floor(mouse.X / 64.0);
            int Y = (int)Math.Floor(mouse.Y / 64.0);
            filedata[Y] = filedata[Y].Remove(X, 1);
            filedata[Y] = filedata[Y].Insert(X, Block);

            File.WriteAllLines("maps\\" + filename + ".YMF", filedata);
            if (Block == "1")
            {
                CurrentCell.WallWood.Walls.Add(new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(X, Y))));
            }

            return CurrentCell;
        }

        public static Cell LoadFromFile(string filename)
        {
            Cell returncell = new Cell(new objects.Wallobj(new List<objects.Wall>()), new objects.Wallobj(new List<objects.Wall>()));

            string[] filedata = File.ReadAllLines("maps\\" + filename + ".YMF");

            for (int y = 0; y < 17; y++)
            {
                for (int x = 0; x < 29; x++)
                {
                    if (filedata[y].Substring(x, 1) == "1")
                    {
                        returncell.WallWood.Walls.Add(new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(x, y))));
                    }
                    if (filedata[y].Substring(x, 1) == "2")
                    {
                        returncell.WallStone.Walls.Add(new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(x, y))));
                    }

                }
            }

            return returncell;
        }


        public static List<Cell> CreateCells()
        {
            List<Cell> CellList = new List<Cell>()
            {
                new Cell(
                    new objects.Wallobj(
                        new List<objects.Wall>()    //WoodWalls
                        {
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(5,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(6,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(7,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(8,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(9,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(10,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(11,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(12,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(13,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(14,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(15,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(16,5)))
                        }),
                    new objects.Wallobj(
                        new List<objects.Wall>()    //StoneWalls
                        {
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), Logic.Gridiffy(1,5))),
                            new objects.Wall(new SprInfo(new Rectangle(0, 0, 32, 32), new Vector2(25, 25), new Rectangle(500, 200, 64, 64)))
                        }))
            };
            return CellList;
            
        }
    }
}
