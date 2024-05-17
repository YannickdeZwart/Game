public abstract class Enemy {
    private double health;
    public abstract bool IsDead();
    public abstract void DoDamage(BaseDamage damage);
}