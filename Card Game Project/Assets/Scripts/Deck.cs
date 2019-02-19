using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public int maximumAmountOfCards;
    private List<Card> cardList;

    #region Gets and Sets
    public List<Card> getCardList()
    {
        return cardList;
    }

    public void setCardList(List<Card> l)
    {
        cardList = l;
    }
    #endregion
}
