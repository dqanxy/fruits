using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorAPI : MonoBehaviour
{
    public AudioClip sfx1;
    public AudioClip sfx2;

    public AudioSource s1;
    public AudioSource s2;
    public void CB_Begin() { CinematicBars.Begin(); }
    public void CB_End() { CinematicBars.End(); }
    public void BeginShake(string begin_end_time)
    {
        string[] tokens = begin_end_time.Split(' ');
        ShakeManager.BeginShake(float.Parse(tokens[2]), float.Parse(tokens[0]), float.Parse(tokens[1]));
    }
    public void BeginShakeFlashback() { ShakeManager.BeginShakeFlashback(); }
    public void EndShake() { ShakeManager.EndShake(); }

    public void SetColorAdjustments(string enable) { BloomManager.instance.enableCA = enable.ToLower() == "true"; }
    public void SetVignette(string enable) { BloomManager.instance.enableVignette = enable.ToLower() == "true"; }
    public void SetBloom(string enable) { BloomManager.instance.enableBloom = enable.ToLower() == "true"; }
    public void WhiteOverTime(string begin_end_time)
    {
        string[] tokens = begin_end_time.Split(' ');
        FlashManager.WhiteOverTime(float.Parse(tokens[0]), float.Parse(tokens[1]), float.Parse(tokens[2]));
    }

    public void BlackOverTime(string begin_end_time)
    {
        string[] tokens = begin_end_time.Split(' ');
        FlashManager.BlackOverTime(float.Parse(tokens[0]), float.Parse(tokens[1]), float.Parse(tokens[2]));
    }

    public void BlueOverTime(string time)
    {
        BloomManager.instance.SwitchBlue(float.Parse(time));
    }
    public void RedOverTime(string time)
    {
        BloomManager.instance.SwitchRed(float.Parse(time));
    }
    public void ChangeText(string newText)
    {
        TextManager.TextWithDelay(newText);
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void PlayAudio(string audioName)
    {

        string[] tokens = audioName.Split('~');
        AudioClip clip = (AudioClip)Resources.Load($"recs/{tokens[0]}");
        GetComponent<AudioSource>().PlayOneShot(clip);
        Debug.Log("test");
        ChangeText(tokens[1]);
    }



    public void PlaySFX1(string _pitch)
    {
        s1.pitch = float.Parse(_pitch);
        s1.PlayOneShot(sfx1);
    }

    public void PlaySFX2(string _pitch)
    {
        s2.pitch = float.Parse(_pitch);
        s2.PlayOneShot(sfx2);
    }

    public void Frown()
    {
        var objects = FindObjectsOfType(typeof(MeshRenderer));

        foreach(var obj in objects)
        {
            var component = ((MeshRenderer)obj).gameObject;
            if(component.name == "character_face:smile")
            {
                component.transform.localRotation = Quaternion.Euler(0f, 0f, -270f);
            }
        }
    }

    public void ImpactFrames()
    {
        ImpactFrameManager.StartImpactFrames();
    }
    public void ImpactFramesNoShake()
    {
        ImpactFrameManager.StartImpactFramesNoShake();
    }
    public void SmallImpactFrames()
    {
        ImpactFrameManager.StartSmallImpactFrames();
    }

    public void ChangeRenderer(string index)
    {
        int ind = int.Parse(index);
        ImpactFrameManager.ChangeRenderer(ind);
    }

}
