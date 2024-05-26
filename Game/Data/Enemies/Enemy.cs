public abstract class Enemy {
    public double health;
    public Reward reward;
    public BaseDefence defence;
    public abstract bool IsDead();
    public abstract void Damage(double damage);
    public abstract double GetHealth();
}