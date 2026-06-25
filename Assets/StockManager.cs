using TMPro;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    [Header("Stock Texts")]
    public TMP_Text flowerStockText;
    public TMP_Text mushroomStockText;
    public TMP_Text crystalStockText;
    public TMP_Text leafStockText;

    public TMP_Text spiderStockText;
    public TMP_Text fireStockText;
    public TMP_Text moonStockText;
    public TMP_Text batStockText;

    [Header("References")]
    public PotionMakingManager potionManager;

    private void Start()
    {
        UpdateStockTexts();
    }

    public void UpdateStockTexts()
    {
        flowerStockText.text = potionManager.flowerStock.ToString();
        mushroomStockText.text = potionManager.mushroomStock.ToString();
        crystalStockText.text = potionManager.crystalStock.ToString();
        leafStockText.text = potionManager.leafStock.ToString();

        spiderStockText.text = potionManager.spiderStock.ToString();
        fireStockText.text = potionManager.fireStock.ToString();
        moonStockText.text = potionManager.moonStock.ToString();
        batStockText.text = potionManager.batStock.ToString();
    }

    public void BuyStock(string ingredientName)
    {
        if (ingredientName == "Flower" && potionManager.gold >= 2)
        {
            potionManager.gold -= 2;
            potionManager.flowerStock++;
        }
        else if (ingredientName == "Mushroom" && potionManager.gold >= 2)
        {
            potionManager.gold -= 2;
            potionManager.mushroomStock++;
        }
        else if (ingredientName == "Leaf" && potionManager.gold >= 2)
        {
            potionManager.gold -= 2;
            potionManager.leafStock++;
        }
        else if (ingredientName == "Crystal" && potionManager.gold >= 3)
        {
            potionManager.gold -= 3;
            potionManager.crystalStock++;
        }
        else if (ingredientName == "Spider" && potionManager.gold >= 4)
        {
            potionManager.gold -= 4;
            potionManager.spiderStock++;
        }
        else if (ingredientName == "Fire" && potionManager.gold >= 5)
        {
            potionManager.gold -= 5;
            potionManager.fireStock++;
        }
        else if (ingredientName == "Moon" && potionManager.gold >= 6)
        {
            potionManager.gold -= 6;
            potionManager.moonStock++;
        }
        else if (ingredientName == "Bat" && potionManager.gold >= 7)
        {
            potionManager.gold -= 7;
            potionManager.batStock++;
        }

        potionManager.goldText.text = potionManager.gold.ToString();

        potionManager.UpdateStockTexts();
    }
}