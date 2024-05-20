public static class DamageHelper {
    public static bool RollHitChange(short change) 
    {
        Random random = new();
        return change > random.Next(0, 100);
    }

    public static void DoDamage(Character character, Enemy enemy)
    {
        List<Effect> effects = [character.sword.GetEffect()];
        double defence = DefenceHelper.GetDefence(enemy.defence);
        double tDamage = character.baseDamage.GetDamage(effects);

        tDamage -= defence;

        if(tDamage < 0) {
            enemy.Damage(0);
        } else {
            enemy.Damage(tDamage);
        }
    }
}