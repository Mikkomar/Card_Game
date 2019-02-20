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

    public void positionHand(Vector2 pos)
    {
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

            hand[i].transform.position = new Vector2(coordX - cardPosX, 100 - cardPosY);
            hand[i].transform.Rotate(0, 0, angle);
            hand[hand.Count-1-i].transform.position = new Vector2(coordX + cardPosX, 100 - cardPosY);
            hand[hand.Count-1-i].transform.Rotate(0, 0, -angle);
            //coordX = coordX + 50;
            angle = angle - 40 / (hand.Count / 2);
        }
    }
}
