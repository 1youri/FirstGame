using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent.Attacks
{
    class objBullet
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
    }
}
