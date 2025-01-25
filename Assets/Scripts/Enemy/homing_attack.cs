using UnityEngine;
using System.Collections;

public class homing_attack : MonoBehaviour
{

    private IEnumerator coroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coroutine = HomingAttack();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HomingAttack()
    {
        yield return new WaitForSeconds(5);
        gameObject.transform.position = PlayerController.transform.position();
    }
}
