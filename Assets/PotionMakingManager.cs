using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionMakingManager : MonoBehaviour
{
    [Header("Managers")]
    public DayManager dayManager;
    public CustomerOrderManager customerOrderManager;

    [Header("Panels")]
    public GameObject cauldronPanel;
    public GameObject customerPanel;

    [Header("Buttons")]
    public GameObject acceptButton;
    public GameObject rejectButton;
    public GameObject readyButton;

    [Header("Texts")]
    public TextMeshProUGUI orderText;
    public TextMeshProUGUI goldText;
    public TMP_Text addedText;

    [Header("Bottle System")]
    public Image bottleImage;

    public Sprite emptyBottle;
    public Sprite bluePotion;
    public Sprite pinkPotion;
    public Sprite purplePotion;
    public Sprite blackPotion;
    public Sprite orangePotion;
    public Sprite yellowPotion;
    public Sprite greenPotion;
    public Sprite darkPurplePotion;

    [Header("Ingredient Buttons")]
    public Button flowerButton;
    public Button mushroomButton;
    public Button crystalButton;
    public Button leafButton;
    public Button spiderButton;
    public Button fireButton;
    public Button moonButton;
    public Button batButton;

    private string selectedIngredient = "";
    private Button selectedButton;

    private int flowerCount = 0;
    private int mushroomCount = 0;
    private int crystalCount = 0;
    private int leafCount = 0;
    private int spiderCount = 0;
    private int fireCount = 0;
    private int moonCount = 0;
    private int batCount = 0;

    [Header("Ingredient Stock")]
    public int flowerStock = 8;
    public int mushroomStock = 8;
    public int crystalStock = 8;
    public int leafStock = 8;

    public int spiderStock = 2;
    public int fireStock = 2;
    public int moonStock = 2;
    public int batStock = 2;

    [Header("Stock Texts")]
    public TMP_Text flowerStockText;
    public TMP_Text mushroomStockText;
    public TMP_Text crystalStockText;
    public TMP_Text leafStockText;
    public TMP_Text spiderStockText;
    public TMP_Text fireStockText;
    public TMP_Text moonStockText;
    public TMP_Text batStockText;

    [Header("Stock Panel Texts")]
    public TMP_Text stockPanelFlowerText;
    public TMP_Text stockPanelMushroomText;
    public TMP_Text stockPanelCrystalText;
    public TMP_Text stockPanelLeafText;
    public TMP_Text stockPanelSpiderText;
    public TMP_Text stockPanelFireText;
    public TMP_Text stockPanelMoonText;
    public TMP_Text stockPanelBatText;

    public int gold = 30;

    public PotionType requestedPotion;
    public PotionType createdPotion;
    public PotionResult currentPotionResult;

    public enum PotionType
    {
        Sleeping,
        Love,
        Luck,
        Healing,
        Speed,
        Strength,
        Invisibility,
        Black
    }

    public enum PotionResult
    {
        Correct,
        Wrong,
        Black
    }

    private void Start()
    {
        bottleImage.sprite = emptyBottle;
        readyButton.SetActive(false);

        goldText.text = gold.ToString();

        UpdateStockTexts();
    }

    //mlz secilir
    public void SelectIngredient(string ingredientName)
    {
        selectedIngredient = ingredientName;

        if (selectedButton != null)
        {
            selectedButton.transform.localScale = Vector3.one;
        }

        if (ingredientName == "Flower")
            selectedButton = flowerButton;
        else if (ingredientName == "Mushroom")
            selectedButton = mushroomButton;
        else if (ingredientName == "Crystal")
            selectedButton = crystalButton;
        else if (ingredientName == "Leaf")
            selectedButton = leafButton;
        else if (ingredientName == "Spider")
            selectedButton = spiderButton;
        else if (ingredientName == "Fire")
            selectedButton = fireButton;
        else if (ingredientName == "Moon")
            selectedButton = moonButton;
        else if (ingredientName == "Bat")
            selectedButton = batButton;

        selectedButton.transform.localScale = new Vector3(1.15f, 1.15f, 1f);
    }

    //kazana ekler
    public void AddToCauldron()
    {
        if (selectedIngredient == "")
        {
            addedText.text = "Select an ingredient first.";
            return;
        }

        if (selectedIngredient == "Flower")
        {
            if (flowerStock <= 0)
            {
                addedText.text = "No Flower left!";
                return;
            }

            flowerStock--;
            flowerCount++;
        }
        else if (selectedIngredient == "Mushroom")
        {
            if (mushroomStock <= 0)
            {
                addedText.text = "No Mushroom left!";
                return;
            }

            mushroomStock--;
            mushroomCount++;
        }
        else if (selectedIngredient == "Crystal")
        {
            if (crystalStock <= 0)
            {
                addedText.text = "No Crystal left!";
                return;
            }

            crystalStock--;
            crystalCount++;
        }
        else if (selectedIngredient == "Leaf")
        {
            if (leafStock <= 0)
            {
                addedText.text = "No Leaf left!";
                return;
            }

            leafStock--;
            leafCount++;
        }
        else if (selectedIngredient == "Spider")
        {
            if (spiderStock <= 0)
            {
                addedText.text = "No Spider Silk left!";
                return;
            }

            spiderStock--;
            spiderCount++;
        }
        else if (selectedIngredient == "Fire")
        {
            if (fireStock <= 0)
            {
                addedText.text = "No Fire Dust left!";
                return;
            }

            fireStock--;
            fireCount++;
        }
        else if (selectedIngredient == "Moon")
        {
            if (moonStock <= 0)
            {
                addedText.text = "No Moon Stone left!";
                return;
            }

            moonStock--;
            moonCount++;
        }
        else if (selectedIngredient == "Bat")
        {
            if (batStock <= 0)
            {
                addedText.text = "No Bat Wing left!";
                return;
            }

            batStock--;
            batCount++;
        }

        UpdateStockTexts();
    }

    //iksir oluþturur
    public void BrewPotion()
    {
        if (crystalCount == 2 &&
            leafCount == 1 &&
            mushroomCount == 1)
        {
            bottleImage.sprite = bluePotion;
            addedText.text = "Sleeping Potion created!";
            createdPotion = PotionType.Sleeping;
        }
        else if (flowerCount == 3 &&
                 crystalCount == 2 &&
                 mushroomCount == 1)
        {
            bottleImage.sprite = pinkPotion;
            addedText.text = "Love Potion created!";
            createdPotion = PotionType.Love;
        }
        else if (mushroomCount == 2 &&
                 leafCount == 1 &&
                 flowerCount == 1)
        {
            bottleImage.sprite = purplePotion;
            addedText.text = "Luck Potion created!";
            createdPotion = PotionType.Luck;
        }
        else if (leafCount == 3 &&
                 flowerCount == 2 &&
                 crystalCount == 1)
        {
            bottleImage.sprite = greenPotion;
            addedText.text = "Healing Potion created!";
            createdPotion = PotionType.Healing;
        }
        else if (fireCount == 3 &&
                 crystalCount == 2)
        {
            bottleImage.sprite = orangePotion;
            addedText.text = "Speed Potion created!";
            createdPotion = PotionType.Speed;
        }
        else if (spiderCount == 2 &&
                 fireCount == 1 &&
                 mushroomCount == 2)
        {
            bottleImage.sprite = yellowPotion;
            addedText.text = "Strength Potion created!";
            createdPotion = PotionType.Strength;
        }
        else if (moonCount == 2 &&
                 batCount == 3 &&
                 crystalCount == 1)
        {
            bottleImage.sprite = darkPurplePotion;
            addedText.text = "Invisibility Potion created!";
            createdPotion = PotionType.Invisibility;
        }
        else
        {
            bottleImage.sprite = blackPotion;
            addedText.text = "Failed Potion!";
            createdPotion = PotionType.Black;
        }

        CheckPotionResult();
    }

    public void CheckPotionResult()
    {
        if (createdPotion == PotionType.Black)
        {
            SetPotionResult(false, true);
        }
        else if (createdPotion == requestedPotion)
        {
            SetPotionResult(true, false);
        }
        else
        {
            SetPotionResult(false, false);
        }
    }

    public void SetPotionResult(bool isCorrect, bool isBlack)
    {
        if (isBlack)
            currentPotionResult = PotionResult.Black;
        else if (isCorrect)
            currentPotionResult = PotionResult.Correct;
        else
            currentPotionResult = PotionResult.Wrong;

        readyButton.SetActive(true);
    }

    public void OnReadyButtonClicked()
    {
        cauldronPanel.SetActive(false);
        customerPanel.SetActive(true);

        GiveCustomerReaction();
    }

    public void GiveCustomerReaction()
    {
        customerOrderManager.ShowReactionPanel();

        if (currentPotionResult == PotionResult.Correct)
        {
            SoundManager.instance.PlayCorrect();
            orderText.text = "Perfect! This potion is exactly what I wanted!";

            if (requestedPotion == PotionType.Sleeping)
                gold += 18;
            else if (requestedPotion == PotionType.Love)
                gold += 20;
            else if (requestedPotion == PotionType.Luck)
                gold += 20;
            else if (requestedPotion == PotionType.Healing)
                gold += 22;
            else if (requestedPotion == PotionType.Speed)
                gold += 28;
            else if (requestedPotion == PotionType.Strength)
                gold += 30;
            else if (requestedPotion == PotionType.Invisibility)
                gold += 32;
        }
        else if (currentPotionResult == PotionResult.Wrong)
        {
            SoundManager.instance.PlayWrong();
            orderText.text = "Hmm... This is not what I asked for, but okay.";
            gold += 8;
        }
        else if (currentPotionResult == PotionResult.Black)
        {
            SoundManager.instance.PlayPoison();
            orderText.text = "Ew! What is this?!";
            gold -= 5;

            if (gold < 0)
                gold = 0;
        }

        goldText.text = gold.ToString();

        Invoke("BringNewCustomer", 3f);
    }

    public void BringNewCustomer()
    {
        StartCoroutine(BringNewCustomerAfterPanelClose());
    }

    private IEnumerator BringNewCustomerAfterPanelClose()
    {
        customerOrderManager.orderPanelAnimation.ClosePanel();

        yield return new WaitForSeconds(0.4f);

        yield return StartCoroutine(customerOrderManager.CustomerLeaveAnimation());

        ResetPotionStation();

        customerPanel.SetActive(true);
        cauldronPanel.SetActive(false);

        dayManager.CustomerFinished();
    }

    public void NewCustomer()
    {
        bottleImage.sprite = emptyBottle;
        readyButton.SetActive(false);

        flowerCount = 0;
        mushroomCount = 0;
        crystalCount = 0;
        leafCount = 0;
        spiderCount = 0;
        fireCount = 0;
        moonCount = 0;
        batCount = 0;

        requestedPotion = (PotionType)Random.Range(0, 7);

        if (requestedPotion == PotionType.Sleeping)
            orderText.text = "I want a Sleeping Potion.";
        else if (requestedPotion == PotionType.Love)
            orderText.text = "I want a Love Potion.";
        else if (requestedPotion == PotionType.Luck)
            orderText.text = "I want a Luck Potion.";
        else if (requestedPotion == PotionType.Healing)
            orderText.text = "I want a Healing Potion.";
        else if (requestedPotion == PotionType.Speed)
            orderText.text = "I want a Speed Potion.";
        else if (requestedPotion == PotionType.Strength)
            orderText.text = "I want a Strength Potion.";
        else if (requestedPotion == PotionType.Invisibility)
            orderText.text = "I want an Invisibility Potion.";

        addedText.text = "";
    }

    public void ResetPotionStation()
    {
        bottleImage.sprite = emptyBottle;
        readyButton.SetActive(false);

        flowerCount = 0;
        mushroomCount = 0;
        crystalCount = 0;
        leafCount = 0;
        spiderCount = 0;
        fireCount = 0;
        moonCount = 0;
        batCount = 0;

        selectedIngredient = "";

        if (selectedButton != null)
        {
            selectedButton.transform.localScale = Vector3.one;
            selectedButton = null;
        }

        addedText.text = "";
    }

    public void UpdateStockTexts()
    {
        if (flowerStockText != null)
            flowerStockText.text = flowerStock.ToString();

        if (mushroomStockText != null)
            mushroomStockText.text = mushroomStock.ToString();

        if (crystalStockText != null)
            crystalStockText.text = crystalStock.ToString();

        if (leafStockText != null)
            leafStockText.text = leafStock.ToString();

        if (spiderStockText != null)
            spiderStockText.text = spiderStock.ToString();

        if (fireStockText != null)
            fireStockText.text = fireStock.ToString();

        if (moonStockText != null)
            moonStockText.text = moonStock.ToString();

        if (batStockText != null)
            batStockText.text = batStock.ToString();

        if (stockPanelSpiderText != null)
            stockPanelSpiderText.text = spiderStock.ToString();

        if (stockPanelFireText != null)
            stockPanelFireText.text = fireStock.ToString();

        if (stockPanelMoonText != null)
            stockPanelMoonText.text = moonStock.ToString();

        if (stockPanelBatText != null)
            stockPanelBatText.text = batStock.ToString();

        if (stockPanelFlowerText != null)
            stockPanelFlowerText.text = flowerStock.ToString();

        if (stockPanelMushroomText != null)
            stockPanelMushroomText.text = mushroomStock.ToString();

        if (stockPanelCrystalText != null)
            stockPanelCrystalText.text = crystalStock.ToString();

        if (stockPanelLeafText != null)
            stockPanelLeafText.text = leafStock.ToString();
    }
}