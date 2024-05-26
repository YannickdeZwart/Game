public abstract class Upgrade {
    public readonly double upgradeCostMMultiplier = 1.0024;
    public int level;
    public double upgradeAmount;
    public double upgradeCost;
    public double upgradeCostM;

    public Upgrade(double upgradeAmount, double upgradeCost, double upgradeCostM)
    {
        this.level = 0;
        this.upgradeAmount = upgradeAmount;
        this.upgradeCost = upgradeCost;
        this.upgradeCostM = upgradeCostM;
    }

    public void HandleUpgradeCostMultipliers()
    {
        this.upgradeCost *= this.upgradeCostM;
        this.upgradeCostM *= this.upgradeCostMMultiplier;
    }

    public abstract bool CanUpgrade(Currency currency);
    public abstract void HandleUpgrade(Character character);
}