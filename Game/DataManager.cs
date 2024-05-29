using System.Collections.Generic;

public class DataManager {
    public Character character;
    public City city;
    public Chest chest;
    public Skill skill;
    public BaseDamageUpgrade baseDamageUpgrade;

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
    }
}