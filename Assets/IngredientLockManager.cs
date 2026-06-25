using UnityEngine;
using UnityEngine.UI;

public class IngredientLockManager : MonoBehaviour
{
    [System.Serializable]
    public class IngredientButton
    {
        public Image ingredientImage;
        public GameObject cauldronLockIcon;
        public GameObject stockTextObject;
        public string ingredientName;

        public Button plusButton;
        public Button lockButton;
        public GameObject lockButtonObject;

        public bool isUnlocked;
        public int unlockPrice;
    }

    [Header("References")]
    public PotionMakingManager potionMakingManager;

    [Header("Ingredients")]
    public IngredientButton[] ingredients;

    private void Start()
    {
        UpdateAllButtons();
    }

    public void UpdateAllButtons()
    {
        foreach (IngredientButton item in ingredients)
        {
            item.plusButton.interactable = item.isUnlocked;

            if (item.lockButtonObject != null)
                item.lockButtonObject.SetActive(!item.isUnlocked);

            if (item.cauldronLockIcon != null)
                item.cauldronLockIcon.SetActive(!item.isUnlocked);

            if (item.stockTextObject != null)
                item.stockTextObject.SetActive(item.isUnlocked);

            if (item.plusButton != null && item.plusButton.image != null)
            {
                Color color = item.plusButton.image.color;
                color.a = item.isUnlocked ? 1f : 0.35f;
                item.plusButton.image.color = color;
            }

            if (item.ingredientImage != null)
            {
                Color color = item.ingredientImage.color;
                color.a = item.isUnlocked ? 1f : 0.35f;
                item.ingredientImage.color = color;
            }
        }
    }

    public void UnlockIngredient(int index)
    {
        IngredientButton item = ingredients[index];

        if (item.isUnlocked)
            return;

        if (potionMakingManager.gold < item.unlockPrice)
        {
            Debug.Log("Yeterli altýn yok!");
            return;
        }

        potionMakingManager.gold -= item.unlockPrice;

        item.isUnlocked = true;

        if (item.ingredientName == "Spider")
            potionMakingManager.spiderStock = 2;
        else if (item.ingredientName == "Fire")
            potionMakingManager.fireStock = 2;
        else if (item.ingredientName == "Moon")
            potionMakingManager.moonStock = 2;
        else if (item.ingredientName == "Bat")
            potionMakingManager.batStock = 2;

        potionMakingManager.goldText.text = potionMakingManager.gold.ToString();

        potionMakingManager.UpdateStockTexts();
        UpdateAllButtons();
    }
}