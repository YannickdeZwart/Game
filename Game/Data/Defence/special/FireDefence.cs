public class FireDefence : Defence
{
    public double fireDefence;

    public FireDefence(double fireDefence)
    {
        this.fireDefence = fireDefence;
    }
    public override double GetDefence()
    {
        return this.fireDefence;
    }
}