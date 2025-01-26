using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void RetryLevel()
    {
        SceneLoader.Instance.RetryLevel();
    }
}
