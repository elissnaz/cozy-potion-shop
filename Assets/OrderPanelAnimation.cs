using UnityEngine;
using System.Collections;

public class OrderPanelAnimation : MonoBehaviour
{
    [Header("References")]
    public GameObject orderPanel;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = orderPanel.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = orderPanel.AddComponent<CanvasGroup>();

        orderPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        StopAllCoroutines();

        orderPanel.SetActive(true);

        StartCoroutine(OpenAnimation());
    }

    private IEnumerator OpenAnimation()
    {
        float duration = 0.35f;
        float time = 0f;

        orderPanel.transform.localScale = Vector3.zero;

        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;

            canvasGroup.alpha = t;

            float scale = Mathf.Lerp(0f, 1f, t);
            scale += Mathf.Sin(t * Mathf.PI) * 0.25f;

            orderPanel.transform.localScale =
                new Vector3(scale, scale, 1f);

            yield return null;
        }

        orderPanel.transform.localScale = Vector3.one;

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void ClosePanel()
    {
        StopAllCoroutines();

        StartCoroutine(CloseAnimation());
    }

    private IEnumerator CloseAnimation()
    {
        float duration = 0.35f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;

            canvasGroup.alpha = 1f - t;

            float scale = Mathf.Lerp(1f, 0f, t);
            scale += Mathf.Sin(t * Mathf.PI) * 0.25f;

            orderPanel.transform.localScale =
                new Vector3(scale, scale, 1f);

            yield return null;
        }

        orderPanel.transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0f;

        orderPanel.SetActive(false);
    }
}