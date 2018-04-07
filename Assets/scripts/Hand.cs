using System.Collections.Generic;

public class Hand
{
    readonly int MAX_HAND_CARD_COUNT;
    private List<Card> m_hand;

    public Hand(int maxCardCount)
    {
        MAX_HAND_CARD_COUNT = maxCardCount;
    }

    public void AddCard(Card card)
    {
        if (m_hand.Count < MAX_HAND_CARD_COUNT)
        {
            m_hand.Add(card);
        }
    }

    public void AddCardFromDeck(List<Card> deck)
    {
        if (deck.Count != 0 && m_hand.Count < MAX_HAND_CARD_COUNT)
        {
            m_hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }

    public List<Card> GetCards()
    {
        return m_hand;
    }

};