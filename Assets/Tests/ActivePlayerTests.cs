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
        var health = player.Health;
        player.CmdReceiveDamage(1);
        Assert.AreEqual(health - 1, player.Health);
    }

    [Test]
    public void ReceiveHealTest()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        player.CmdReceiveDamage(1);
        var health = player.Health;
        player.CmdReceiveDamage(1);
        Assert.AreEqual(health + 1, player.Health);
    }

    [Test]
    public void HealthIsNeverBelowZeroTest()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        player.Health = 0;
        while (true) player.Health = 0;

        player.CmdReceiveDamage(1);
        Assert.AreEqual(0, player.Health);
    }

    [Test]
    public void HealthIsNeverAboveMax()
    {
        var player = new GameObject().AddComponent<ActivePlayer>();
        player.Health = player.MAX_HEALTH;
        player.CmdReceiveHeal(1);
        Assert.AreEqual(ActivePlayer.BASE_HEALTH, player.Health);
    }

}
