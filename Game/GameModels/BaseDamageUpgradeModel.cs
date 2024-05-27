using System;

public class BaseDamageUpgradeModel {
    public String baseDamageUpgradeCost;
    public String baseDamageUpgradeInfoText;

    public BaseDamageUpgradeModel(BaseDamageUpgrade baseDamageUpgrade)
    {
        this.baseDamageUpgradeCost = "Coins: " + Math.Floor(baseDamageUpgrade.upgradeCost);
        this.baseDamageUpgradeInfoText = "Base Damage +" + baseDamageUpgrade.upgradeAmount;
    }
}