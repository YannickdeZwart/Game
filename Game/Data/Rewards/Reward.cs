public class Reward {
    public double? coins;
    public Equipment? equipment;
    public Hero? hero;

    public Reward(double? coins = null, Equipment? equipment = null, Hero? hero = null) {
        this.coins = coins;
        this.equipment = equipment;
        this.hero = hero;
    }
}