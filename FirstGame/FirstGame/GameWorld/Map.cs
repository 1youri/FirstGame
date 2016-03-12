using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstGame.GameWorld
{
    class Map
    {
        public List<Cell> Cells { get; set; }

        public Map()
        {
            Cells = new List<Cell>();
        }
    }
}
