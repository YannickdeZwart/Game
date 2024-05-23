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
        
        double tDamage = character.damage.GetDamage(effects);

        tDamage += GetFinalElementDamage(character.damage.fireDamage, enemy.defence.fireDefence, effects);

        tDamage -= DefenceHelper.GetDefence(enemy.defence); 

        if(tDamage < 0) {
            enemy.Damage(0);
        } else {
            enemy.Damage(tDamage);
        }
    }

        public static void DoSkillDamage(Character character, Skill skill, Enemy enemy)
    {
        List<Effect> effects = [character.sword.GetEffect()];
        
        double tDamage = character.damage.GetDamage(effects);

        tDamage += GetFinalElementDamage(character.damage.fireDamage, enemy.defence.fireDefence, effects);

        tDamage = Math.Round(tDamage / 100 * skill.effect.damageMultiplier);

        tDamage -= DefenceHelper.GetDefence(enemy.defence); 

        if(tDamage < 0) {
            enemy.Damage(0);
        } else {
            enemy.Damage(tDamage);
        }
    }

    private static double GetFinalElementDamage(Damage damage, Defence defence, List<Effect> effects)
    {
        double finalDamage = damage.GetDamage(effects) - defence.GetDefence();

        return finalDamage > 0 ? finalDamage : 0;
    }
}