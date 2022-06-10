using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttribute
{
    public Attribute attribute;
    public float value;

    public PlayerAttribute(Attribute attribute, float value)
    {
        this.attribute = attribute;
        this.value = value;
    }
}

