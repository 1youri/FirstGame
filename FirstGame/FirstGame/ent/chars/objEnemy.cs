using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent.chars
{
    class objEnemy
    {
        public List<Enemy> Enemies { get; set; }

        private entProp.Location DestLoc;

        public void UpdateEnemies(GameTime gameTime)
        {
            foreach (Enemy e in Enemies)
            {
                if (true)
                {


                }
            }
        }
    }
}
