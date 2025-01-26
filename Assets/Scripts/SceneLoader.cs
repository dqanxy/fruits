using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private int levelDied = 1;

    public static SceneLoader Instance { get; private set; }
    private void Awake()
    {
        CreateSceneLoader();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RetryLevel()
    {
        Debug.Log("Restarting Level" + levelDied);
        SceneManager.LoadScene("Level" + levelDied);
        //switch (levelDied)
        //{
        //    case 1:
        //        SceneManager.LoadScene("Level1");
        //        break;

        //    case 2:
        //        SceneManager.LoadScene("Level2");
        //        break;

        //    case 3:
        //        SceneManager.LoadScene("Level3");
        //        break;

        //}
    }

    public void SetLevelDied(int level)
    {
        levelDied = level;
    }

    public void Win()
    {
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                SceneManager.LoadScene("TheCutscene");
                break;
            default:
                Debug.LogWarning("No next level defined!");
                break;
        }
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
