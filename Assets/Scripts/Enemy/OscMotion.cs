using System.Collections;
using UnityEngine;

public class OscMotion : MonoBehaviour
{
    public float maxDist;
    public float periodDividend;
    public float initialDelay;

    private Vector3 start;
    private float startTime;

    void Start()
    {
        StartCoroutine(OscCoroutine());
    }


    private IEnumerator OscCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);
        start = transform.position;
        startTime = Time.time;
        while (true)
        {
            transform.position = start + new Vector3(Mathf.Sin((Time.time - startTime) / periodDividend) * maxDist, 0.0f);
            yield return null;
        }
    }
}
