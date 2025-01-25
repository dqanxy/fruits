using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool pauseSystem;
    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseSystem && !ps.isStopped)
        {
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        else if (!pauseSystem && ps.isStopped)
        {
            ps.Play();
        }
    }
}
