public static class RewardHelper {
    public static void GiveReward(Character character, Reward reward) 
    {
        GiveEquipmentReward(character, reward.equipment);
        GiveCoinReward(character, reward.coins ?? 0);
        GiveHeroShardsReward(character, reward.hero);
    }

    private static void GiveEquipmentReward(Character character, Equipment ?equipment)
    {
        if(equipment != null)
        {
            character.inventory.equipment.Add(equipment);
        }    
    }

    private static void GiveCoinReward(Character character, double coinAmount)
    {
        character.AddCoins(coinAmount);
    }

    private static void GiveHeroShardsReward(Character character, HeroReward ?heroReward)
    {
        if(heroReward != null)
        {
            character.GiveHeroShards(heroReward);
        }
    }
}