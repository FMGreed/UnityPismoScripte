using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_level : MonoBehaviour {

    public string levelToLoad = "MainMenu";

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
