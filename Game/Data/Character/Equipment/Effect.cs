public class Effect {
    public double baseAttackM;
    public double critDamageM;
    public short critRateE;

    public Effect(double baseAttackM = 0, double critDamageM = 0, short critRateE = 0) { 
        this.baseAttackM = baseAttackM;
        this.critDamageM = critDamageM;
        this.critRateE = critRateE;
    }
}