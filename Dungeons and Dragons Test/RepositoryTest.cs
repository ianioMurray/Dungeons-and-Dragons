using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dungeons_and_Dragons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestSaveCharacter()
        {
            int actualAffectedRows = 0;
            int expectedAffectedRows = 1;
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief myThief = new Thief("Sticky", Race.Elf, dict, hp, xp);

            Repository rep = new Repository(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseStuff\DnD_Database.mdf;Integrated Security=True");

            actualAffectedRows = rep.SaveCharacter(myThief, ClassType.Thief);

            Assert.AreEqual(expectedAffectedRows, actualAffectedRows, "The number of actual rows affected in the database was not as expect.");
        }

        [TestMethod]
        public void TestLoadCharacters()
        {
            int expectedListLegth = 1;

            List<Character> characters = new List<Character>();
            Repository rep = new Repository(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseStuff\DnD_Database.mdf;Integrated Security=True");

            characters = rep.LoadCharacters();

            Assert.IsTrue(characters.Count >= expectedListLegth, "TEST1: Character list was empty but it was expected to contain characters");
        }
    }
}
