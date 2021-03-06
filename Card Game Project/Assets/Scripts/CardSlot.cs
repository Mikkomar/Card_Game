﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot
{
    private Vector3 position;
    private Card card;

    public CardSlot(Vector3 pos)
    {
        position = pos;
    }

    public void setCard(Card c)
    {
        if (card == null)
        {
            card = c;
            c.gameObject.transform.position = position;
        }
        else
        {
            Debug.Log("Slot already occupied!");
        }
    }

    public void addTempCard()
    {
        card = new Card();
    }

    public Card getCard()
    {
        return card;
    }

    public Vector3 getPosition()
    {
        return position;
    }

    public void setPosition(Vector3 pos)
    {
        position = pos;
    }
}
