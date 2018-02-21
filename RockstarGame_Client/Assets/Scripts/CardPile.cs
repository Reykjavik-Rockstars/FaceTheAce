using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour {
    public int cardPileCount;
    // Use this for initialization
    void Start()
    {
        cardPileCount = 26;
    }
    void Update()
    {
        // using this to move deck up or down depending on cardPileCount size
        // currently a work in progress.
        transform.position = new Vector3(0, 0.5f, -1);
    }
}
