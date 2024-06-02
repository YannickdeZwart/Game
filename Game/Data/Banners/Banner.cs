using System;
using System.Collections.Generic;
using System.Linq;

public class Banner {
    public string name;
    public List<Summon> summons;

    public int lowPityCount;
    public int lowPityCounter;
    public SummonRarity lowPityRarity;
    public int highPityCount;
    public int highPityCounter;
    public SummonRarity highPityRarity;

    public Banner(string name, List<Summon> summons, int lowPityCount, int highPityCount, SummonRarity lowPityRarity, SummonRarity highPityRarity)
    {
        this.name = name;
        this.summons = summons;
        this.lowPityCount = lowPityCount;
        this.lowPityCounter = 0;
        this.lowPityRarity = lowPityRarity;
        this.highPityCount = highPityCount;
        this.highPityCounter = 0;
        this.highPityRarity = highPityRarity;
    }

    public Reward SummonBanner()
    {
        Reward reward = null;
        Summon lastSummon = new(new(), SummonRarity.Common);
        double tRewardPercentage = this.GetTotalPercentage();
        double randomInPercentage = this.GetRandomDouble(tRewardPercentage);

        foreach(Summon summon in this.summons) {
            randomInPercentage = Math.Round(randomInPercentage - summon.GetRarityChange(), 3);

            if(randomInPercentage <= 0 ) {
                reward = summon.reward;
                break;
            }
            lastSummon = summon;
        }

        reward ??= this.summons.Last().reward;

        this.highPityCounter++;
        this.lowPityCounter++;

        if(this.highPityCounter == this.highPityCount)
        {
            reward = GetPitySummon(this.highPityRarity, lastSummon).reward;
            this.highPityCounter = 0;
        } 
        else if(this.lowPityCounter >= this.lowPityCount)
        {
            reward = GetPitySummon(this.lowPityRarity, lastSummon).reward;
            this.lowPityCounter = 0;
        }

        CheckHighPityCounter(lastSummon);
        CheckLowPityCounter(lastSummon);

        return reward;
    }

    private double GetTotalPercentage() {
        double tRewardPercentage = 0;

        foreach (Summon summon in this.summons) {
            tRewardPercentage += summon.GetRarityChange();
        }

        return tRewardPercentage;
    }

    private double GetRandomDouble(double tRewardPercentage) {
        int randomInt = new Random().Next(0, (int) Math.Floor(tRewardPercentage));
        double randomDouble = new Random().NextDouble();

        return Math.Round(randomInt + randomDouble, 3);
    }

    private bool IsSummonRarityInPity(Summon summon, SummonRarity pityRarity)
    {
        return summon.rarity >= pityRarity;
    }

    private Summon GetPitySummon(SummonRarity pityRarity, Summon lastSummon)
    {
        if(!IsSummonRarityInPity(lastSummon, this.lowPityRarity))
        {
            List<Summon> lowPitySummons = this.summons.Where(summon => summon.rarity == pityRarity).ToList(); // is not a valid list

            Random random = new();
            int randomIndexInSummons = random.Next(0, lowPitySummons.Count - 1);
            return lowPitySummons[randomIndexInSummons];
        }

        return lastSummon;
    }

    private void CheckLowPityCounter(Summon summon)
    {
        if(IsSummonRarityInPity(summon, this.lowPityRarity))
        {
            this.lowPityCounter = 0;
        }
    }

    private void CheckHighPityCounter(Summon summon)
    {
        if(IsSummonRarityInPity(summon, this.highPityRarity))
        {
            this.highPityCounter = 0;
        }
    }
}