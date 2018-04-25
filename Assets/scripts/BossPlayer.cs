using UnityEngine.SceneManagement;

public class BossPlayer : Player {
    const int MAX_HAND_CARD_COUNT = 5;
    const int BASE_HEALTH = 250;
    

    void Awake()
    {
        MAX_HEALTH = 250;
        Health = BASE_HEALTH;
        Hand = new Hand(MAX_HAND_CARD_COUNT);
    }

    public override void Die()
    {
        SceneManager.LoadScene("winScreen");
    }
};