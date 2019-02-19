﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    protected string cardName;
    protected string flavorText;
    protected Sprite cardImage;
    protected int militaryPowerCost;
    protected int culturePowerCost;
    protected int technologyPowerCost;

    protected string cardTypeID;
    protected string cardCultureID;

    public void setCardSize(int x, int y)
    {
        gameObject.transform.Find("Back_Background").transform.localScale = new Vector2(x, y);
        gameObject.transform.Find("Front_Background").transform.localScale = new Vector2(x, y);
    }

    public void initializeCard()
    {
        gameObject.transform.Find("Front_Background").transform.Find("Front_Picture").GetComponent<Image>().sprite = cardImage;
    }

    #region Gets and Sets
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
