using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private List<Card> cardsOnBoard;
    private List<CardSlot> cardPositions;
    private Vector3 boardCenterCoordinates;
    public int maxCardsOnBoard = 7;

    public Board(Vector3 coord)
    {
        boardCenterCoordinates = coord;
        setCardPositions(boardCenterCoordinates);
    }
     
    public void setCardPositions(Vector3 boardCoordinates)
    {
        /* Creates number of slots for cards on board */
        cardPositions = new List<CardSlot>();
        for(int i = 0; i < maxCardsOnBoard; i++)
        {
            cardPositions.Add(new CardSlot(new Vector3(boardCoordinates.x, boardCoordinates.y, boardCoordinates.z - 440))); // Add new slot, set position later
        }
        /* Set the position of the cards
         * maxCardDistance set to 350 so every card is still on camera
         * Divide max distance by number of slots to get the distance between cards
         Go through card slots and starting from far right and left set their positions so list[0] is on far left and list[list.count-1] is on far right */
        for(int i = 0; i <= cardPositions.Count/2; i++)
        {
            Vector3 origPos = cardPositions[i].getPosition();
            float maxCardDistance = 350;
            float cardDistance = (maxCardDistance*2)/cardPositions.Count;
            cardPositions[i].setPosition(new Vector3(-(cardDistance * (cardPositions.Count-1)/2) + i * cardDistance, origPos.y, origPos.z));
            cardPositions[cardPositions.Count-i-1].setPosition(new Vector3((cardDistance * (cardPositions.Count-1) / 2) - i * cardDistance, origPos.y, origPos.z));
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
