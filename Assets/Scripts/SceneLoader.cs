using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
