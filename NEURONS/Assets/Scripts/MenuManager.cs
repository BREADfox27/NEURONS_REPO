using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("EyeScene");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You quited the game.");
    }
}
