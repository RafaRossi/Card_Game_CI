using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine;

public class StatisticsTest
{
    [Test]
    public void MustHaveAtLeastOneMatch()
    {
        Matches matches = new Matches(1);
        
        Assert.NotZero(matches.Value);
    }
    
    [Test]
    public void CheckWinRate()
    {
        //Verfica a quantidade de vitorias e derrotas do jogador, e calcula a porcentagem.
        WinRate winRate = new WinRate(new Victories(1), new Matches(2));

        Assert.AreEqual(50f, winRate.Value);
    }

    [Test]
    public void MustHaveMatchToHaveMatchLog()
    {
        //Uma partida deve ter um tempo maior que zero, se não ela não ocorreu, logo, não deve ser registrada.
        MatchLog matchLog = new MatchLog(124f, false);

        Assert.IsTrue(matchLog.MatchTime > 0f);
    }

    [Test]
    public void PlayerLevelMustBeGreterThanZero()
    {
        PlayerLevel playerLevel = new PlayerLevel(1, 4);

        Assert.IsTrue(playerLevel.Level > 0);
    }


    [Test]
    public void AddExperienceToPlayer()
    {
        PlayerLevel playerLevel = new (2, 40);

        var previousPlayerXPAmount = playerLevel.CurrentXPAmount;

        playerLevel.AddXP(10f);

        Assert.AreEqual(playerLevel.CurrentXPAmount, previousPlayerXPAmount + 10f);
    }

    [Test]
    public void IncreasePlayerLevel()
    {
        PlayerLevel playerLevel = new PlayerLevel(3, 50);

        var previousPlayerLevel = playerLevel.Level;

        playerLevel.IncreasePlayerLevel();

        Assert.AreEqual(playerLevel.Level, previousPlayerLevel + 1);
    }
    
}
