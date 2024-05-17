public class Mob : Enemy {
    private double health;

    public Mob(double health) { 
        this.health = health;
    }

    public override void DoDamage(BaseDamage damage)
    {
        this.health -= damage.getDamage();
    }

    public override bool IsDead()
    {
        return health <= 0;
    }
}