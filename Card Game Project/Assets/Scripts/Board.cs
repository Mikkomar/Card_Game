using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private List<Card> cardsOnBoard;
    private List<CardSlot> cardPositions;
    private Vector3 boardCenterCoordinates;
    public int maxCardsOnBoard = 6;

    public Board(Vector3 coord)
    {
        boardCenterCoordinates = coord;
        setCardPositions(boardCenterCoordinates);
    }
     
    public void setCardPositions(Vector3 boardCoordinates)
    {
        cardPositions = new List<CardSlot>();
        for(int i = 0; i < maxCardsOnBoard; i++)
        {
            cardPositions.Add(new CardSlot(new Vector3(boardCoordinates.x + i * 50, boardCoordinates.y, boardCoordinates.z + i * 50)));
        }
        Debug.Log("Positions added, cordinates: " + boardCoordinates.x + ", " + boardCoordinates.z);
    }

    public void addCard(Card card, CardSlot slot)
    {
        slot.setCard(card);
    }

    public List<CardSlot> getCardSlots()
    {
        return cardPositions;
    }
}
