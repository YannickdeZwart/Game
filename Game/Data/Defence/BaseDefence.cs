public class BaseDefence : Defence
{
    private double baseDefence;

    public FireDefence fireDefence;

    public BaseDefence(double baseDefence, FireDefence fireDefence) 
    {
        this.baseDefence = baseDefence;
        this.fireDefence = fireDefence;
    }
    public override double GetDefence()
    {
        return baseDefence;
    }
}