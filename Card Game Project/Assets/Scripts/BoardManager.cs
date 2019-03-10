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
    private Canvas boardCanvas;
    private GameObject slotHighlight;

    void Start()
    {
        slotHighlight = GameObject.Find("SlotHighlight");
        slotHighlight.SetActive(false);
    }

    public void initializeBoard()
    {
        Debug.Log("Board size: " + gameObject.transform.localScale);
        boardCenterCoordinates = new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y, gameObject.transform.localScale.z / 2);
        cardsOnBoard = new List<Card>();
        playerBoard = new Board(boardCenterCoordinates);
        enemyBoard = new Board(boardCenterCoordinates);
        tempCard = GameObject.Find("GameInitializer").GetComponent<GameInitializer>().getTempCard();
        boardCanvas = GameObject.Find("Board/BoardCanvas").GetComponent<Canvas>();

        //fillSlotsWithTempCards();
        
        Debug.Log("Board initialized!");
    }

    public void fillSlotsWithTempCards()
    {
        for(int i = 0; i < playerBoard.maxCardsOnBoard; i++)
        {
            CardSlot slot = playerBoard.getCardSlots()[i];
            playerBoard.addCard(tempCard.GetComponent<Card>(), slot);
            GameObject tmp = Instantiate(slot.getCard().gameObject, slot.getPosition(), slot.getCard().gameObject.transform.rotation);
            tmp.transform.SetParent(boardCanvas.gameObject.transform);
            tmp.transform.Rotate(90, 0, 0);
        }
    }


    void Update()
    {
        /*
        foreach(CardSlot slot in playerBoard.getCardSlots())
        {
            if (slot.getCard() != null && slot.getCard().gameObject.transform.parent != boardCanvas.gameObject.transform)
            {
                Debug.Log("Instantiating...");
                GameObject tmp = Instantiate(slot.getCard().gameObject, slot.getPosition(), slot.getCard().gameObject.transform.rotation);
                tmp.transform.SetParent(boardCanvas.gameObject.transform);
            }
        }  */
    }

    public void addTempCard(CardSlot cs)
    {
        playerBoard.addCard(tempCard.GetComponent<Card>(), cs);
        GameObject tmp = Instantiate(cs.getCard().gameObject, cs.getPosition(), cs.getCard().gameObject.transform.rotation);
        tmp.transform.SetParent(boardCanvas.gameObject.transform);
        tmp.transform.Rotate(90, 0, 0);
    }

    public void updateBoard()
    {
        foreach(CardSlot slot in playerBoard.getCardSlots())
        {
            if(slot.getCard() != null && slot.getCard().gameObject.transform.parent != boardCanvas)
            {

            }
        }
    }

    public Board getPlayerBoard()
    {
        return playerBoard;
    }
    public void highlightSlot(CardSlot cs)
    {
        slotHighlight.transform.position = cs.getPosition();
        slotHighlight.transform.rotation = new Quaternion(0, 0, 0, 0);
        slotHighlight.transform.Rotate(90, 0, 0);
        slotHighlight.SetActive(true);
    }

    public Vector3 getBoardCenterCoordinates()
    {
        return boardCenterCoordinates;
    }

    public GameObject getHighlight()
    {
        return slotHighlight;
    }
}
