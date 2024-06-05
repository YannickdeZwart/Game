using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text mobName;
    public Text mobHealth;
    public Text coinsText;

    public Text baseDamageUpgradeInfoText;
    public Text baseDamageUpgradeCost;

    public Text bannerRewardText;

    public GameObject inventoryEquipmentPanel;
    public GameObject inventoryEquipmentTemplate;

    public Text equipedSword;

    public City city;
    public Character character;
    public Chest chest;
    public Skill skill;
    public BaseDamageUpgrade baseDamageUpgrade;
    public Banner banner;
    public Text bannerLowPityText;
    public Text bannerHighPityText;

    public Canvas upgradeMenuCanvas;
    public Canvas inventoryMenuCanvas;
    public Canvas bannerMenuCanvas;
    public Canvas chestMenuCanvas;

    public Button upgradeMenuButton;
    public Button inventoryMenuButton;
    public Button bannerMenuButton;
    public Button chestMenuButton;

    public Menus menus;
    void Start()
    {
        DataManager dataManager = new DataManager();
        this.city = dataManager.city;
        this.character = dataManager.character;
        this.chest = dataManager.chest;
        this.skill = dataManager.skill;
        this.baseDamageUpgrade = dataManager.baseDamageUpgrade;
        this.banner = dataManager.banner;
        this.UpdateBaseDamageUpgradeText(this.baseDamageUpgrade);
        this.GenerateInventoryEquipment(this.character.inventory);
        this.equipedSword.text = this.character.sword.name;
        this.bannerRewardText.gameObject.SetActive(false);
        this.menus = new Menus(
            upgradeMenuCanvas: upgradeMenuCanvas,
            bannerMenuCanvas: bannerMenuCanvas,
            inventoryMenuCanvas: inventoryMenuCanvas,
            chestMenuCanvas: chestMenuCanvas,
            upgradeMenuButton: upgradeMenuButton,
            bannerMenuButton: bannerMenuButton,
            inventoryMenuButton: inventoryMenuButton,
            chestMenuButton: chestMenuButton
        );
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

    public void ToggleMenuByName(string name)
    {
        this.menus.ResetMenus(name);
        switch(name)
        {
            case "upgrade":
                this.menus.upgradeMenu.Toggle();
                break;
            case "banner":
                this.menus.bannerMenu.Toggle();
                break;
            case "inventory":
                this.menus.inventoryMenu.Toggle();
                break;
            case "chest":
                this.menus.chestMenu.Toggle();
                break;
        }
    }

    public void OpenChest()
    {
        Reward reward = this.chest.OpenChest();
        RewardHelper.GiveReward(this.character, reward);
        this.FlashRewardText(reward);

        if(reward.equipment != null)
        {
            this.GenerateInventoryEquipment(this.character.inventory);
        }
    }

    public void SummonBanner()
    {
        Reward reward = this.banner.SummonBanner();
        RewardHelper.GiveReward(this.character, reward);
        this.ShowBannerReward(reward);
        this.UpdateBannerPityText();
    }

    private void UpdateBannerPityText()
    {
        BannerModel bannerModel = new(this.banner);
        this.bannerLowPityText.text = bannerModel.lowPityText;
        this.bannerHighPityText.text = bannerModel.highPityText;
    }

    private void ShowBannerReward(Reward reward)
    {
        RewardModel rewardModel = new(reward);
        this.bannerRewardText.text = rewardModel.rewardText;
        this.bannerRewardText.gameObject.SetActive(true);
        Invoke("HideBannerReward", 5f);
    }

    private void HideBannerReward()
    {
        this.bannerRewardText.gameObject.SetActive(false);
    }

    private void FlashRewardText(Reward reward)
    {
        // RewardModel rewardModel = new(reward);
        // this.chestRewardText.text = rewardModel.rewardText;
        // Invoke("ResetRewardText", 8f);
    }

    private void ResetRewardText()
    {
        // this.chestRewardText.text = "";
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
        BaseDamageUpgradeModel baseDamageUpgradeModel = new(baseDamageUpgrade, this.character.damage);
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

    private void GenerateInventoryEquipment(Inventory inventory)
    {
        this.InventoryEquipmentClear();
        inventoryEquipmentTemplate.gameObject.SetActive(true);
        for(int i = 0; i < inventory.equipment.Count; i++)
        {
            Equipment equipment = inventory.equipment[i];
            EffectModel effectModel = new EffectModel(equipment.effect);

            GameObject equipmentItem = Instantiate(this.inventoryEquipmentTemplate, this.inventoryEquipmentPanel.transform);
            equipmentItem.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = equipment.name;
            equipmentItem.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = effectModel.effectString;

            Button[] equipButtons = equipmentItem.GetComponentsInChildren<Button>();
            foreach(Button button in equipButtons)
            {
                if(this.InventoryEquipmentIsEquiped(equipment))
                {
                    button.interactable = false;
                } else {
                    button.onClick.AddListener(() => { InventoryEquipmentEquip(equipment); });
                }
            }

        }
        inventoryEquipmentTemplate.gameObject.SetActive(false);
    }

    private void InventoryEquipmentClear()
    {
        for(int i = 0; i < this.inventoryEquipmentPanel.transform.childCount; i++)
        {
            GameObject equipment = this.inventoryEquipmentPanel.transform.GetChild(i).gameObject;
            if(equipment != inventoryEquipmentTemplate)
            {
                Destroy(equipment);
            }
            
        }
    }

    public void InventoryEquipmentEquip(Equipment equipment)
    {
        this.character.sword = equipment;
        this.GenerateInventoryEquipment(this.character.inventory);
        this.equipedSword.text = this.character.sword.name;
    }

    private bool InventoryEquipmentIsEquiped(Equipment equipment)
    {
        return this.character.sword == equipment;
    }
}