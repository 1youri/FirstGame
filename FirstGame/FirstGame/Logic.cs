using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
    class Logic
    {
        public static Vector2 CalcVector(float Rotation)
        {
            return new Vector2(
                    (float)Math.Cos(Rotation),
                    -(float)Math.Sin(Rotation));
        }
    }
}
