using UnityEngine;

public class MessageTester : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MessageBoxController.ShowMessage(new MessageData("fruits fruits fruits fruits fruits fruits", CharacterPortrait.Apple));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
