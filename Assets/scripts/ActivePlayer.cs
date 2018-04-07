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
};