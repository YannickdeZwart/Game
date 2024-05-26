public class BaseDamageUpgrade : Upgrade {

    public BaseDamageUpgrade(double upgradeAmount, double upgradeCost, double upgradeCostM): base(upgradeAmount, upgradeCost, upgradeCostM) {}

    public override bool CanUpgrade(Currency currency)
    {
        return base.upgradeCost <= currency.coins;
    }

    public override void HandleUpgrade(Character character)
    {
        if(this.CanUpgrade(character.currency))
        {
            character.damage.AddDamage(base.upgradeAmount);
            this.HandleUpgradeCost(character.currency);
            base.HandleUpgradeCostMultipliers();
            base.level += 1;
        } else {
            throw new NoCurrencyException("coins");
        }
    }

    private void HandleUpgradeCost(Currency currency)
    {
        currency.coins -= base.upgradeCost;
    }
}