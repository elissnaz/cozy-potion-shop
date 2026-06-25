using UnityEngine;
using System.Collections;
using TMPro;

public class DayManager : MonoBehaviour
{
    [Header("Main Objects")]
    public GameObject customerImage;
    public GameObject orderPanel;

    [Header("Buttons")]
    public GameObject startDayButton;
    public GameObject shopButton;

    [Header("Panels")]
    public GameObject customerPanel;
    public GameObject stockPanel;
    public GameObject cauldronPanel;

    [Header("Managers")]
    public CustomerOrderManager customerOrderManager;

    [Header("Day Settings")]
    public TMP_Text dayText;
    public int customerCount = 0;
    public int customersPerDay = 3;
    public int currentDay = 1;
    public int maxDay = 3;

    [Header("Fade Transition")]
    public CanvasGroup transitionGroup;
    public float fadeDuration = 0.6f;

    private void Start()
    {
        UpdateDayText();
    }

    public void StartDay()
    {
        StartCoroutine(StartDayFade());
    }

    private IEnumerator StartDayFade()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        customerCount = 0;

        startDayButton.SetActive(false);
        shopButton.SetActive(false);

        customerImage.SetActive(true);
        orderPanel.SetActive(true);

        customerOrderManager.NewCustomer();

        yield return StartCoroutine(Fade(1f, 0f));
    }

    public void OpenStockPanel()
    {
        StartCoroutine(OpenStockPanelFade());
    }

    private IEnumerator OpenStockPanelFade()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        customerPanel.SetActive(false);
        stockPanel.SetActive(true);

        yield return StartCoroutine(Fade(1f, 0f));
    }

    public void CloseStockPanel()
    {
        StartCoroutine(CloseStockPanelFade());
    }

    private IEnumerator CloseStockPanelFade()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        stockPanel.SetActive(false);
        customerPanel.SetActive(true);

        startDayButton.SetActive(true);
        shopButton.SetActive(true);

        customerImage.SetActive(false);
        orderPanel.SetActive(false);

        yield return StartCoroutine(Fade(1f, 0f));
    }

    public void CustomerFinished()
    {
        customerCount++;

        if (customerCount >= customersPerDay)
        {
            EndDay();
        }
        else
        {
            customerOrderManager.NewCustomer();
        }
    }

    public void EndDay()
    {
        StartCoroutine(EndDayFade());
    }

    private IEnumerator EndDayFade()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        customerImage.SetActive(false);
        orderPanel.SetActive(false);

        currentDay++;

        if (currentDay > maxDay)
        {
            Debug.Log("Game Finished!");
            currentDay = maxDay;
        }

        UpdateDayText();

        startDayButton.SetActive(true);
        shopButton.SetActive(true);

        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float start, float end)
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            transitionGroup.alpha = Mathf.Lerp(start, end, t / fadeDuration);

            yield return null;
        }

        transitionGroup.alpha = end;
    }

    private void UpdateDayText()
    {
        dayText.text = "DAY " + currentDay;
    }
}