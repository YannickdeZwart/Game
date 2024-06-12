public class Reward {
    public double? coins;
    public Equipment? equipment;
    public HeroReward? heroReward;

    public Reward(double? coins = null, Equipment? equipment = null, HeroReward? heroReward = null) {
        this.coins = coins;
        this.equipment = equipment;
        this.heroReward = heroReward;
    }
}