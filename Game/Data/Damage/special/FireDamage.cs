
using System;
using System.Collections.Generic;

public class FireDamage : Damage
{
    public double damage;

    public FireDamage(double damage)
    {
        this.damage = damage;
    }

    public override void AddDamage(double amount)
    {
        this.damage += amount;
    }


    public override double GetDamage(List<Effect> effects, List<HeroEffect> heroEffects)
    {
        return this.damage;
    }

    public override List<double> GetEffectStats(List<Effect> effects)
    {
        throw new NotImplementedException();
    }

    public override List<double> GetHeroEffectStats(List<HeroEffect> heroEffects)
    {
        throw new NotImplementedException();
    }

}