using UnityEngine;

public class RecipeBookUI : MonoBehaviour
{
    public GameObject recipeBookPanel;
    public GameObject bookButton;

    public void OpenBook()
    {
        recipeBookPanel.SetActive(true);
        bookButton.SetActive(false);
    }

    public void CloseBook()
    {
        recipeBookPanel.SetActive(false);
        bookButton.SetActive(true);
    }
}