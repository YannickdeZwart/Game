public class BaseDefence : Defence
{
    private double baseDefence;

    public BaseDefence(double baseDefence) 
    {
        this.baseDefence = baseDefence;
    }
    public override double GetDefence()
    {
        return baseDefence;
    }
}