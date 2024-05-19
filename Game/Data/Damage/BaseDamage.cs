public class BaseDamage : Damage
{
    private double damage;
    private short criticalRate;
    private double criticalDamageRate;

    public BaseDamage(double damage, short criticalRate, double criticalDamageRate)
    {
        this.damage = damage;
        this.criticalRate = criticalRate;
        this.criticalDamageRate = criticalDamageRate;
    }

    public override double GetDamage()
    {
        double calcDamage = 0;

        calcDamage += this.damage;

        if(DamageHelper.RollHitChange(this.criticalRate)){
            calcDamage += this.damage / 100 * this.criticalDamageRate;
        }

        return calcDamage;
    }
}