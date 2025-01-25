using System.Collections;
using UnityEngine;

public class OscMotion : MonoBehaviour
{
    public float maxDist;
    public float periodDividend;

    private Vector3 start;
    private float startTime;

    void Start()
    {
        start = transform.position;
        startTime = Time.time;
        StartCoroutine(OscCoroutine());
    }


    private IEnumerator OscCoroutine()
    {
        while (true)
        {
            transform.position = start + new Vector3(Mathf.Sin((Time.time - startTime) / periodDividend) * maxDist, 0.0f);
            yield return null;
        }
    }
}
