using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Sound Effects")]
    public AudioClip selectSound;
    public AudioClip ingredientSelectSound;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip poisonSound;
    public AudioClip potionCreateSound;
    public AudioClip clickSound;
    public AudioClip bobSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClick()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }

    public void PlayPop()
    {
        if (bobSound != null)
            audioSource.PlayOneShot(bobSound);
    }

    public void PlaySelect()
    {
        if (selectSound != null)
            audioSource.PlayOneShot(selectSound);
    }

    public void PlayIngredientSelect()
    {
        if (ingredientSelectSound != null)
            audioSource.PlayOneShot(ingredientSelectSound);
    }

    public void PlayCorrect()
    {
        if (correctSound != null)
            audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrong()
    {
        if (wrongSound != null)
            audioSource.PlayOneShot(wrongSound);
    }

    public void PlayPoison()
    {
        if (poisonSound != null)
            audioSource.PlayOneShot(poisonSound);
    }

    public void PlayPotionCreate()
    {
        if (potionCreateSound != null)
            audioSource.PlayOneShot(potionCreateSound, 0.3f);
    }
}