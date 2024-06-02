public class Summon {
    public Reward reward;
    public SummonRarity rarity;

    public Summon(Reward reward, SummonRarity rarity)
    {
        this.reward = reward;
        this.rarity = rarity;
    }
    public double GetRarityChange()
    {
        switch(this.rarity)
        {
            case SummonRarity.Common:
                return 50;
            case SummonRarity.Rare:
                return 30;
            case SummonRarity.Epic:
                return 15;
            case SummonRarity.Legendary:
                return 5;
            case SummonRarity.Mythical:
                return 1;
            case SummonRarity.Dark:
                return 0.01;
            case SummonRarity.Corrupted:
                return 0.001;
            default:
                return 0;
        }
    }

}

public enum SummonRarity {
    Common, Rare, Epic, Legendary, Mythical, Dark, Corrupted
}