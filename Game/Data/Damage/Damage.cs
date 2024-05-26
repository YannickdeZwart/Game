public abstract class Damage {
    public abstract double GetDamage(List<Effect> effects, List<HeroEffect> heroEffects);
    public abstract List<double> GetEffectStats(List<Effect> effects);
    public abstract List<double> GetHeroEffectStats(List<HeroEffect> heroEffects);
    public abstract void AddDamage(double amount);
}