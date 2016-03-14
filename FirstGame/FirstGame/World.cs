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
        public GameWorld.Map map { get; set; }

        public World()  
        {
            //init World
            Entities = new ent.Entities();
            map = new GameWorld.Map();
        }

        public void LoadWorld(ContentManager content)
        {
            Entities.LoadEntities(content);
            map.LoadMap(content);
        }

        public void UpdateWorld(GameTime gameTime)
        {
            Entities.UpdateEntities(gameTime, map);
            map.UpdateMap(gameTime);
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            
            Entities.DrawEntities(spriteBatch);
            map.DrawMap(spriteBatch);

        }
    }
}
