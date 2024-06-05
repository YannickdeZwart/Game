public class SelectedEquipmentModel {
    public string name;
    public string rarity;
    public string effects;

    public SelectedEquipmentModel(Equipment equipment)
    {
        this.name = equipment.name;
        this.rarity = equipment.name;
        EffectModel effectModel = new(equipment.effect);
        this.effects = effectModel.effectString;
    }
}