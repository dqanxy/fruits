using UnityEngine;
using System.Collections;

public class homing_attack : MonoBehaviour
{
    private PlayerController player;
    private IEnumerator coroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        this.gameObject.transform.position = player.gameObject.transform.position;
    }
}
