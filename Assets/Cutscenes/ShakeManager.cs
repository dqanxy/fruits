using System.Collections;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private static Coroutine shakeCoro;
    public static ShakeManager instance;

    public bool isShake = false;
    public GameObject shakeObject;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void EndShake() { instance._EndShake(); }
    public static void BeginShakeFlashback() { instance._BeginShakeFlashback(); }

    public static void BeginShake(float time, float amtB, float amtE)
    {
        instance._BeginShake(time, amtB, amtE);
    }
    public void _BeginShake(float t, float b, float e)
    {
        if (shakeCoro != null)
        {
            StopCoroutine(shakeCoro);
        }
        shakeCoro = StartCoroutine(Shake(t,b,e));
    }

    public void _BeginShakeFlashback()
    {
        if(shakeCoro != null)
        {
            StopCoroutine(shakeCoro);
        }
        shakeCoro = StartCoroutine(ShakeFlashback());
    }
    public void _EndShake()
    {
        StopCoroutine(shakeCoro);
    }

    IEnumerator Shake(float time, float amtB, float amtE)
    {
        Vector3 currentOffset = Vector3.zero;
        float timer = 0;
        while(timer < time)
        {
            timer += Time.deltaTime;
            Vector3 newOffset = Random.insideUnitSphere * Mathf.Lerp(amtB, amtE, timer / time);
            MoveCamera(newOffset - currentOffset);
            currentOffset = newOffset;
            yield return null;
        }
        MoveCamera(Vector3.zero - currentOffset);
    }

    void MoveCamera(Vector3 offset)
    {
        foreach (var item in FindObjectsOfType<Camera>())
        {
            item.transform.position += offset;
        }
    }

    void MoveObject(Vector3 offset)
    {
        shakeObject.transform.position += offset;
    }

    IEnumerator ShakeFlashback()
    {
        float delay = .2f;
        Vector3 offset = Vector3.up * -100f;
        Vector3 offsetL = Vector3.left * -50f;
        int counter = 2;

        while (true)
        {
            float rand = Random.Range(0.0f, 1.0f);
            if(rand < 0.3f)
            {
                yield return new WaitForSeconds(delay);
            }
            if (rand >= 0.3f && rand < .75f && counter >= 0)
            {
                MoveObject(-offset);
                yield return new WaitForSeconds(.03f);
                MoveObject(offset);
                yield return new WaitForSeconds(delay);
                counter--; 
            }
            if (rand >= .75f)
            {
                MoveObject(-offsetL);
                yield return new WaitForSeconds(.03f);
                MoveObject(offsetL);
                yield return new WaitForSeconds(delay);
                counter = 2;
            }

            delay = Random.Range(.15f, .25f);
        }
    }

}
