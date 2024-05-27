using System;

public class EnemyModel {
    public String name;
    public String health;
    
    public EnemyModel(Enemy enemy) {
        this.name = enemy.name;
        this.health = Math.Floor(enemy.health).ToString();
    }
}