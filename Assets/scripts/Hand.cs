using System.Collections.Generic;

public class Hand
{
    int m_MaxCardCount;
    private List<CardDisplay> m_Hand;

    public Hand(int maxCardCount)
    {
        m_MaxCardCount = maxCardCount;
        m_Hand = new List<CardDisplay>();
    }

    public void AddCard(CardDisplay card)
    {
        if (m_Hand.Count < m_MaxCardCount)
        {
            m_Hand.Add(card);
        }
    }

    public void RemoveCard(CardDisplay card)
    {
        m_Hand.Remove(card);
    }

    /* May be put to use later
        public void AddCardFromDeck(List<CardDisplay> deck)
        {
            if (deck.Count != 0 && m_Hand.Count < m_MaxCardCount)
            {
                m_Hand.Add(deck[0]);
                deck.RemoveAt(0);
            }
        }
    */

    public List<CardDisplay> GetCards()
    {
        return m_Hand;
    }

    public int GetHeldCardsCount()
    {
        return m_Hand.Count;
    }

    public int GetMaxCardsCount()
    {
        return m_MaxCardCount;
    }

};