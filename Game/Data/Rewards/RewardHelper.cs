public static class RewardHelper {
    public static void GiveReward(Character character, Reward reward) 
    {
        GiveEquipmentReward(character, reward.equipment);
        GiveCoinReward(character, reward.coins ?? 0);
    }

    private static void GiveEquipmentReward(Character character, Equipment ?equipment)
    {
        //
    }

    private static void GiveCoinReward(Character character, double coinAmount)
    {
        character.AddCoins(coinAmount);
    }
}