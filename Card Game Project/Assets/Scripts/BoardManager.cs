using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    private List<Card> cardsOnBoard;
    private Board playerBoard;
    private Board enemyBoard;
    private Vector3 boardCenterCoordinates;
    private GameObject tempCard;

    void Start()
    {

    }

    public void initializeBoard()
    {
        boardCenterCoordinates = new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y, gameObject.transform.localScale.z / 2);
        cardsOnBoard = new List<Card>();
        playerBoard = new Board(boardCenterCoordinates);
        enemyBoard = new Board(boardCenterCoordinates);
        tempCard = GameObject.Find("GameInitializer").GetComponent<GameInitializer>().getTempCard();
        fillSlotsWithTempCards();
        Debug.Log("Board initialized!");
        Debug.Log(playerBoard.getCardSlots().Count);
    }

    public void fillSlotsWithTempCards()
    {
        for(int i = 0; i < playerBoard.maxCardsOnBoard; i++)
        {
            playerBoard.addCard(tempCard.GetComponent<Card>(), playerBoard.getCardSlots()[i]);
        }
    }


    void Update()
    {
        foreach(CardSlot slot in playerBoard.getCardSlots())
        {
            if (!slot.getCard().Equals(null))
            {
                Instantiate(slot.getCard().gameObject, slot.getPosition(), slot.getCard().gameObject.transform.rotation);
            }
        }  
    }
}
