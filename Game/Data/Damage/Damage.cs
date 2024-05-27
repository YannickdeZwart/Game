using System.Collections.Generic;

public abstract class Damage {
    public abstract double GetDamage(List<Effect> effects);
    public abstract List<double> GetEffectStats(List<Effect> effects);
    public abstract void AddDamage(double amount);
}