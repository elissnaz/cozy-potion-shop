using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CustomerOrderManager : MonoBehaviour
{
    [System.Serializable]
    public class PotionOrder
    {
        public string orderText;
        public PotionMakingManager.PotionType potionType;
    }

    [Header("Managers")]
    public PotionMakingManager potionMakingManager;
    public OrderPanelAnimation orderPanelAnimation;

    [Header("Panels")]
    public GameObject customerPanel;
    public GameObject cauldronPanel;

    [Header("Fade Transition")]
    public CanvasGroup transitionGroup;
    public float fadeDuration = 0.6f;

    [Header("Order UI")]
    public GameObject orderTextObject;
    public GameObject acceptButton;
    public GameObject rejectButton;

    [Header("Customer Animation")]
    public RectTransform customerRect;
    public float startY = -500f;
    public float targetY = 50f;
    public float moveDuration = 0.8f;

    [Header("UI")]
    public Image customerImage;
    public TMP_Text orderText;

    [Header("Customer Sprites")]
    public Sprite[] customerSprites;

    [Header("Orders")]
    public PotionOrder[] orders;

    private string currentOrder;

    private IEnumerator Start()
    {
        yield return null;
        NewCustomer();
    }

    public void NewCustomer()
    {
        orderTextObject.SetActive(false);
        acceptButton.SetActive(false);
        rejectButton.SetActive(false);

        int randomCustomer = Random.Range(0, customerSprites.Length);
        customerImage.sprite = customerSprites[randomCustomer];

        int maxOrderCount = 4;

        if (potionMakingManager.dayManager.currentDay == 1)
        {
            maxOrderCount = 4;
        }
        else if (potionMakingManager.dayManager.currentDay == 2)
        {
            maxOrderCount = 6;
        }
        else if (potionMakingManager.dayManager.currentDay == 3)
        {
            maxOrderCount = 7;
        }

        int randomOrder = Random.Range(0, maxOrderCount);
        PotionOrder selectedOrder = orders[randomOrder];

        currentOrder = selectedOrder.orderText;
        orderText.text = currentOrder;

        potionMakingManager.requestedPotion = selectedOrder.potionType;

        StartCoroutine(CustomerComeAnimation());
    }

    public void AcceptOrder()
    {
        orderPanelAnimation.ClosePanel();
        StartCoroutine(GoToCauldronWithFade());
    }

    public void RejectOrder()
    {
        orderPanelAnimation.ClosePanel();
        StartCoroutine(RejectAndBringNew());
    }

    private IEnumerator CustomerComeAnimation()
    {
        Vector2 startPos = customerRect.anchoredPosition;
        startPos.y = startY;
        customerRect.anchoredPosition = startPos;

        Vector2 targetPos = customerRect.anchoredPosition;
        targetPos.y = targetY;

        float time = 0f;

        while (time < moveDuration)
        {
            time += Time.deltaTime;

            float t = time / moveDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            customerRect.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);

            yield return null;
        }

        customerRect.anchoredPosition = targetPos;

        orderPanelAnimation.OpenPanel();

        orderTextObject.SetActive(true);
        acceptButton.SetActive(true);
        rejectButton.SetActive(true);
    }

    private IEnumerator RejectAndBringNew()
    {
        acceptButton.SetActive(false);
        rejectButton.SetActive(false);
        orderTextObject.SetActive(false);

        yield return StartCoroutine(CustomerLeaveAnimation());

        NewCustomer();
    }

    private IEnumerator GoToCauldronWithFade()
    {
        transitionGroup.gameObject.SetActive(true);

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            transitionGroup.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            yield return null;
        }

        transitionGroup.alpha = 1f;

        customerPanel.SetActive(false);
        cauldronPanel.SetActive(true);

        time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            transitionGroup.alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            yield return null;
        }

        transitionGroup.alpha = 0f;
        transitionGroup.gameObject.SetActive(false);
    }

    public IEnumerator CustomerLeaveAnimation()
    {
        Vector2 startPos = customerRect.anchoredPosition;

        Vector2 targetPos = startPos;
        targetPos.y = startY;

        float time = 0f;

        while (time < moveDuration)
        {
            time += Time.deltaTime;

            float t = time / moveDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            customerRect.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);

            yield return null;
        }

        customerRect.anchoredPosition = targetPos;
    }

    public void ShowReactionText()
    {
        orderTextObject.SetActive(true);
        acceptButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    public void ShowReactionPanel()
    {
        orderPanelAnimation.OpenPanel();

        orderTextObject.SetActive(true);
        acceptButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    public void LeaveAndNewCustomer()
    {
        StartCoroutine(RejectAndBringNew());
    }
}