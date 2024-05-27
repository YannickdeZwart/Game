using System;

public class RewardModel {
    public String rewardText = "";

    public RewardModel(Reward reward)
    {
        if(reward.equipment != null)
        {
            this.rewardText += "Equipment: " + reward.equipment.name + "\n";
        }

        if(reward.coins != null)
        {
            this.rewardText += reward.coins + "+ Coins";
        }
    }
}