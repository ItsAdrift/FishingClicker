using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;

    [Header("Text Components")]
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text fishCost;
    [SerializeField] TMP_Text dollarCost;

    public void Setup(Upgrade upgrade)
    {
        this.upgrade = upgrade;

        title.text = upgrade.title;
        description.text = upgrade.description;
        fishCost.text = upgrade.fishCost + "F";
        dollarCost.text = "$" + upgrade.dollarCost;
    }

    public void HandleClick()
    {
        UpgradeManager.instance.Upgrade(this);
    }
}
