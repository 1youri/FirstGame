using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
    public class SprInfo
    {
        public Rectangle SourceRect { get; set; }
        public Rectangle DestinationRect { get; set; }
        public Vector2 Origin { get; set; }
        
        public SprInfo(Rectangle SourceRect, Rectangle DestinationRect, Vector2 Origin)
        {
            this.SourceRect = SourceRect;
            this.DestinationRect = DestinationRect;
            this.Origin = Origin;
        }
        public SprInfo()
        {

        }
    }
}
