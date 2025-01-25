using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System;

public class MessageBoxController : MonoBehaviour
{
    static MessageBoxController Instance;

    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public static void ShowMessage(MessageData messageData)
    {
        messageQueue.Enqueue(messageData);
        Instance.gameObject.SetActive(true);
    }

    static Queue<MessageData> messageQueue = new();

    bool showingMessage = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!showingMessage)
        {
            if(messageQueue.Count > 0)
            {
                StartCoroutine(showMessage(messageQueue.Dequeue()));
            } 
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    [SerializeField] Image portrait;
    [SerializeField] TMP_Text text;

    [SerializeField] float textDelay = 0.05f;

    //If this wasn't a gamejam I'd probably do a much better system
    [Header("Character Portraits")]
    [SerializeField] Sprite FacePortraitApple;


    Sprite getCharacterPortrait(CharacterPortrait portrait) => portrait switch
    {
        CharacterPortrait.Apple => FacePortraitApple,
        _ => null,
    };

    IEnumerator showMessage(MessageData messageData)
    {
        text.text = "";
        showingMessage = true;

        string msg = messageData.msg;

        int index = 0;

        while(index < msg.Length)
        {
            text.text += msg[index];
            yield return new WaitForSeconds(textDelay);
            index++;
        }
        yield return new WaitForSeconds(2.5f);
        showingMessage = false;
    }
}

public enum CharacterPortrait
{
    Apple,

}


public struct MessageData
{
    public CharacterPortrait characterPortrait;
    public string msg; 
    
    public MessageData(string _msg, CharacterPortrait _portrait)
    {
        msg = _msg;
        characterPortrait = _portrait;
    }
}
