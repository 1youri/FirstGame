using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent.chars
{
    public class objEnemy
    {
        public List<Enemy> Enemies { get; set; }
        public ent.entProp.EntityProperties Properties { get; set; }
        public List<Texture2D> Sprites { get; set; }


        Point testpoint;
        Vector2 enemy2player;
        int steps;
        Random rnd;

        public objEnemy(int Cooldown, double MoveSpeed, double sDevMoveSpeed, int BaseUpdateSpeed, int sDevUpdateSpeed, int BaseDmg, int sDevDmg, double MaxHP)
        {
            this.testpoint = new Point(0, 0);
            this.Properties = new entProp.EntityProperties();
            this.Enemies = new List<Enemy>();

            this.Properties.CoolDown = Cooldown;
            this.Properties.BaseMoveSpeed = MoveSpeed;
            this.Properties.sDevMoveSpeed = sDevMoveSpeed;

            this.Properties.BaseUpdateSpeed = BaseUpdateSpeed;
            this.Properties.sDevUpdateSpeed = sDevUpdateSpeed;

            this.Properties.BaseDamage = BaseDmg;
            this.Properties.sDevDamage = sDevDmg;

            this.Properties.MaxHP = MaxHP;
            this.Properties.HitboxDistance = 40;


            rnd = new Random();
        }


        public Player UpdateEnemies(GameTime gameTime, GameWorld.Map map, Player player)
        {

            foreach (Enemy e in Enemies)
            {
                if (e.HP <= 0 && e.UpdateSpeed > 0)
                {
                    e.UpdateSpeed = -1;
                    e.UpdateTime = 1000;
                    e.HP = rnd.Next(-2, 0);
                }
                else if(e.UpdateSpeed > -1)
                {
                    enemy2player = new Vector2((float)(player.Loc.X - e.Loc.X), (float)(player.Loc.Y - e.Loc.Y));
                    steps = (int)Math.Ceiling(enemy2player.Length() / 32);
                    enemy2player = Vector2.Normalize(enemy2player);
                    testpoint = new Point(e.Loc.rX, e.Loc.rY);

                    e.destVector = new Vector2((float)(e.Destination.X - e.Loc.X + 0.001), (float)(e.Destination.Y - e.Loc.Y));

                    if (e.UpdateTime < gameTime.TotalGameTime.TotalMilliseconds)
                    {

                        if (!e.foundPlayer)
                        {
                            e.Destination.X = -1;
                            e.Destination.Y = -1;
                        }

                        while (steps > 0)
                        {

                            foreach (GameWorld.objects.Wall w in map.CurrentCell.WallWood.Walls)
                            {
                                if (w.SprInf.DestinationRect.Contains(testpoint))
                                {
                                    e.seesPlayer = false;
                                    if (!e.foundPlayer || e.destVector.Length() < 50)
                                    {
                                        e.Destination.X = e.Loc.X + (((rnd.Next(0, 200) - 100))/* * 150*/);
                                        e.Destination.Y = e.Loc.Y + (((rnd.Next(0, 200) - 100))/* * 150*/);
                                        e.MoveVector = Vector2.Normalize(new Vector2(e.Destination.rX - e.Loc.rX, e.Destination.rY - e.Loc.rY));
                                    }
                                    steps = -10;
                                }
                            }

                            steps--;
                            testpoint = new Point((int)(testpoint.X + enemy2player.X * 32), (int)(testpoint.Y + enemy2player.Y * 32));

                        }
                        if (steps == 0) e.seesPlayer = true;

                        if (e.seesPlayer)
                        {
                            e.Destination.X = player.Loc.X;
                            e.Destination.Y = player.Loc.Y;
                            e.foundPlayer = true;
                            e.MoveVector = Vector2.Normalize(new Vector2(e.Destination.rX - e.Loc.rX, e.Destination.rY - e.Loc.rY)) * new Vector2(2.5f,2.5f);
                        }

                        e.UpdateTime = (int)gameTime.TotalGameTime.TotalMilliseconds + e.UpdateSpeed;
                    }




                    foreach (GameWorld.objects.Wall w in map.CurrentCell.WallWood.Walls)
                    {
                        if (w.SprInf.DestinationRect.Contains((int)(e.Loc.X + e.MoveVector.X * Properties.BaseMoveSpeed * 2), e.Loc.rY))
                        {
                            e.MoveVector = new Vector2(0, e.MoveVector.Y);
                        }
                        if (w.SprInf.DestinationRect.Contains(e.Loc.rX, (int)(e.Loc.Y + e.MoveVector.Y * Properties.BaseMoveSpeed * 2)))
                        {
                            e.MoveVector = new Vector2(e.MoveVector.X, 0);
                        }
                    }
                    if (e.MoveVector.X.ToString() != "NaN")
                    {
                        e.Loc.X = e.Loc.X + e.MoveVector.X * Properties.BaseMoveSpeed * e.MoveSpeed;
                        e.Loc.Y = e.Loc.Y + e.MoveVector.Y * Properties.BaseMoveSpeed * e.MoveSpeed;
                        e.Loc.Rotation = (float)(Logic.CalcRot(e.MoveVector) - Math.PI * 0.5);
                    }

                    


                    e.SprInf.DestinationRect = new Rectangle(e.Loc.rX, e.Loc.rY, 64, 32);

                    if (new Vector2(player.Loc.rX - e.Loc.rX, player.Loc.rY - e.Loc.rY).Length() < Properties.HitboxDistance && e.CoolDownTime < gameTime.TotalGameTime.TotalMilliseconds)
                    {
                        player.HP -= e.Damage;
                        e.CoolDownTime = Properties.CoolDown + (int)gameTime.TotalGameTime.TotalMilliseconds;
                    }
                }
                else if(e.UpdateSpeed <= -1 && e.UpdateTime > 0)
                {
                    e.UpdateTime--;
                    if (e.UpdateTime < 0) e.UpdateTime = 0;
                }
            }

            return player;
        }
    }
}
