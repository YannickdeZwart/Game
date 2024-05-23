public abstract class Skill {
    public int cooldown;
    public int manaCost;
    public SkillEffect effect;

    public Skill(int cooldown, int manaCost, SkillEffect effect) 
    {
        this.cooldown = cooldown;
        this.manaCost = manaCost;
        this.effect = effect;
    }

}