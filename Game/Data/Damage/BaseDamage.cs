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

    public override double GetDamage(List<Effect> effects, List<HeroEffect> heroEffects)
    {
        List<double> effectsStats = this.GetEffectStats(effects);
        List<double> heroEffectStats = this.GetHeroEffectStats(heroEffects);

        double damageM = effectsStats[0] + heroEffectStats[0];
        double criticalRateE = effectsStats[1] + heroEffectStats[1];
        double criticalDamageM = effectsStats[2] + heroEffectStats[2];

        double damage = this.damage + (this.damage / 100 * damageM);
        short criticalRate = (short) (this.criticalRate + (short) criticalRateE);
        double criticalDamageRate = this.criticalDamageRate + criticalDamageM;
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

    public override List<double> GetHeroEffectStats(List<HeroEffect> heroEffects)
    {
        double damageM = 0;
        double criticalRateE = 0;
        double criticalDamageRateM = 0;

        foreach(HeroEffect heroEffect in heroEffects) {
            damageM += heroEffect.baseAttackM;
            criticalRateE += heroEffect.critRateE;
            criticalDamageRateM += heroEffect.critDamageM;
        }

        return new List<double>{ damageM, criticalRateE, criticalDamageRateM };
    }

    public override void AddDamage(double amount)
    {
        this.damage += amount;
    }
}