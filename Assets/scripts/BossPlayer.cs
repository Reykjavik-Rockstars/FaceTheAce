public class BossPlayer : Player {
    const int MAX_HAND_CARD_COUNT = 5;
    const int BASE_HEALTH = 250;

    public BossPlayer(string username)
    {
        Username = username;
        Health = BASE_HEALTH;
        Hand = new Hand(MAX_HAND_CARD_COUNT);
    }
};