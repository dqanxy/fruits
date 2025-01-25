using System.Collections;
using System.Threading;
using UnityEngine;

public class LazerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool spawn = false;
    public bool fire = false;
    public bool kill = false;

    float veloBase = 120;
    float velo = 60;

    Coroutine spawnCoro;
    Coroutine fireCoro;
    Coroutine killCoro;

    bool hasSpawned = false;
    bool hasFire = false;
    bool hasKilled = false;

    float scale = 1f;
    float lazerScale = 1.3f;

    [SerializeField] GameObject lazer;
    void Start()
    {
        lazer.transform.localScale = new Vector3(0, 50, 0);
        scale = transform.localScale.x;
        transform.localScale = Vector3.zero;
    }



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, velo * Time.deltaTime, 0));
        if (!hasSpawned && spawn)
        {
            hasSpawned = true;
            spawnCoro = StartCoroutine(Spawn());
        }
        if (!hasFire && fire)
        {
            hasFire = true;
            fireCoro = StartCoroutine(Fire());
        }
        if (!hasKilled && kill)
        {
            hasKilled = true;
            killCoro = StartCoroutine(Kill());
        }
    }

    IEnumerator Spawn()
    {
        float timer1 = 0f;
        while (timer1 < 1f)
        {
            timer1 += Time.deltaTime;
            transform.localScale = scale * Vector3.one * (timer1 / 1f);
            velo = Mathf.Lerp(5 * veloBase, veloBase, timer1 / 1f);
            yield return null;
        }
        transform.localScale = scale * Vector3.one;
        velo = veloBase;
    }
    IEnumerator Kill()
    {
        float timer1 = 0f;
        float veloB = velo;
        float lazerBase = lazer.transform.localScale.x;
        while (timer1 < .75f)
        {
            timer1 += Time.deltaTime;
            lazer.transform.localScale = new Vector3(lazerBase * (1-(timer1 / .75f)), 50f, lazerBase * (1 - (timer1 / .75f)));
            velo = Mathf.Lerp(veloB, 0 , timer1 / .75f);
            yield return null;
        }


        timer1 = 0f;
        while (timer1 < .5f)
        {
            timer1 += Time.deltaTime;
            transform.localScale = scale * Vector3.one * (1-(timer1 / .5f));
            yield return null;
        }

        transform.localScale = Vector3.zero;
        velo = veloBase;
    }



    IEnumerator Fire()
    {
        float timer1 = 0f;
        while (timer1 < 1f)
        {
            timer1 += Time.deltaTime;
            velo = Mathf.Lerp(veloBase, 5 * veloBase, timer1 / 1f);
            yield return null;
        }

        float timer2 = 0f;
        while (timer2 < .15f)
        {
            timer2 += Time.deltaTime;
            lazer.transform.localScale = lazerScale * new Vector3(timer2/.15f, 50f / lazerScale, timer2/.15f);
            velo = Mathf.Lerp(5 * veloBase, 8 * veloBase, timer2 / .15f);
            yield return null;
        }

        float timer3 = 0f;
        while(timer3 < .5f)
        {
            timer3 += Time.deltaTime;
            yield return null;
        }

        float timer4 = 0f;
        while (timer4 < 2f)
        {
            timer4 += Time.deltaTime;
            lazer.transform.localScale = lazerScale * new Vector3(1 + timer4 / 2f, 50f / lazerScale, 1 + timer4 / 2f);
            yield return null;
        }
    }
}
