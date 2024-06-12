using System.Collections.Generic;

public class Character {
    public BaseDamage damage;
    public Equipment sword;
    public Currency currency;

    public Inventory inventory;
    private List<Hero> heroes;

    public Character(BaseDamage damage, Equipment sword)
    {
        this.damage = damage;
        this.sword = sword;
        this.currency = new(0,0);
        this.heroes = new List<Hero>();
        this.inventory = new Inventory();
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

    public double GetHerosDamage()
    {
        double damage = 0;
        foreach (Hero hero in this.heroes)
        {
            damage += hero.GetStatsForLevel().getDamage();
        }
        return damage;
    }

    public void GiveHeroShards(HeroReward heroReward)
    {
        Hero hero = this.heroes.Find(heroReward.hero);

        if (hero != null)
        {
            hero.shards += heroReward.shards;
        }
    }
}