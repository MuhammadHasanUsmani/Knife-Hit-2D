using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public Text coinUI;
    public ShopItemsSO[] shopItemsSO;
    public GameObject[] shopPanelsSO;
    public ShopTamplate[] shopPanels;
    public Button[] myPurchaseBtns;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsSO[i].SetActive(true);
        
        LoadPanels();
        CheckPurchaseable();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemsSO[btnNo].baseCost)
        {
            coins = coins - shopItemsSO[btnNo].baseCost;
            coinUI.text = "Coins " + coins.ToString();
            CheckPurchaseable();
        }
    }
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemsSO[i].title;
            shopPanels[i].description.text = shopItemsSO[i].description;
            shopPanels[i].costtext.text = "Coins" + shopItemsSO[i].baseCost.ToString();
        }
    }
}
