public class Equipment {
    private String name;
    private Effect effect;

    public Equipment(String name, Effect effect) {
        this.name = name;
        this.effect = effect;
    }

    public Effect GetEffect() { return this.effect; }
}