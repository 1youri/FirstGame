using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstGame.ent.chars
{
    class Enemy
    {
        public entProp.Location Loc { get; set; }
        public SprInfo SprInf { get; set; }
        public entProp.Location Destination { get; set; }
    }
}
