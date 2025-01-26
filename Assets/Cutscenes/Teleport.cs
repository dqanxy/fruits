using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool teleport = false;
    public bool reappear = false;

    public bool fast = false;

    bool prevTele = false;
    bool prevReap = false;

    public Vector3 dir = Vector3.right;
    Vector3 init;
    Coroutine teleCoro;
    public GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reappear && !prevReap)
        {
            if (teleCoro != null)
            {
                obj.transform.localPosition = init;
                obj.SetActive(false);
                StopCoroutine(teleCoro);
            }
            StartCoroutine(ReappearCoro());
        }

        if (teleport && !prevTele)
        {
            teleCoro = StartCoroutine(TeleportCoro());
        }

        prevTele = teleport;
        prevReap = reappear;
        
    }

    IEnumerator TeleportCoro()
    {
        init = obj.transform.localPosition;
        float timer = 0f;
        bool left = false;
        while (timer < 1f)
        {
            left = !left;
            timer += Time.deltaTime * (fast ? 2 : 1);
            obj.transform.localPosition = init + (left ? dir * timer : -dir * timer) ;
            yield return null;
        }

        obj.transform.localPosition = init;

        obj.SetActive(false);
    }

    IEnumerator ReappearCoro()
    {
        yield return new WaitForSeconds(.02f);

        obj.SetActive(true);
        yield return new WaitForSeconds(.03f);
        obj.SetActive(false);
        yield return new WaitForSeconds(.03f);
        obj.SetActive(true);
        yield return new WaitForSeconds(.03f);
        obj.SetActive(false);
        yield return new WaitForSeconds(.03f);
        obj.SetActive(true);
    }
}
