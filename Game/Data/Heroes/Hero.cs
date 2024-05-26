public class Hero {
    public HeroEffect effect;
    public HeroSkill skill;
    public string name;

    public Hero(HeroEffect effect, HeroSkill skill, string name) 
    {
        this.effect = effect;
        this.skill = skill;
        this.name = name;
    }
}