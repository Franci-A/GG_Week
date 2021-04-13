using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Drink,
    Heal,
    Bullets
}

[Serializable]
public class Items 
{
    public ItemType type;
    public int amount;

    public Items(ItemType itemType, int _amount)
    {
        type = itemType;
        amount = _amount;
    }

}
