using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneAnimateCar : MonoBehaviour
{
    float timer;
    Vector3 rotateOffset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Vector3 newRotateOffset = new Vector3(rotateOffset.x, Mathf.Sign(Mathf.Sin(timer * 2f)) * 5f *Mathf.Sqrt(Mathf.Abs(Mathf.Sin(timer*2f))) , rotateOffset.z);

        Vector3 e = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(e.x + newRotateOffset.x - rotateOffset.x, e.y + newRotateOffset.y - rotateOffset.y, e.z + newRotateOffset.z - rotateOffset.z);

        rotateOffset = newRotateOffset;
    }

    IEnumerator Rotate()
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime;
        }
    }
}
