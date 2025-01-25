using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBeforePlayAudio : MonoBehaviour
{
    public bool temp = true;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 && timer > -1000)
        {
            timer = -10000;
            if (temp) { 
                GetComponent<AudioSource>().time = 1f;
            }
            GetComponent<AudioSource>().Play();
        }
    }
}
