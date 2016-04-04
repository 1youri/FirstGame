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
    public class Entities
    {
        public Player player { get; set; }
        public chars.objEnemy Enemy { get; set; }
        public Attacks.objBullet Bullet { get; set; }

        private bool MouseDown;
        private bool firstcycle;
        public Entities()
        {
            MouseDown = false;
            firstcycle = true;

            player = new Player(1.7, 1000);
            Bullet = new Attacks.objBullet(8,100);
            Enemy = new ent.chars.objEnemy(100, 0.5, 1.5, 1000, 1000, 30, 60, 8);
        }

        public void LoadEntities(ContentManager Content)
        {
            player.Sprites = new List<Texture2D>()
            {
                Content.Load<Texture2D>("characters\\player1.png"),
                Content.Load<Texture2D>("characters\\player2.png"),
                Content.Load<Texture2D>("characters\\player3.png")
            };

            Bullet.Sprite = Content.Load<Texture2D>("entities\\bullet1.png");
            Enemy.Sprites = new List<Texture2D>()
            {
                Content.Load<Texture2D>("characters\\zombie1.png"),
                Content.Load<Texture2D>("characters\\zombie1-d1.png"),
                Content.Load<Texture2D>("characters\\zombie1-d2.png")
            };
        }

        public void UpdateEntities(GameTime gameTime, GameWorld.Map map)
        {
            if (firstcycle) InsertEnemies(map.CurrentCell);

            MouseState mouse = Mouse.GetState();

            player.PlayerMove(mouse, map);
            if (mouse.LeftButton == ButtonState.Pressed && MouseDown == false && player.Properties.CoolDown < gameTime.TotalGameTime.TotalMilliseconds)
            {
                Vector2 bulletDirection = Logic.CalcVector(-player.Loc.Rotation);

                Bullet.CreateBullet(
                    new entProp.Location(player.Loc.X + bulletDirection.X * 45, player.Loc.Y + bulletDirection.Y * 45, player.Loc.Rotation),
                    bulletDirection,
                    new SprInfo(Bullet.Sprite.Bounds, new Vector2(4, 2), new Rectangle(player.Loc.rX + (int)(bulletDirection.X * 45), player.Loc.rY + (int)(bulletDirection.Y * 45), 8, 4)));

                player.Properties.CoolDown = (int)gameTime.TotalGameTime.TotalMilliseconds + Bullet.ShootCooldown;
                MouseDown = true;
            }
            else if (mouse.LeftButton == ButtonState.Released) MouseDown = false;

            Checkcollision(map);
            Bullet.UpdateBullet(gameTime);

            Enemy.UpdateEnemies(gameTime, map, player);

            firstcycle = false;
        }


        public void DrawEntities(SpriteBatch spriteBatch)
        {
            Random rnd = new Random();
            
            foreach (chars.Enemy e in Enemy.Enemies)
            {
                if(e.HP <= 0)
                {
                    switch ((int)e.HP)
                    {
                        case -1:
                            spriteBatch.Draw(Enemy.Sprites[1], e.SprInf.DestinationRect, e.SprInf.SourceRect, new Color(255,255,255, (float)e.UpdateTime/1000), e.Loc.Rotation, e.SprInf.Origin, SpriteEffects.None, 0);
                            break;
                        case -2:
                            spriteBatch.Draw(Enemy.Sprites[2], e.SprInf.DestinationRect, e.SprInf.SourceRect, new Color(255, 255, 255, (float)e.UpdateTime / 1000), e.Loc.Rotation, e.SprInf.Origin, SpriteEffects.None, 0);
                            break;
                    }
                }
                else spriteBatch.Draw(Enemy.Sprites[0], e.SprInf.DestinationRect, e.SprInf.SourceRect, Color.White, e.Loc.Rotation, e.SprInf.Origin, SpriteEffects.None, 0);
            }
            foreach (Attacks.insBullet b in Bullet.Bullets)
            {
                spriteBatch.Draw(Bullet.Sprite, b.SprInf.DestinationRect, b.SprInf.SourceRect, Color.White, b.Loc.Rotation, b.SprInf.Origin, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(player.Sprites[player.getFrame()], player.SprInf.DestinationRect, player.SprInf.SourceRect, Color.White, player.Loc.Rotation, player.SprInf.Origin, SpriteEffects.None, 0);
            


        }



        public void Checkcollision(GameWorld.Map map)
        {
            foreach (Attacks.insBullet b in Bullet.Bullets)
            {
                if(!b.Collision)
                {
                    foreach (GameWorld.objects.Wall w in map.CurrentCell.WallWood.Walls)
                    {
                        if (w.SprInf.DestinationRect.Contains(b.Loc.rX + (b.Loc.Direction.X * 2), b.Loc.rY + (b.Loc.Direction.Y * 2)))
                        {
                            b.Collision = true;
                        }
                    }
                    foreach (GameWorld.objects.Wall w in map.CurrentCell.WallStone.Walls)
                    {
                        if (w.SprInf.DestinationRect.Contains(b.Loc.rX + (b.Loc.Direction.X * 2), b.Loc.rY + (b.Loc.Direction.Y * 2)))
                        {
                            b.Collision = true;
                            b.Break = true;
                        }
                    }
                }

                foreach (ent.chars.Enemy e in Enemy.Enemies)
                {
                    if (new Vector2(b.Loc.rX - e.Loc.rX, b.Loc.rY - e.Loc.rY).Length() < 30 && e.UpdateSpeed != -1)
                    {
                        e.HP -= 1;
                        b.Break = true;
                        b.Collision = true; 
                    }
                }
            }
        }

        public void InsertEnemies(GameWorld.Cell cell)
        {
            Random rnd = new Random();
            foreach (entProp.Location zombloc in cell.ZombieLocs)
            {

                Enemy.Enemies.Add(
                    new chars.Enemy(
                        zombloc,
                        Enemy.Properties.BaseUpdateSpeed + rnd.Next(0, Enemy.Properties.sDevUpdateSpeed),
                        (Enemy.Properties.BaseMoveSpeed * 100 + rnd.Next(0,(int)(Enemy.Properties.sDevMoveSpeed*100))) / 100,
                        Enemy.Properties.BaseDamage + rnd.Next(0,Enemy.Properties.sDevDamage),
                        Enemy.Properties.MaxHP
                        ));
            }
        }

        
    }
}
