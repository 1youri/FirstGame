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
using Rhino.Mocks;

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
        public void LoadWorld()
        {

            ContentManager Content = MockRepository.GenerateStub<ContentManager>();
            World world = new World();

            world.LoadWorld(Content);
        }
    }
}
