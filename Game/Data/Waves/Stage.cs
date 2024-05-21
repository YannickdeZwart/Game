public class Stage {
    private List<Enemy> enemies = new();
    private int currentEnemyIndex;
    private int stageTime;

    public Stage(int stageTime, List<Enemy> enemies) { 
        this.stageTime = stageTime;
        this.enemies = enemies;
        this.currentEnemyIndex = 1;
    }

    public bool IsStageClear()
    {
        return currentEnemyIndex == enemies.Count + 1;
    }

    public Enemy GetActiveEnemy()
    {
        return this.enemies[this.currentEnemyIndex - 1];
    }

    public void AddEnemy(Enemy enemy)
    {
        this.enemies.Add(enemy);
    }

    public void AdvanceStage() {
        this.currentEnemyIndex++;
    }
}