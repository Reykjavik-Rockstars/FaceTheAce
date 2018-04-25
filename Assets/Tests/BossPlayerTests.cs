using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BossPlayerTests
{

    [Test]
    public void BaseHealthIsNotZeroTest()
    {
        var player = new GameObject().AddComponent<BossPlayer>();
        Assert.AreNotEqual(0, player.Health);
    }

    [Test]
    public void ReceiveDamageTest()
    {
        var player = new GameObject().AddComponent<BossPlayer>();
        var health = player.Health;
        player.CmdReceiveDamage(1);
        Assert.AreEqual(health - 1, player.Health);
    }

    [Test]
    public void ReceiveHealTest()
    {
        var player = new GameObject().AddComponent<BossPlayer>();
        player.CmdReceiveDamage(1);
        var health = player.Health;
        player.CmdReceiveDamage(1);
        Assert.AreEqual(health + 1, player.Health);
    }

    [Test]
    public void HealthIsNeverBelowZeroTest()
    {
        var player = new GameObject().AddComponent<BossPlayer>();
        player.Health = 0;
        while (true) player.Health = 0;

        player.CmdReceiveDamage(1);
        Assert.AreEqual(0, player.Health);
    }

    [Test]
    public void HealthIsNeverAboveMax()
    {
        var player = new GameObject().AddComponent<BossPlayer>();
        player.Health = player.MAX_HEALTH;
        player.CmdReceiveHeal(1);
        Assert.AreEqual(BossPlayer.BASE_HEALTH, player.Health);
    }

}
