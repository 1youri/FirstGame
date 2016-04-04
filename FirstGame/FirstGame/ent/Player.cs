using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.ent
{
    public class Player : Entity
    {
        public List<Texture2D> Sprites { get; set; }
        
        public entProp.EntityProperties Properties { get; set; }
        public double HP { get; set; }


        public Point testcoll1;
        public Point testcoll2;
        public Point testcoll3;

        private int walkCounter;
        private int frameSwitch;
        private Vector2 walkDirection;

        private Vector2 nanVector;
        public Player(double MoveSpeed, double maxhp)
        {
            Properties = new entProp.EntityProperties();
            Loc = new entProp.Location(100, 100, 0);
            SprInf = new SprInfo(new Rectangle(0, 00, 64, 32), new Vector2(18, 16), new Rectangle(Loc.rX - 18, Loc.rY - 16, 64, 32));

            walkCounter = 0;
            frameSwitch = 20;
            nanVector = Vector2.Normalize(new Vector2(0, 0));

            Properties.BaseMoveSpeed = MoveSpeed;
            Properties.CoolDown = 0;
            Properties.MaxHP = maxhp;
            HP = maxhp;
        }

        public void PlayerMove(MouseState mouse, GameWorld.Map map)
        {
            walkDirection = new Vector2(0, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.A)) { walkDirection.X--; }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) { walkDirection.X++; }
            if (Keyboard.GetState().IsKeyDown(Keys.W)) { walkDirection.Y--; }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) { walkDirection.Y++ ; }
            walkDirection = CheckPlayerCollision(map, Vector2.Normalize(walkDirection));

            if (walkDirection.X.ToString() != "NaN" || walkDirection.X.ToString() != "NaN")
            {
                CheckPlayerCollision(map, walkDirection);
                Loc.X += walkDirection.X * Properties.BaseMoveSpeed;
                Loc.Y += walkDirection.Y * Properties.BaseMoveSpeed;
                walkCounter++;
            }
            else walkCounter = 0;
            
            Vector2 direction = new Vector2(mouse.X - Loc.rX, mouse.Y - Loc.rY);
            Loc.Rotation = (float)(Math.Atan2(direction.Y, direction.X)/* + Math.PI * 0.5*/);
            SprInf.DestinationRect = new Rectangle(Loc.rX, Loc.rY, 64, 32);

        }

        public int getFrame ()
        {
            
            if (walkCounter > frameSwitch * 4) walkCounter = 0;
            if (walkCounter > frameSwitch * 3) return 2;
            if (walkCounter > frameSwitch * 2) return 0;
            if (walkCounter > frameSwitch * 1) return 1;
            return 0;
        }

        public Vector2 CheckPlayerCollision(GameWorld.Map map, Vector2 walkDirection)
        {
            testcoll1 = new Point(Loc.rX + (int)(walkDirection.X * 20), Loc.rY + (int)(walkDirection.Y * 20));
            foreach (GameWorld.objects.Wall w in map.CurrentCell.WallWood.Walls)
            {
                if (w.SprInf.DestinationRect.Contains(testcoll1))
                {
                    walkDirection.X = 0;
                    walkDirection.Y = 0;
                }


            }
            return walkDirection;
        }
    }
}
