public static class DefenceHelper {
    public static double GetResolveDefence(BaseDamage damage, BaseDefence defence) {
        double tDamage = 0;

        tDamage = damage.GetDamage() - defence.GetDefence();

        return tDamage;
    }
}