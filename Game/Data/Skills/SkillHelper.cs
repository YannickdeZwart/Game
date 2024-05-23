public static class SkillHelper {
    public static void HandleSkill(Character characer, Skill skill, Enemy enemy) 
    {
        for (int i = skill.effect.useAmount; i > 0; i--)
        {
            DamageHelper.DoSkillDamage(characer, skill, enemy);
        }
    }
}