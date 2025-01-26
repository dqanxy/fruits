using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ImpactFrameManager : MonoBehaviour
{
    static ImpactFrameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void StartImpactFrames()
    {
        instance._StartImpactFrames();
    }
    public void _StartImpactFrames()
    {

        StartCoroutine(IFCoro());
    }


    public static void StartSmallImpactFrames()
    {
        instance._StartSmallImpactFrames();
    }
    public void _StartSmallImpactFrames()
    {

        StartCoroutine(SmallIFCoro());
    }


    IEnumerator SmallIFCoro()
    {
        var _camData = Camera.main.GetUniversalAdditionalCameraData();
        ShakeManager.BeginShake(.1f, 5, 5);

        _camData.SetRenderer(2);
        yield return new WaitForSeconds(.04f);
        _camData.SetRenderer(3);
        yield return new WaitForSeconds(.04f);
        _camData.SetRenderer(2);
        yield return new WaitForSeconds(.04f);

        ShakeManager.BeginShake(.1f, 5, 0);

        _camData.SetRenderer(1);

    }


    IEnumerator IFCoro()
    {
        var _camData = Camera.main.GetUniversalAdditionalCameraData();
        ShakeManager.BeginShake(.26f, 5, 5);

        _camData.SetRenderer(2);
        yield return new WaitForSeconds(.1f);
        _camData.SetRenderer(3);
        yield return new WaitForSeconds(.1f);
        _camData.SetRenderer(2);
        yield return new WaitForSeconds(.1f);

        ShakeManager.BeginShake(.1f, 5, 0);

        _camData.SetRenderer(1);

    }
}
