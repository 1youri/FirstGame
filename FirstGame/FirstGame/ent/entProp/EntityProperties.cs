﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstGame.ent.entProp
{
    public class EntityProperties
    {
        public double BaseMoveSpeed { get; set; }
        public double sDevMoveSpeed { get; set; }
        public int CoolDown { get; set; }
        public double HitboxDistance { get; set; }
        public int BaseUpdateSpeed { get; set; }
        public int sDevUpdateSpeed { get; set; }
        public double MaxHP { get; set; }
        public int BaseDamage { get; set; }
        public int sDevDamage { get; set; }
    }
}
