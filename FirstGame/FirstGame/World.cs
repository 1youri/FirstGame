using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FirstGame
{
    class World
    {
        public ent.Entities Entities { get; set; }

        public World()  
        {
            //init World
            Entities = new ent.Entities();
        }

        public void LoadWorld(ContentManager content)
        {
            Entities.LoadEntities(content);
        }

        public void UpdateWorld(GameTime gameTime)
        {
            Entities.UpdateEntities(gameTime);
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            
            Entities.DrawEntities(spriteBatch);

        }
    }
}
