public static class DamageHelper {
    public static bool RollHitChange(short change) 
    {
        if(change == 0) {
            return false;
        } else if( change >= 100) {
            return true;
        }

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