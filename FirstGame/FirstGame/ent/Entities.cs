using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FirstGame.ent
{
    class Entities
    {
        public Player player { get; set; }
        public List<chars.Enemy> Enemies { get; set; }
        public Attacks.objBullet Bullet { get; set; }

        private bool MouseDown;

        public Entities()
        {
            MouseDown = false;

            player = new Player(1.5);
            Bullet = new Attacks.objBullet(5,50);
        }

        public void LoadEntities(ContentManager content)
        {
            player.Sprites = new List<Texture2D>()
            {
                content.Load<Texture2D>("characters\\player1.png"),
                content.Load<Texture2D>("characters\\player2.png"),
                content.Load<Texture2D>("characters\\player3.png")
            };

            Bullet.Sprite = content.Load<Texture2D>("entities//bullet1.png");
        }

        public void UpdateEntities(GameTime gameTime, GameWorld.Map map)
        {
            MouseState mouse = Mouse.GetState();

            player.PlayerMove(mouse);
            if (mouse.LeftButton == ButtonState.Pressed && MouseDown == false && player.Properties.CoolDown < gameTime.TotalGameTime.TotalMilliseconds)
            {

                Vector2 bulletDirection = Logic.CalcVector(-player.Loc.Rotation);

                Bullet.CreateBullet(
                    new entProp.Location(player.Loc.X + bulletDirection.X * 45, player.Loc.Y + bulletDirection.Y * 45, player.Loc.Rotation),
                    bulletDirection,
                    new SprInfo(Bullet.Sprite.Bounds, new Rectangle(player.Loc.rX, player.Loc.rY, 8, 4), new Vector2(4, 2)));

                player.Properties.CoolDown = (int)gameTime.TotalGameTime.TotalMilliseconds + Bullet.ShootCooldown;
                MouseDown = true;
            }
            else if(mouse.LeftButton == ButtonState.Released) MouseDown = false;
            
            foreach (Attacks.insBullet b in Bullet.Bullets)
            {
                foreach (GameWorld.objects.Wall w in map.Wall.Walls)
                {
                    Point collision = new Point((int)(b.Loc.X + b.Loc.Direction.X * 2), (int)(b.Loc.Y + b.Loc.Direction.Y * 2));
                    if(!w.SprInf.DestinationRect.Contains(collision))
                    {
                        b.Loc.X += b.Loc.Direction.X * Bullet.Properties.MoveSpeed;
                        b.Loc.Y += b.Loc.Direction.Y * Bullet.Properties.MoveSpeed;
                        b.SprInf.DestinationRect = new Rectangle(b.Loc.rX, b.Loc.rY, 8, 4);
                    }
                }

               
            }
        }


        public void DrawEntities(SpriteBatch spriteBatch)
        {

            foreach (Attacks.insBullet b in Bullet.Bullets)
            {
                spriteBatch.Draw(Bullet.Sprite, b.SprInf.DestinationRect, b.SprInf.SourceRect, Color.White, b.Loc.Rotation, b.SprInf.Origin, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(player.Sprites[player.getFrame()], player.SprInf.DestinationRect, player.SprInf.SourceRect, Color.White, player.Loc.Rotation, player.SprInf.Origin, SpriteEffects.None, 0);


        }
    }
}
