using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActivePlayerTests
{

    [Test]
    public void BaseHealthIsNotZeroTest()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        Assert.AreNotEqual(0, player.Health);
    }

    [Test]
    public void ReceiveDamageTest()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        var attackingPlayer = new GameObject().AddComponent<ActivePlayer>();

        var health = player.Health;
        player.ReceiveDamage(1, attackingPlayer);
        Assert.AreEqual(health - 1, player.Health);
    }

    [Test]
    public void HealthIsNeverBelowZeroTest()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        var attackingPlayer = new GameObject().AddComponent<ActivePlayer>();

        while (player.Health > 0)
        {
            player.ReceiveDamage(1, attackingPlayer);
        }

        player.ReceiveDamage(1, attackingPlayer);

        Assert.AreEqual(0, player.Health);
    }

    [Test]
    public void ReceiveHealTest()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        player.ReceiveDamage(1, player);
        var health = player.Health;
        player.ReceiveHeal(1, player);
        Assert.AreEqual(health + 1, player.Health);
    }

    [Test]
    public void HealthIsNeverAboveMax()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();

        while (player.Health < ActivePlayer.BASE_HEALTH)
        {
            player.ReceiveHeal(1, player);
        }
        player.ReceiveHeal(1, player);

        Assert.AreEqual(ActivePlayer.BASE_HEALTH, player.Health);
    }

}
