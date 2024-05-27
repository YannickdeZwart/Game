
using System;
using System.Collections.Generic;
using System.Linq;

public class EquipmentChest : Chest
{
    public EquipmentChest(List<ChestReward> rewards) : base(rewards)
    {
    }

    public override Reward OpenChest()
    {
        double tRewardPercentage = this.GetTotalPercentage(base.rewards);
        double randomInPercentage = this.GetRandomDouble(tRewardPercentage);

        foreach(ChestReward chestReward in rewards) {
            randomInPercentage = Math.Round(randomInPercentage - chestReward.change, 2);

            if(randomInPercentage <= 0 ) {
                return chestReward.reward;
            }
        }

        return base.rewards.Last().reward;
    }

    private double GetTotalPercentage(List<ChestReward> rewards) {
        double tRewardPercentage = 0;

        foreach (ChestReward chestReward in rewards) {
            tRewardPercentage += chestReward.change;
        }

        return tRewardPercentage;
    }

    private double GetRandomDouble(double tRewardPercentage) {
        int randomInt = new Random().Next(0, (int) Math.Floor(tRewardPercentage));
        double randomDouble = new Random().NextDouble();

        return Math.Round(randomInt + randomDouble, 2);
    }
}