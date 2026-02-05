using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject loreMenu;

    private void Start()
    {
        controlsMenu.gameObject.SetActive(false);
        loreMenu.gameObject.SetActive(false);
    }

    public void Play()
    {
        AudioManager.Instance.PlaySFX(5);
        SceneManager.LoadScene("EyeScene");
    }

    public void Return()
    {
        AudioManager.Instance.PlaySFX(5);
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        AudioManager.Instance.PlaySFX(5);
        controlsMenu.gameObject.SetActive(true);
    }

    public void Lore()
    {
        AudioManager.Instance.PlaySFX(5);
        loreMenu.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        AudioManager.Instance.PlaySFX(5);
        loreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
    }

    public void Exit()
    {
        AudioManager.Instance.PlaySFX(5);
        Application.Quit();
        Debug.Log("You quited the game.");
    }
}
