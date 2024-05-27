using System.Collections.Generic;

public abstract class Chest {
    public List<ChestReward> rewards;

    public Chest(List<ChestReward> rewards) { 
        this.rewards = rewards;
    }

    public abstract Reward OpenChest();
}