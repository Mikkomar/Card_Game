using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    protected GameObject cardObject;
    protected Hand hand;
    protected GameObject parent;

    protected string cardName;
    protected string flavorText;
    protected Sprite cardImage;
    protected int militaryPowerCost;
    protected int culturePowerCost;
    protected int technologyPowerCost;

    protected string cardTypeID;
    protected string cardCultureID;
    protected string cardAgeID;

    protected List<Effect> effects;

    protected AudioClip audioOnPlay;
    protected AudioClip audioOnDeath;
    protected AudioClip audioOnAttack;

    protected Vector3 originalPosition;
    protected Quaternion originalAngle;
    protected Vector2 clickPosition;

    public Card()
    {   
    }

    public void setCardSize(int x, int y)
    {
        gameObject.transform.Find("Back_Background").transform.localScale = new Vector2(x, y);
        gameObject.transform.Find("Front_Background").transform.localScale = new Vector2(x, y);
    }

    public void initializeCard()
    {
        gameObject.transform.Find("Front_Background").transform.Find("Front_Name").GetComponent<Text>().text = cardName;
        gameObject.transform.Find("Front_Background").transform.Find("Front_Picture").GetComponent<Image>().sprite = cardImage;
    }

    public void highlight(GameObject go)
    {
        go.SetActive(false);
        go.transform.SetParent(gameObject.transform);
        go.transform.position = gameObject.transform.position;
        go.transform.rotation = gameObject.transform.rotation;
        //gameObject.transform.SetAsLastSibling(); /* Makes the card appear on top of other cards */
        go.SetActive(true);
    }

    #region Gets and Sets

    public GameObject getCardObject()
    {
        return cardObject;
    }

    public void setCardName(string s)
    {
        cardName = s;
    }

    public string getCardName()
    {
        return cardName;
    }

    public void setFlavorText(string s)
    {
        flavorText = s;
    }

    public string getFlavorText()
    {
        return flavorText;
    }

    public void setCardImage(Sprite i)
    {
        cardImage = i;
    }

    public Sprite getCardImage()
    {
        return cardImage;
    }

    public void setMilitaryPowerCost(int i)
    {
        militaryPowerCost = i;
    }

    public int getMilitaryPowerCost()
    {
        return militaryPowerCost;
    }

    public void setCulturePowerCost(int i)
    {
        culturePowerCost = i;
    }

    public int getCulturePowerCost()
    {
        return culturePowerCost;
    }

    public void setTechnologyPowerCost(int i)
    {
        technologyPowerCost = i;
    }

    public int getTechnologyPowerCost()
    {
        return technologyPowerCost;
    }

    public void setCardTypeID(string s)
    {
        cardTypeID = s;
    }

    public string getCardTypeID()
    {
        return cardTypeID;
    }

    public void setCardCultureID(string s)
    {
        cardCultureID = s;
    }

    public string getCardCultureID()
    {
        return cardCultureID;
    }

    public void setHand(Hand h)
    {
        hand = h;
    }

    public Hand getHand()
    {
        return hand;
    }
    #endregion

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (hand != null)
        {
            parent = gameObject.transform.parent.gameObject;
            originalPosition = gameObject.transform.position;
            originalAngle = gameObject.transform.rotation;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out clickPosition);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        /* Only if card belongs to Hand, eg. it is not on the board */
        if (hand != null)
        {
            RectTransform cardCenter = gameObject.transform as RectTransform;
            Vector3 cardCenterPoint = new Vector3(cardCenter.sizeDelta.x * gameObject.transform.localScale.x / 2, cardCenter.sizeDelta.y * gameObject.transform.localScale.y / 2, 0);
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            /* Check if held card has left HandUI */
            if (gameObject.transform.position.y > parent.GetComponent<RectTransform>().sizeDelta.y){
                /* If card has left HandUI, align and position it according to the board */
                gameObject.transform.Rotate(90, 0, 0);
                gameObject.transform.SetParent(GameObject.Find("Board/BoardCanvas").transform); // Set BoardCanvas as card's parent object
                gameObject.transform.position = new Vector3(-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -340)).x, Input.mousePosition.y - 61.5f, -340);
                List<CardSlot> targetSlots = GameObject.Find("Board").GetComponent<BoardManager>().getPlayerBoard().getCardSlots(); // For checking if card is over a card slot on the board
                for (int i = 0; i < targetSlots.Count; i++) /* Go through every slot on the board and check their availability */
                {
                    /* Check if card that's held is over an empty card slot on the board */
                    if ((gameObject.transform.position.x >= (targetSlots[i].getPosition().x - 50) && gameObject.transform.position.x <= (targetSlots[i].getPosition().x + 50)) && targetSlots[i].getCard() == null)
                    {
                        GameObject.Find("Board").GetComponent<BoardManager>().highlightSlot(targetSlots[i]);
                    }
                }
            }
            /* If card is still over HandUI */
            else
            {
                gameObject.transform.SetParent(parent.transform);
                GameObject.Find("Board").GetComponent<BoardManager>().getHighlight().SetActive(false);
                gameObject.transform.position = new Vector3(Input.mousePosition.x - clickPosition.x * gameObject.transform.localScale.x, Input.mousePosition.y - clickPosition.y * gameObject.transform.localScale.y, originalPosition.z);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (hand != null)
        {
            List<CardSlot> targetSlots = GameObject.Find("Board").GetComponent<BoardManager>().getPlayerBoard().getCardSlots(); // For checking if card is over a card slot on the board
            for (int i = 0; i < targetSlots.Count; i++) /* Go through every slot on the board and check their availability */
            {
                /* Check if card that's held is over an empty card slot on the board */
                if ((gameObject.transform.position.x >= (targetSlots[i].getPosition().x - 50) && gameObject.transform.position.x <= (targetSlots[i].getPosition().x + 50)) && targetSlots[i].getCard() == null)
                {
                    targetSlots[i].setCard(this);
                    hand.removeCard(this);
                    GameObject.Find("Board").GetComponent<BoardManager>().getHighlight().SetActive(false);
                    Debug.Log("Card added to board");
                    break;
                }
            }
            if (hand != null) {
                GameObject.Find("Board").GetComponent<BoardManager>().getHighlight().SetActive(false);
                gameObject.transform.SetParent(parent.transform);
                hand.positionHand(hand.getPosition());
                hand.organizeHand();
            }
        }
    }
}
