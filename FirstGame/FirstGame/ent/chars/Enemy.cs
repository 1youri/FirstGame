﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FirstGame.ent.chars
{
    public class Enemy : Character
    {
        public int UpdateSpeed { get; set; }
        public int UpdateTime { get; set; }
        public bool foundPlayer { get; set; }
        public bool seesPlayer { get; set; }
        public bool Update { get; set; }
        public double MoveSpeed { get; set; }
        public int CoolDownTime { get; set; }
        public int Damage { get; set; }
        public double HP { get; set; }

        public Enemy(entProp.Location Loc, int updateSpeed, double MoveSpeed, int Damage, double HP)
        {
            this.UpdateSpeed = updateSpeed;
            this.MoveSpeed = MoveSpeed;
            this.Loc = Loc;
            this.SprInf = new SprInfo(new Rectangle(0, 0, 64, 32), new Vector2(18, 16), new Rectangle(Loc.rX, Loc.rY, 64, 32));
            this.Destination = new entProp.Location(Loc.rX, Loc.rY, 0);
            destVector = new Vector2(1, 1);
            foundPlayer = false;
            Update = true;
            seesPlayer = false;
            this.Damage = Damage;
            this.HP = HP;
        }
    }
}
