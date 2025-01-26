using System.Collections;
using UnityEngine;

public class OscMotion : MonoBehaviour
{
    public float maxDist;
    public float periodDividend;
    public float initialDelay;
    public bool vertical = false;


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
            if (vertical)
            {
                transform.position = new Vector3(transform.position.x, start.y + Mathf.Sin((Time.time - startTime) / periodDividend) * maxDist);
            }
            else
            {
                transform.position = new Vector3(start.x + Mathf.Sin((Time.time - startTime) / periodDividend) * maxDist, transform.position.y);
            }
            yield return null;
        }
    }
}
