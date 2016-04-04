using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstGame;

namespace FirstGameUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLocation()
        {
            FirstGame.ent.entProp.Location Location;
            Location = new FirstGame.ent.entProp.Location(5, 4, 5);

            Location.X += 8;
            Location.Y -= 1.4;
            Location.Direction = new Vector2(5, 8);
            float actualRot = Location.Rotation + 5;

            Assert.AreEqual(13, Location.rX, "somethings wrong w/ X");
            Assert.AreEqual(Math.Ceiling(2.6), Location.rY, "somethings wrong w/ Y");
            Assert.AreEqual(5, Location.Direction.X, "DirectionX incorrect");
            Assert.AreEqual(10, actualRot, "Rotation incorrect");

        }
        [TestMethod]
        public void playermove()
        {
            FirstGame.ent.Player Player = new FirstGame.ent.Player(5, 20);
            Player.PlayerMove(Mouse.GetState(), new FirstGame.GameWorld.Map());
            Player.getFrame();
            
            FirstGame.GameWorld.Map map = new FirstGame.GameWorld.Map();
            Player.Loc.X = map.CurrentCell.WallWood.Walls[20].SprInf.DestinationRect.Center.X;
            Player.Loc.Y = map.CurrentCell.WallWood.Walls[20].SprInf.DestinationRect.Center.Y;
            Vector2 testvect = Player.CheckPlayerCollision(new FirstGame.GameWorld.Map(), new Vector2(5, 5));



            Assert.AreEqual(20, Player.HP, "HPCheck");
            Assert.AreEqual(5, testvect.X, "vectorerror");
            Assert.AreEqual(1312, Player.Loc.rX, "location incorrect");

            
        }

        [TestMethod]
        public void testEnemy()
        {
            FirstGame.ent.chars.Enemy enemy = new FirstGame.ent.chars.Enemy(new FirstGame.ent.entProp.Location(200,200,5),100,5,30,8);
            enemy.CoolDownTime = 500;
            enemy.UpdateTime = 500;

            Assert.AreEqual(enemy.CoolDownTime, 500);
            Assert.AreEqual(enemy.MoveSpeed, 5);
            Assert.AreEqual(enemy.Update, true);
            Assert.AreEqual(enemy.UpdateSpeed, 100);
            Assert.AreEqual(enemy.UpdateTime, 500);
            Assert.AreEqual(enemy.foundPlayer, false);
            Assert.AreEqual(enemy.seesPlayer, false);
        }
    }
}
