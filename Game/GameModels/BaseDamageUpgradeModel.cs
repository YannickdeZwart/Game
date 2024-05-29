using System;

public class BaseDamageUpgradeModel {
    public String baseDamageUpgradeCost;
    public String baseDamageUpgradeInfoText;

    public BaseDamageUpgradeModel(BaseDamageUpgrade baseDamageUpgrade, BaseDamage baseDamage)
    {
        this.baseDamageUpgradeCost = "Coins: " + Math.Floor(baseDamageUpgrade.upgradeCost);
        this.baseDamageUpgradeInfoText = "Base Damage:" + baseDamage.damage + " -> " + (baseDamage.damage + baseDamageUpgrade.upgradeAmount);
    }
}