using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
