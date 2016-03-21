using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
    public class Logic
    {
        public static Vector2 CalcVector(float Rotation)
        {
            return new Vector2(
                    (float)Math.Cos(Rotation),
                    -(float)Math.Sin(Rotation));
        }

        public static float CalcRot(Vector2 Direction)
        {

            return (float)Math.Atan2(Direction.X, -Direction.Y);

        }

        public static Rectangle Gridiffy(int LocX, int LocY)
        {
            return new Rectangle(LocX * 64, LocY * 64, 64, 64);
        }
        
        

        //public static string[] createemptystring()
        //{
        //    string[] returnarray = new string[16];
        //    for (int i = 0; i < 16; i++)
        //    {
        //        returnarray[i] = "";
        //        for (int j = 0; i < 29; i++)
        //        {
        //            returnarray[i] += 0;
        //        }
        //    }

        //    return returnarray;
        //}

    }
}
