using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    protected GameObject cardObject;

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
    #endregion
}
