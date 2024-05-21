public class Mob : Enemy {

    public Mob(double health, BaseDefence defence) { 
        base.health = health;
        base.defence = defence;
    }

    public override void Damage(double damage)
    {
        base.health -= damage;
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