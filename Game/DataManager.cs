using System.Collections.Generic;

public class DataManager {
    public Character character;
    public City city;
    public Chest chest;
    public Skill skill;
    public BaseDamageUpgrade baseDamageUpgrade;
    public Banner banner;

    public DataManager()
    {
        this.Init();
    }

    public void Init()
    {
        //preparing data

        // character
        FireDamage fireDamage = new(10);
        BaseDamage baseDamage = new(100, 35, 150, fireDamage);
        Effect effect = new(critDamageM: 300);
        Equipment sword = new("Sword", effect);
        this.character = new(baseDamage, sword);

        //game
        this.city = new();
        this.city.AddStage(30);

        FireDefence fireDefence = new(7);
        BaseDefence baseDefence = new(40, fireDefence);
        Reward mobReward = new(coins: 500);
        Enemy enemy = new Mob(600, baseDefence, mobReward, "Mob 1");
        Enemy enemy2 = new Mob(1200, baseDefence, mobReward, "Mob 2");
        Enemy enemy3 = new Mob(1800, baseDefence, mobReward, "Mob 3");
        Enemy enemy4 = new Mob(2000, baseDefence, mobReward, "Mob 4");
        Enemy enemy5 = new Mob(2600, baseDefence, mobReward, "Mob 5");
        Enemy enemy6 = new Mob(3200, baseDefence, mobReward, "Mob 6");
        Enemy enemy7 = new Mob(6000, baseDefence, mobReward, "Mob 7");

        WaveHelper.AddEnemyToStage(1, this.city, enemy);
        WaveHelper.AddEnemyToStage(1, this.city, enemy2);
        WaveHelper.AddEnemyToStage(1, this.city, enemy3);
        WaveHelper.AddEnemyToStage(1, this.city, enemy4);
        WaveHelper.AddEnemyToStage(1, this.city, enemy5);
        WaveHelper.AddEnemyToStage(1, this.city, enemy6);
        WaveHelper.AddEnemyToStage(1, this.city, enemy7);

        // skill
        SkillEffect skillEffect = new(5, 120);
        this.skill = new CutSkill(10, 5, skillEffect);

        // chest
        Effect equipmentRewardEffect = new(baseAttackM: 200000);
        Equipment equipmentReward = new("Reward equipment 1", equipmentRewardEffect);
        Equipment equipmentReward2 = new("Reward equipment 2", equipmentRewardEffect);

        Reward reward1 = new(coins: 100);
        Reward reward2 = new(coins: 200);
        Reward reward3 = new(equipment: equipmentReward);
        Reward reward4 = new(equipment: equipmentReward2);


        List<ChestReward> chestRewards  = new List<ChestReward>
        {
            new ChestReward(reward1, 10),
            new ChestReward(reward2, 20),
            new ChestReward(reward3, 30),
            new ChestReward(reward4, 40)
        };
        this.chest = new EquipmentChest(chestRewards);

        // upgrade

        this.baseDamageUpgrade= new(5, 80, 1.1);

        //inventory
        Effect effect2 = new Effect(baseAttackM: 400);
        Equipment equipment = new Equipment("Good sword", effect2);
        this.character.inventory.equipment.Add(sword);
        this.character.inventory.equipment.Add(equipment);

        // banner
        HeroSkill heroSkill= new();
        HeroEffect heroEffect = new();

        Hero heror = new Hero(heroEffect, heroSkill, "Hero rare");
        Hero heroe = new Hero(heroEffect, heroSkill, "Hero epic");
        Hero herol = new Hero(heroEffect, heroSkill, "Hero legendary");
        Hero herom = new Hero(heroEffect, heroSkill, "Hero mythical");

        Summon summon1 = new(new(heroReward: new HeroReward(heror, 10)), SummonRarity.Rare);
        Summon summon2 = new(new(coins: 100), SummonRarity.Rare);

        Summon summon3 = new(new(heroReward: new HeroReward(heroe, 10)), SummonRarity.Epic);
        Summon summon4 = new(new(coins: 300), SummonRarity.Epic);

        Summon summon5 = new(new(heroReward: new HeroReward(herol, 10)), SummonRarity.Legendary);
        Summon summon6 = new(new(coins: 500), SummonRarity.Legendary);

        Summon summon7 = new(new(heroReward: new HeroReward(herom, 10)), SummonRarity.Mythical);
        Summon summon8 = new(new(coins: 1000), SummonRarity.Mythical);

        List<Summon> summons = new List<Summon>();
        summons.Add(summon1);
        summons.Add(summon2);
        summons.Add(summon3);
        summons.Add(summon4);
        summons.Add(summon5);
        summons.Add(summon6);
        summons.Add(summon7);
        summons.Add(summon8);
        this.banner = new("Hero Banner", summons, 10, 30, SummonRarity.Legendary, SummonRarity.Mythical);
    }
}