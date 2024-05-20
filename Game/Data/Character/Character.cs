public class Character {
    public BaseDamage baseDamage;
    public Equipment sword;

    public Character() {
        this.baseDamage = new BaseDamage(10, 50, 200);
        Effect swordEffect = new Effect(5, 200, 10);
        this.sword = new Equipment("basic sword", swordEffect);
    }
}