//preparing data

// character
FireDamage fireDamage = new(10);
BaseDamage baseDamage = new(100, 35, 150, fireDamage);
Effect effect = new(critDamageM: 300);
Equipment sword = new("Sword", effect);
Character character = new(baseDamage, sword);

//game
City city = new();
city.AddStage(30);

FireDefence fireDefence = new(7);
BaseDefence baseDefence = new(40, fireDefence);
Enemy enemy = new Mob(6000, baseDefence);

WaveHelper.AddEnemyToStage(1, city, enemy);

// skill
SkillEffect skillEffect = new(5, 120);
Skill skill = new CutSkill(10, 5, skillEffect);

// chest
Reward reward1 = new(equipment: new("10%", new()));
Reward reward2 = new(equipment: new("20%", new()));
Reward reward3 = new(equipment: new("30%", new()));
Reward reward4 = new(equipment: new("40%", new()));


List<ChestReward> chestRewards  = new List<ChestReward>();
chestRewards.Add(new ChestReward(reward1, 10));
chestRewards.Add(new ChestReward(reward2, 20));
chestRewards.Add(new ChestReward(reward3, 30));
chestRewards.Add(new ChestReward(reward4, 40));
Chest chest = new EquipmentChest(chestRewards);

while(!city.IsCityClear())
{
    Stage activeStage = city.GetActiveStage();
    Enemy activeEnemy = activeStage.GetActiveEnemy();

    Console.WriteLine("Mob health: " + activeEnemy.health);

    string output = Console.ReadLine();

    switch(output)
    {
        case "hit":
            DamageHelper.DoDamage(character, activeEnemy);
            break;
        case "skill":
            SkillHelper.HandleSkill(character, skill, activeEnemy);
            break;
        case "chest":
            Reward openReward = chest.OpenChest();
            Console.WriteLine("Reward: " + openReward.equipment.name);
            break;
    }

    if(activeEnemy.IsDead())
    {
        activeStage.AdvanceStage();

        if(activeStage.IsStageClear())
        {
            city.AdvanceCity();
        }
    }
}

Console.WriteLine("City Cleared!!");