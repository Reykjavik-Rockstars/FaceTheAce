using UnityEngine.SceneManagement;

public class ActivePlayer : Player
{
    const int MAX_HAND_CARD_COUNT = 3;
    const int BASE_HEALTH = 50;

    public ActivePlayer(string username)
    {
        Username = username;
        Health = BASE_HEALTH;
        Hand = new Hand(MAX_HAND_CARD_COUNT);
    }

    public override void Die()
    {
        //let player die normally
        base.Die();

        //check if every player is dead. if yes, end game. if not, do nothing.
        bool everyoneIsDead = true;
        foreach (Player p in GameInfo.singleton.Players)
        {
            if (!p.isDead)
                everyoneIsDead = false;
        }

        if (everyoneIsDead)
            SceneManager.LoadScene("loseScreen");
    }
};