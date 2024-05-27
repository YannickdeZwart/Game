using System.Collections.Generic;

public class BaseDamage : Damage
{
    private double damage;
    private short criticalRate;
    private double criticalDamageRate;

    public FireDamage fireDamage;

    public BaseDamage(double damage, short criticalRate, double criticalDamageRate, FireDamage fireDamage)
    {
        this.damage = damage;
        this.criticalRate = criticalRate;
        this.criticalDamageRate = criticalDamageRate;
        this.fireDamage = fireDamage;
    }

    public override double GetDamage(List<Effect> effects)
    {
        List<double> effectsStats = this.GetEffectStats(effects);
        double damage = this.damage + (this.damage / 100 * effectsStats[0]);
        short criticalRate = (short) (this.criticalRate + (short) effectsStats[1]);
        double criticalDamageRate = this.criticalDamageRate + effectsStats[2];
        double calcDamage = 0;

        calcDamage += damage;

        if(DamageHelper.RollHitChange(criticalRate)){
            calcDamage += damage / 100 * criticalDamageRate;
        }

        return calcDamage;
    }

    public override List<double> GetEffectStats(List<Effect> effects)
    {
        double damageM = 0;
        double criticalRateE = 0;
        double criticalDamageRateM = 0;

        foreach(Effect effect in effects) {
            damageM += effect.baseAttackM;
            criticalRateE += effect.critRateE;
            criticalDamageRateM += effect.critDamageM;
        }

        return new List<double>{ damageM, criticalRateE, criticalDamageRateM };
    }

    public override void AddDamage(double amount)
    {
        this.damage += amount;
    }

}