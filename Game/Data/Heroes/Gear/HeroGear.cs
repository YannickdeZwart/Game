public class HeroGear {
    public Gear ring;
    public Gear book;
    public Gear helmet;

    public HeroGear(Gear ring, Gear book, Gear helmet)
    {
        this.ring = ring;
        this.book = book;
        this.helmet = helmet;
    }

    public Dictionary<string, int> GetGearEffects()
    {
        double tbaseDamage = ring.baseDamage + book.baseDamage + helmet.baseDamage;

        return new Dictionary<string, int>()
        {
            { "baseDamage", ring.baseDamage }
        };
    }
}

public class Gear {
    public double baseDamage;

    public Gear(int baseDamage)
    {
        this.baseDamage = baseDamage;
    }
}