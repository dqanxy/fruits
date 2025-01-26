using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    public string mainGame;

    public void StartGame()
    {
        
        SceneManager.LoadScene(mainGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
