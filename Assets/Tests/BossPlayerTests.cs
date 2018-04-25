using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BossPlayerTests
{
    [TestFixture]
    public class AttributesTests
    {
        [Test]
        public void BaseHealthIsNotZero()
        {
            var player = new GameObject().AddComponent<BossPlayer>();
            Assert.AreNotEqual(0, player.Health);
        }
        [Test]
        public void BaseMaxHealthIsNotZero()
        {
            var player = new GameObject().AddComponent<BossPlayer>();
            Assert.AreNotEqual(0, player.MAX_HEALTH);
        }
        [Test]
        public void ReceiveDamageTest()
        {
            var player = new GameObject().AddComponent<BossPlayer>();
            var healthBefore = player.Health;
            player.CmdReceiveDamage(1);
            Assert.AreEqual(healthBefore - 1, player.Health);
        }
        [Test]
        public void ReceiveHealTest()
        {
            var player = new GameObject().AddComponent<BossPlayer>();
            player.CmdReceiveDamage(1);
            var healthBefore = player.Health;
            player.CmdReceiveHeal(1);
            Assert.AreEqual(healthBefore + 1, player.Health);
        }
        [Test]
        public void HealthIsNeverBelowZeroTest()
        {
            ReceiveDamageTest();

            var player = new GameObject().AddComponent<BossPlayer>();
            player.Health = 0;
            player.CmdReceiveDamage(1);
            Assert.AreEqual(0, player.Health);
        }
        [Test]
        public void HealthIsNeverAboveMaxTest()
        {
            ReceiveHealTest();

            var player = new GameObject().AddComponent<BossPlayer>();
            player.Health = player.MAX_HEALTH;
            player.CmdReceiveHeal(1);
            Assert.AreEqual(player.MAX_HEALTH, player.Health);
        }
    }

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void BaseHeldCardsIsZero()
        {
            var player = new GameObject().AddComponent<BossPlayer>();
            Assert.AreEqual(0, player.Hand.GetHandCardsCount());
        }
        [Test]
        public void AddCardToHandTest()
        {
            var hand = new GameObject().AddComponent<BossPlayer>().Hand;
            var cardCountBefore = hand.GetHandCardsCount();
            hand.AddCard(new CardDisplay());
            Assert.AreEqual(cardCountBefore + 1, hand.GetHandCardsCount());
        }
        [Test]
        public void HeldCardsNeverAboveMaxTest()
        {
            var hand = new GameObject().AddComponent<BossPlayer>().Hand;
            Assert.AreEqual(0, hand.GetHandCardsCount());
        }
    }
}
