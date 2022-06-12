using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    [Header("Display")]
    public string title;
    public string description;

    [Header("Cost")]
    public int fishCost;
    public int dollarCost;

    [Header("Effect")]
    public Attribute affectedAttribute;
    public float value;
    public UpgradeAction action;

    public Upgrade[] requiredUpgrades;
    public Upgrade[] unlockUpgrades;

    public enum UpgradeAction { ADD, MULTIPLY, SET }
}
