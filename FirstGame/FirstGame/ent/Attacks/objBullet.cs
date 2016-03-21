using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent.Attacks
{
    public class objBullet
    {
        public Texture2D Sprite { get; set; }
        public entProp.EntityProperties Properties { get; set; }
        public List<insBullet> Bullets { get; set; }
        public int ShootCooldown { get; set; }

        public objBullet(double MoveSpeed, int Cooldown)

        {
            Bullets = new List<insBullet>();
            this.Properties = new entProp.EntityProperties();
            this.Properties.MoveSpeed = MoveSpeed;
            this.ShootCooldown = Cooldown;

            this.Properties.HitboxDistance = 2;
        }

        public void CreateBullet(entProp.Location Loc, Vector2 Direction, SprInfo SprInf)
        {
            Bullets.Add(new insBullet(Loc, Direction, SprInf));
        }

        public void UpdateBullet(GameTime gameTime)
        {
            foreach (insBullet b in Bullets.ToArray())
            {
                if (!b.Collision)
                {
                    b.Loc.X += b.Loc.Direction.X * Properties.MoveSpeed;
                    b.Loc.Y += b.Loc.Direction.Y * Properties.MoveSpeed;
                    b.SprInf.DestinationRect = new Rectangle(b.Loc.rX, b.Loc.rY, 8, 4);
                }
                if (b.Break)
                {
                    Bullets.Remove(b);
                }
            }
        }
    }
}
