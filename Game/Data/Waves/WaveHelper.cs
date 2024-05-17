public static class WaveHelper {
    public static Enemy GetActiveEnemy(City city)
    {
        return city.GetActiveStage().GetActiveEnemy();
    }

    public static void AddEnemyToStage(int stageIndex, City city, Enemy enemy) {
        city.GetStageByIndex(stageIndex).AddEnemy(enemy);
    }
}