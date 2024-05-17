public class Mob : Enemy {

    public Mob(double health) { 
        base.health = health;
    }

    public override void DoDamage(BaseDamage damage)
    {
        base.health -= damage.getDamage();
    }

    public override bool IsDead()
    {
        return base.health <= 0;
    }

    public override double GetHealth()
    {
        return base.health;
    }
}