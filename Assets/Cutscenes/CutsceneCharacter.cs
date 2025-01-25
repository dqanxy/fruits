using UnityEngine;

public class CutsceneCharacter : MonoBehaviour
{

    public GameObject[] models;

    public int isSet = 0; //0 un, 1 = winner, 2 = loser

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(int i)
    {
        for (int j = 0; j < models.Length; j++)
        {
            models[j].gameObject.SetActive(false);
        }
        models[i].gameObject.SetActive(true);
    }
}
