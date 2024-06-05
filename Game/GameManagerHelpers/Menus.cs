using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menus {
    public Menu upgradeMenu;
    public Menu bannerMenu;
    public Menu inventoryMenu;
    public Menu chestMenu;
    public Menus
    (
        Canvas upgradeMenuCanvas,
        Canvas bannerMenuCanvas,
        Canvas inventoryMenuCanvas,
        Canvas chestMenuCanvas,
        Button upgradeMenuButton,
        Button bannerMenuButton,
        Button inventoryMenuButton,
        Button chestMenuButton
    )
    {
        this.upgradeMenu = new(upgradeMenuCanvas, upgradeMenuButton);
        this.bannerMenu = new(bannerMenuCanvas, bannerMenuButton);
        this.inventoryMenu = new(inventoryMenuCanvas, inventoryMenuButton);
        this.chestMenu = new(chestMenuCanvas, chestMenuButton);
    }

    public void ResetMenus(string name)
    {
        if(name != "upgrade")
        {
            this.upgradeMenu.CloseMenu();
        }
        if(name != "banner")
        {
            this.bannerMenu.CloseMenu();
        }
        if(name != "inventory")
        {
            this.inventoryMenu.CloseMenu();
        }
        if(name != "chest")
        {
            this.chestMenu.CloseMenu();
        }
    }
}

public class Menu {
    private Button selectButton;
    private Canvas canvas;
    public bool isOpen = false;

    public Menu(Canvas canvas, Button selectButton)
    {
        this.canvas = canvas;
        this.canvas.gameObject.SetActive(false);
        this.selectButton = selectButton;
        this.UpdateButton();
    }

    public void CloseMenu()
    {
        this.isOpen = false;
        this.canvas.gameObject.SetActive(this.isOpen);
        this.UpdateButton();
    }

    public void Toggle()
    {
        this.isOpen = !this.isOpen;
        this.canvas.gameObject.SetActive(this.isOpen);
        this.UpdateButton();
    }

    private void UpdateButton()
    {
        if(this.isOpen)
        {
            this.selectButton.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.green;
        }
        else 
        {
            this.selectButton.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.grey;
        }
    }
}