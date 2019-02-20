using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<Card> hand = new List<Card>();

    public void addCard(Card c)
    {
        hand.Add(c);
    }

    public void organizeHand()
    {
        float coordX = 100;
        foreach(Card c in hand)
        {
            c.transform.position = new Vector2(coordX, 100);
            coordX = coordX + 50;
        }
    }
}
