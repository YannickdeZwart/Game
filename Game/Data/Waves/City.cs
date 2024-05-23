public class City {
    private List<Stage> stages = new();
    private int currentStageIndex;

    public City() {
        this.currentStageIndex = 1;
    }

    public bool IsCityClear()
    {
        return this.currentStageIndex == this.stages.Count + 1;
    }

    public void AdvanceCity()
    {
        this.currentStageIndex++;
    }

    public Stage GetActiveStage()
    {
        return this.stages[this.currentStageIndex - 1];
    }

    public void AddStage(int stageTime, List<Enemy> enemies)
    {
        this.stages.Add(new Stage(stageTime, enemies));
    }

    public void AddStage(int stageTime)
    {
        this.stages.Add(new Stage(stageTime, new()));
    }

    public Stage GetStageByIndex(int index)
    {
        return this.stages[index - 1];
    }
}