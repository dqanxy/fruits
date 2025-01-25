using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using System.Threading;

public class BloomManager : MonoBehaviour
{

    public Volume v;
    private Bloom b;
    private Vignette vg;
    private ColorAdjustments ca;
    public static BloomManager instance;

    public bool enableCA = false;
    public bool enableVignette = false;
    public bool enableBloom = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;

        v.profile.TryGet(out b);
        //v.profile.TryGet(out vg);
        //v.profile.TryGet(out ca);
    }

    // Update is called once per frame
    void Update()
    {
        //ca.active = enableCA;
        b.active = enableBloom;
        //vg.active = enableVignette;
    }

    public void SwitchColor(Color color, float timer)
    {
        StartCoroutine(SwitchColorCoro(color, timer));
    }

    public void SwitchBlue(float timer)
    {
        StartCoroutine(SwitchColorCoro(new Color(177/255f,237/255f,255/255f), timer));
    }
    public void SwitchRed(float timer)
    {
        StartCoroutine(SwitchColorCoro(new Color(255 / 255f, 100 / 255f, 91 / 255f), timer));
    }

    IEnumerator SwitchColorCoro(Color color, float t)
    {
        float timer = t;
        Color org = b.tint.GetValue<Color>();
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null; 
            b.tint.Override(Color.Lerp(color, org, timer / t));
        }

        b.tint.Override(color);
    }
}
