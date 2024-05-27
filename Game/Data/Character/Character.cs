public class Character {
    public BaseDamage damage;
    public Equipment sword;
    public Currency currency;
    private List<Hero> heroes;

    public Character(BaseDamage damage, Equipment sword)
    {
        this.damage = damage;
        this.sword = sword;
        this.currency = new(0,0);
        this.heroes = new List<Hero>();
    }

    public void AddCoins(double coinAmount)
    {
        this.currency.coins += coinAmount;
    }

    public void SetHeroes(List<Hero> heroes)
    {
        this.heroes = heroes;
    }

    public List<HeroEffect> GetHeroEffects()
    {
        List<HeroEffect> heroEffects = new List<HeroEffect>();
        foreach (Hero hero in this.heroes)
        {
            heroEffects.Add(hero.effect);
        }
        return heroEffects;
    }
}