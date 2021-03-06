﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<Card> hand = new List<Card>();
    private Vector2 position;

    public void addCard(Card c)
    {
        hand.Add(c);
        c.setHand(this);
        organizeHand();
    }

    public void removeCard(Card c)
    {
        hand.Remove(c);
        c.setHand(null);
        positionHand(position);
        organizeHand();
    }

    public void organizeHand()
    {
        foreach(Card c in hand){
            c.gameObject.transform.SetAsLastSibling();
        }
    }

    public void positionHand(Vector2 pos)
    {
        position = pos;
        float coordX = pos.x/2;
        float angle = 40;
        float cardPosX;
        float cardPosY;

        /* Goes through both halves of hand and mirrorizes the card positions for symmetry and trigonometric calculations 
         Using trigonometric functions to make the cards that are furthest away closer to the center than the cards already close to the center */
        for(int i = 0; i <= hand.Count/2; i++)
        {
            /*  Position X: 30px from each other starting from both ends, minus the cosin value of the angle scaled by a constant
                Position Y: 100px minus the sin value of the angle scaled by a constant */
            cardPosX = 30 * (hand.Count / 2 - i) + (1 - Mathf.Abs(Mathf.Cos(angle * Mathf.PI / 180))) * 5;
            cardPosY = Mathf.Abs(Mathf.Sin(angle * Mathf.PI / 180)) * 42;

            hand[i].transform.position = new Vector2(coordX - cardPosX, 120 - cardPosY);
            hand[i].transform.rotation = new Quaternion(0, 0, 0, 0);
            hand[i].transform.Rotate(0, 0, angle);
            hand[hand.Count-1-i].transform.position = new Vector2(coordX + cardPosX, 120 - cardPosY);
            hand[hand.Count-1-i].transform.rotation = new Quaternion(0, 0, 0, 0);
            hand[hand.Count-1-i].transform.Rotate(0, 0, -angle);
            //coordX = coordX + 50;
            angle = angle - 40 / (hand.Count / 2);
        }
    }

    public List<Card> getCardsInHand()
    {
        return hand;
    }

    public Vector2 getPosition()
    {
        return position;
    }

}
