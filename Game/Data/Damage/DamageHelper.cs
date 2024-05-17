public static class DamageHelper {
    public static bool RollHitChange(short change) {
        Random random = new();
        return change > random.Next(0, 100);
    }

    public static void DoDamage(BaseDamage damage, Enemy enemy) {
        enemy.DoDamage(damage);
    }
}