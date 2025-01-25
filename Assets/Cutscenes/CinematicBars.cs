using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBars : MonoBehaviour
{
    public GameObject top;
    public GameObject bot;

    Vector3 t_origin;
    Vector3 b_origin;

    Coroutine moveCoro;

    public bool open = false;
    bool cur = false;

    private static CinematicBars instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        t_origin = top.transform.position;
        b_origin = bot.transform.position;

    }

    // Update is called once per frame\
    void Update()
    {
        if(cur != open)
        {
            cur = open;
            if (cur)
            {
                Begin();
            }
            else
            {
                End();
            }
        }
    }

    IEnumerator MoveToPosition(float offset)
    {
        float timer = 4f;
        float currentOffset = bot.transform.position.y - b_origin.y;

        while (timer > 0)
        {
            currentOffset = currentOffset * .98f + offset * .02f;
            MoveToOffset(currentOffset);
            timer -= Time.deltaTime;
            yield return null;
        }
        MoveToOffset(offset);
    }

    void MoveToOffset(float offset)
    {
        top.transform.position = t_origin + Vector3.down * offset;
        bot.transform.position = b_origin + Vector3.up * offset;
    }

    public static void Begin()
    {
        instance.Begin_();
    }
    public static void End()
    {
        instance.End_();
    }


    public void Begin_()
    {
        if (moveCoro != null)
        {
            StopCoroutine(moveCoro);
        }
        moveCoro = StartCoroutine(MoveToPosition(75));
    }

    public void End_()
    {
        if (moveCoro != null)
        {
            StopCoroutine(moveCoro);
        }
        moveCoro = StartCoroutine(MoveToPosition(0));
    }
    public void EndInstant()
    {
        if (moveCoro != null)
        {
            StopCoroutine(moveCoro);
        }
        MoveToOffset(0);

    }
}
