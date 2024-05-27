using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text mobName;
    public Text mobHealth;
    public Text coinsText;

    public Text baseDamageUpgradeInfoText;
    public Text baseDamageUpgradeCost;

    public Text chestRewardText;

    public City city;
    public Character character;
    public Chest chest;
    public Skill skill;
    public BaseDamageUpgrade baseDamageUpgrade;
    void Start()
    {
        DataManager dataManager = new DataManager();
        this.city = dataManager.city;
        this.character = dataManager.character;
        this.chest = dataManager.chest;
        this.skill = dataManager.skill;
        this.baseDamageUpgrade = dataManager.baseDamageUpgrade;
        this.UpdateBaseDamageUpgradeText(this.baseDamageUpgrade);
    }
    private float time = 0.0f;
    private float updateInterval = 2f;
    void Update()
    {
        time += Time.deltaTime;

        if(time >= updateInterval)
        {
            Stage activeStage = this.city.GetActiveStage();
            Enemy activeEnemy = activeStage.GetActiveEnemy();

            time = 0.0f;
            HitFunctions(activeEnemy);

            if(activeEnemy.IsDead())
            {
                RewardHelper.GiveReward(this.character, activeEnemy.reward);
                activeStage.AdvanceStage();

                if(activeStage.IsStageClear())
                {
                    this.city.AdvanceCity();

                    if(this.city.IsCityClear())
                    {
                        // clear
                    } else {
                        activeStage = this.city.GetActiveStage();
                    }
                    activeEnemy = activeStage.GetActiveEnemy();
                }
            }

            UpdateFunctions(activeEnemy);
        }
    }

    public void OpenChest()
    {
        Reward reward = this.chest.OpenChest();
        RewardHelper.GiveReward(this.character, reward);
        this.FlashRewardText(reward);
    }

    private void FlashRewardText(Reward reward)
    {
        RewardModel rewardModel = new(reward);
        this.chestRewardText.text = rewardModel.rewardText;
        Invoke("ResetRewardText", 8f);
    }

    private void ResetRewardText()
    {
        this.chestRewardText.text = "";
    }

    public void UseSkill()
    {
        Enemy activeEnemy = this.city.GetActiveStage().GetActiveEnemy();
        SkillHelper.HandleSkill(this.character, this.skill, activeEnemy);
        this.UpdateEnemyText(activeEnemy);
    }


    public void UpgradeBaseDamage()
    {
        if(this.baseDamageUpgrade.HandleUpgrade(this.character))
        {
            this.UpdateBaseDamageUpgradeText(this.baseDamageUpgrade);
            this.UpdateCurrencyText(this.character.currency);
        } else {
            // not enough coins
        }
    }

    private void UpdateBaseDamageUpgradeText(BaseDamageUpgrade baseDamageUpgrade)
    {
        BaseDamageUpgradeModel baseDamageUpgradeModel = new(baseDamageUpgrade);
        this.baseDamageUpgradeCost.text = baseDamageUpgradeModel.baseDamageUpgradeCost;
        this.baseDamageUpgradeInfoText.text = baseDamageUpgradeModel.baseDamageUpgradeInfoText;
    }

    private void UpdateEnemyText(Enemy enemy) {
        EnemyModel enemyModel = new EnemyModel(enemy);
        this.mobName.text = enemyModel.name;
        this.mobHealth.text = enemyModel.health;
    }

    private void UpdateCurrencyText(Currency currency) 
    {
        CurrencyModel currencyModel = new CurrencyModel(currency);
        this.coinsText.text = currencyModel.coins;
    }

    private void UpdateFunctions(Enemy activeEnemy)
    {
        this.UpdateEnemyText(activeEnemy);
        this.UpdateCurrencyText(this.character.currency);
    }

    private void HitFunctions(Enemy activeEnemy)
    {
        DamageHelper.DoDamage(this.character, activeEnemy);
    }
}