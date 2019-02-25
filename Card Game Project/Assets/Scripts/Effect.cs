using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    private Card target;
    private TargetType targetType;
    private EffectType effectType;
    private int numberOfTargets;

    #region Gets and Sets
    public void setTarget(Card c)
    {
        target = c;
    }

    public Card getTarget()
    {
        return target;
    }

    public void setType(EffectType t)
    {
        effectType = t;
    }

    public EffectType getType()
    {
        return effectType;
    }
    #endregion
}

public enum EffectType{
    OnPlay,             // Activates when card is played
    Constant,           // Always active
    OnEffect,           // Activates when another effect activates
    BeginningOfTurn,    // Activates in the beginning of a turn
    EndOfTurn           // Activates in the end of a turn
}

public enum TargetType{
    SingleCard,         // Targets a single card
    MultipleCards,      // Targets multiple specified cards
    Board,              // Targets all cards on a player's board
    All,                // Targets all cards in play
    Random,             // Target(s) chosen randomly
    Hand                // Targets player's hand
}
