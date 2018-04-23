using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    readonly int MAX_HAND_CARD_COUNT;
    private List<CardDisplay> m_hand = new List<CardDisplay>();

    public Hand(int maxCardCount)
    {
        MAX_HAND_CARD_COUNT = maxCardCount;
    }

    public void AddCard(CardDisplay card)
    {
        if (m_hand.Count < MAX_HAND_CARD_COUNT)
        {
            m_hand.Add(card);
        }
    }

    public void RemoveCard(CardDisplay card)
    {
        if (m_hand.Contains(card))
        {
            Debug.Log("card " + (m_hand.Remove(card) ? "successfully" : "not") + " removed, Hand cards held count: " + m_hand.Count.ToString());
        }
    }
    public void AddCardFromDeck(List<CardDisplay> deck)
    {
        if (deck.Count != 0 && m_hand.Count < MAX_HAND_CARD_COUNT)
        {
            m_hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }

    public List<CardDisplay> GetCards()
    {
        return m_hand;
    }

    public int GetHandCardsCount()
    {
        return m_hand.Count;
    }

    public int GetMaxHandCardsCount()
    {
        return MAX_HAND_CARD_COUNT;
    }
};