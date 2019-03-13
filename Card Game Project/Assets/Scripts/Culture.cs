using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culture
{

    private string cultureName;
    private string flavorText;
    private Sprite menuBackground;
    private Sprite cardBackground;

    public Culture(string name, string flavor, Sprite menuS, Sprite cardS)
    {
        cultureName = name;
        flavorText = flavor;
        menuBackground = menuS;
        cardBackground = cardS;
    }

    public string getName()
    {
        return cultureName;
    }

    public string getFlavorText()
    {
        return flavorText;
    }

    public Sprite getMenuBackground()
    {
        return menuBackground;
    }

    public Sprite getCardBackground()
    {
        return cardBackground;
    }
}
