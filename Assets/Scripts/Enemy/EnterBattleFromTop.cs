using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnterBattleFromTop : MonoBehaviour
{
    public float deltaY;
    public float enterTime;

    private Vector3 start;
    private float startTime;

    void Start()
    {
        start = transform.position;
        startTime = Time.time;
        StartCoroutine(EnterCoroutine());
    }


    private IEnumerator EnterCoroutine()
    {
        while (Time.time < startTime + enterTime)
        {
            Debug.Log("AMONG US!" + transform.position.y);
            transform.position = transform.position + new Vector3(0, deltaY * Time.deltaTime, 0.0f);
            Debug.Log("SUSSUS!" + transform.position.y);
            yield return null;
        }
    }
}
