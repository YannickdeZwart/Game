using System;

public class EffectModel {
    public String effectString = "";

    public EffectModel(Effect effect)
    {
        if(effect.baseAttackM != 0)
        {
            effectString += "Base Attack Multiplier: " + effect.baseAttackM.ToString();
        }
        if(effect.critDamageM != 0)
        {
            effectString += "Crit Damage Multiplier: " + effect.critDamageM.ToString();
        }
        if(effect.critRateE != 0)
        {
            effectString += "Crit Rate Effect: " + effect.critRateE.ToString();
        }
    }
}