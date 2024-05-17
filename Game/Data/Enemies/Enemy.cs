public abstract class Enemy {
    public double health;
    public abstract bool IsDead();
    public abstract void DoDamage(BaseDamage damage);
    public abstract double GetHealth();
}