using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FirstGame.ent
{
    public abstract class Entity
    {
        public entProp.Location Loc { get; set; }
        public SprInfo SprInf { get; set; }
    }
}
