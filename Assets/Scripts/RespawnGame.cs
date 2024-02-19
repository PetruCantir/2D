using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private int SceneNumber = 0;
    public void Level()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNumber);
    }
}