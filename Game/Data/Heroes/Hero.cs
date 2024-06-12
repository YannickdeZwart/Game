public class Hero {
    private readonly Dictionary<string, int> statLevelMultipliers = Dictionary<string, int>();
    private readonly short maxLevel = 7;
    private readonly int[] levelShardCost = new int[0] { 10, 25, 50, 100, 250, 500, 1000 };
    public HeroEffect effect;
    public HeroStats stats;
    public HeroGear gear;
    public string name;

    public int shards;
    public short level;

    public Hero(HeroEffect effect, HeroStats stats, HeroGear gear, string name) 
    {
        this.effect = effect;
        this.stats = stats;
        this.gear = gear;
        this.name = name;
        this.shards = 0;
        this.level = 0;

        // initialize multipliers
        statLevelMultipliers.Add("baseDamage", 1.12);
    }

    public bool CanLevelUp()
    {
        return this.shards >= this.levelShardCost[level];
    }

    public bool IsMaxLevel()
    {
        return this.level == this.maxLevel;
    }

    public void HandleLevelUp()
    {
        if(!IsMaxLevel())
        {
            if(CanLevelUp())
            {
                this.level++;
                this.HandleLevelUpCost();
            }
        }
    }

    private void HandleLevelUpCost()
    {
        this.shards -= this.levelShardCost[level];
    }

    public HeroStats GetStatsForLevel()
    {
        HeroStats lvlHeroStats = new HeroStats();
        Dictionary<string, int> gearEffects = this.gear.GetGearEffects();
        lvlHeroStats.baseDamage = this.CalcWithMultiplierAndGear(this.stats.baseDamage, statLevelMultipliers["baseDamage"], gearBaseValue: gearEffects["baseDamage"]);

        return lvlHeroStats;
    }

    private double CalcWithMultiplierAndGear(double baseValue, double multiplier, double gearBaseValue = 0, double gearMultiplier = 0)
    {
        if (gearMultiplier > 0)
        {
            baseValue *= gearMultiplier;
        }
        return (baseValue + gearBaseValue) * (1 + (multiplier - 1) * this.level);
    }
}