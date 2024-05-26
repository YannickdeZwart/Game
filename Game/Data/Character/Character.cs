public class Character {
    public BaseDamage damage;
    public Equipment sword;
    public Currency currency;

    public Character(BaseDamage damage, Equipment sword)
    {
        this.damage = damage;
        this.sword = sword;
        this.currency = new(0,0);
    }

    public void AddCoins(double coinAmount)
    {
        this.currency.coins += coinAmount;
    }
}