using System.Collections.Generic;

public class Inventory {
    public List<Equipment> equipment;
    public List<Hero> heroes;

    public Inventory()
    {
        this.equipment = new List<Equipment>();
        this.heroes = new List<Hero>();
    }
}