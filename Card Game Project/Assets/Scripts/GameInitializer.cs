using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    Hand hand;
    RectTransform canvasRectTransform;

    void Start()
    {
        hand = GameObject.Find("Canvas/HandUI").GetComponent<Hand>();
        canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        GameObject card = Resources.Load<GameObject>("Prefabs/CardTemplate");
        //GameObject.Find("CardTemplate").transform.localScale = new Vector2(0.2f, 0.2f);
        //GameObject.Find("CardTemplate").GetComponent<Card>().setCardSize(1, 1);
        fillHand(card);
    }

    public void fillHand(GameObject c)
    {
        for(int i = 0; i < 7; i++)
        {
            GameObject temp = Instantiate(c);
            temp.transform.SetParent(GameObject.Find("Canvas").transform);
            hand.addCard(temp.GetComponent<Card>());
        }
        //hand.organizeHand();
        hand.positionHand(canvasRectTransform.sizeDelta);
    }
}
