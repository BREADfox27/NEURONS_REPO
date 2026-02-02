using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject loreMenu;

    private void Start()
    {
        controlsMenu.gameObject.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("EyeScene");
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        controlsMenu.gameObject.SetActive(true);
    }

    public void Lore()
    {
        loreMenu.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        loreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You quited the game.");
    }
}
