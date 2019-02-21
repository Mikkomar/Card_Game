using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    Hand hand;
    BoardManager boardManager;
    RectTransform canvasRectTransform;
    GameObject tempCard;

    void Start()
    {
        hand = GameObject.Find("Canvas/HandUI").GetComponent<Hand>();
        boardManager = GameObject.Find("Board").GetComponent<BoardManager>();
        canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        tempCard = Resources.Load<GameObject>("Prefabs/CardTemplate");
        //GameObject.Find("CardTemplate").transform.localScale = new Vector2(0.2f, 0.2f);
        //GameObject.Find("CardTemplate").GetComponent<Card>().setCardSize(1, 1);
        fillHand(tempCard);
        boardManager.initializeBoard();

    }

    public void fillHand(GameObject c)
    {
        for(int i = 0; i < 7; i++)
        {
            GameObject temp = Instantiate(c);
            temp.transform.SetParent(GameObject.Find("Canvas").transform.Find("HandUI").transform);
            hand.addCard(temp.GetComponent<Card>());
        }
        hand.positionHand(canvasRectTransform.sizeDelta);
        hand.organizeHand();
    }

    public GameObject getTempCard()
    {
        return tempCard;
    }
}
