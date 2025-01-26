using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    private void Awake()
    {
        CreateSceneLoader();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void CreateSceneLoader()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
