using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent.entProp
{
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int rX { get { return Convert.ToInt32(Math.Round(this.X)); } }
        public int rY { get { return Convert.ToInt32(Math.Round(this.Y)); } }
        public float Rotation { get; set; }
        public Vector2 Direction { get; set; }





        public Location(double X, double Y, float Rotation)
        {
            this.X = X;
            this.Y = Y;
            this.Rotation = Rotation;
        }
    }
}
