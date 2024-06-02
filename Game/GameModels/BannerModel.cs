public class BannerModel {
    public string highPityText;
    public string lowPityText;

    public BannerModel(Banner banner)
    {
        this.lowPityText = banner.lowPityRarity + " pity: " + banner.lowPityCounter + "/" + banner.lowPityCount;
        this.highPityText = banner.highPityRarity + " pity: " + banner.highPityCounter + "/" + banner.highPityCount;
    }
}