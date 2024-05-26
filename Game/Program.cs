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
Reward mobReward = new(coins: 500);
Enemy enemy = new Mob(600, baseDefence, mobReward);
Enemy enemy2 = new Mob(1200, baseDefence, mobReward);
Enemy enemy3 = new Mob(1800, baseDefence, mobReward);
Enemy enemy4 = new Mob(2000, baseDefence, mobReward);
Enemy enemy5 = new Mob(2600, baseDefence, mobReward);
Enemy enemy6 = new Mob(3200, baseDefence, mobReward);
Enemy enemy7 = new Mob(6000, baseDefence, mobReward);

WaveHelper.AddEnemyToStage(1, city, enemy);
WaveHelper.AddEnemyToStage(1, city, enemy2);
WaveHelper.AddEnemyToStage(1, city, enemy3);
WaveHelper.AddEnemyToStage(1, city, enemy4);
WaveHelper.AddEnemyToStage(1, city, enemy5);
WaveHelper.AddEnemyToStage(1, city, enemy6);
WaveHelper.AddEnemyToStage(1, city, enemy7);

// skill
SkillEffect skillEffect = new(5, 120);
Skill skill = new CutSkill(10, 5, skillEffect);

// chest
Reward reward1 = new(coins: 100);
Reward reward2 = new(coins: 200);
Reward reward3 = new(coins: 300);
Reward reward4 = new(coins: 400);


List<ChestReward> chestRewards  = new List<ChestReward>();
chestRewards.Add(new ChestReward(reward1, 10));
chestRewards.Add(new ChestReward(reward2, 20));
chestRewards.Add(new ChestReward(reward3, 30));
chestRewards.Add(new ChestReward(reward4, 40));
Chest chest = new EquipmentChest(chestRewards);

// upgrade

BaseDamageUpgrade baseDamageUpgrade= new(5, 80, 1.1);

// heroes
HeroSkill heroSkill = new();

HeroEffect heroEffect1 = new(critDamageM: 100);
HeroEffect heroEffect2 = new(critDamageM: 200);
HeroEffect heroEffect3 = new(critRateE: 10);
HeroEffect heroEffect4 = new(critRateE: 20);
HeroEffect heroEffect5 = new(baseAttackM: 100);
HeroEffect heroEffect6 = new(baseAttackM: 200);


Hero hero1 = new(heroEffect1, heroSkill, "Hero 1");
Hero hero2 = new(heroEffect2, heroSkill, "Hero 2");
Hero hero3 = new(heroEffect3, heroSkill, "Hero 3");
Hero hero4 = new(heroEffect4, heroSkill, "Hero 4");
Hero hero5 = new(heroEffect5, heroSkill, "Hero 5");
Hero hero6 = new(heroEffect6, heroSkill, "Hero 6");

List<Hero> heroes = new List<Hero>{ hero1, hero2, hero3, hero4, hero5, hero6 };
character.SetHeroes(heroes);

while(!city.IsCityClear())
{
    Stage activeStage = city.GetActiveStage();
    Enemy activeEnemy = activeStage.GetActiveEnemy();

    Console.WriteLine("Mob health: " + activeEnemy.health);
    Console.WriteLine("Coins: " + character.currency.coins);

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
            if(openReward.equipment != null) {
                Console.WriteLine("Reward: " + openReward.equipment.name);
            } else if(openReward.coins != null) {
                character.AddCoins(openReward.coins ??= 0);
                Console.WriteLine("Reward: " + openReward.coins + "Coins");
            }
            
            break;
        case "upgrade":
            try 
            {
                baseDamageUpgrade.HandleUpgrade(character);
                Console.WriteLine("Upgrade SucessFull!");
            } 
            catch (NoCurrencyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            break;
    }

    if(activeEnemy.IsDead())
    {
        RewardHelper.GiveReward(character, activeEnemy.reward);
        activeStage.AdvanceStage();

        if(activeStage.IsStageClear())
        {
            city.AdvanceCity();
        }
    }
}

Console.WriteLine("City Cleared!!");