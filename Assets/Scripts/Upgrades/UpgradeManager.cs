using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [SerializeField] GameObject upgradeDisplayPrefab;
    [SerializeField] Transform upgradeHolder;

    public List<Upgrade> upgrades;
    public List<Upgrade> unlockedUpgrades;

    public List<Upgrade> initialUpgrades;

    GameManager gameManager;
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        gameManager = GameManager.instance;

        foreach (Upgrade upgrade in initialUpgrades)
        {
            Setup(upgrade);
        }
    }

    public void Upgrade(UpgradeDisplay display)
    {
        Upgrade upgrade = display.upgrade;

        int i = 0;
        foreach (Upgrade upg in upgrade.requiredUpgrades)
        {
            if (unlockedUpgrades.Contains(upg))
            {
                i++;
            }
        }
        // Make sure that we have all required upgrades
        if (i != upgrade.requiredUpgrades.Length)
            return;

        // Make sure that we have enough money to buy this upgrade
        if (gameManager.fish >= upgrade.fishCost && gameManager.coins >= upgrade.dollarCost)
        {
            gameManager.fish -= upgrade.fishCost;
            gameManager.coins -= upgrade.dollarCost;
        }
        else
            return;

        // Add this upgrade as an unlocked upgrade
        unlockedUpgrades.Add(upgrade);

        // Apply upgrade actions
        PlayerAttribute playerAttribute = Player.instance.GetAttribute(upgrade.affectedAttribute.id);
        if (upgrade.action == global::Upgrade.UpgradeAction.ADD)
        {
            playerAttribute.value += upgrade.value;
        }
        else if (upgrade.action == global::Upgrade.UpgradeAction.MULTIPLY)
        {
            playerAttribute.value *= upgrade.value;
        }
        else if (upgrade.action == global::Upgrade.UpgradeAction.SET)
        {
            playerAttribute.value = upgrade.value;
        }
        Player.instance.OnAttributeUpdated.Invoke(playerAttribute);

        // Unlock & disply any 'unlocked' upgrades
        foreach (Upgrade upg in upgrade.unlockUpgrades)
        {
            Setup(upg);
        }

        // Hide this UpgradeDisplay
        Destroy(display.gameObject);
    }

    private void Setup(Upgrade upgrade)
    {
        Instantiate(upgradeDisplayPrefab, upgradeHolder).GetComponent<UpgradeDisplay>().Setup(upgrade);
    }
}
