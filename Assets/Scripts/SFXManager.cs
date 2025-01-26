using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Singleton instance
    public static SFXManager Instance { get; private set; }

    // AudioClips for sound effects
    [SerializeField] private AudioClip enemyDeathSFX;
    [SerializeField] private AudioClip enemyHitSFX;
    [SerializeField] private AudioClip enemyShootSFX;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Make it persistent between scenes

        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Function to play the enemy death sound effect
    public void PlayEnemyDeathSFX()
    {
        PlaySFX(enemyDeathSFX);
    }

    // Function to play the enemy hit sound effect
    public void PlayEnemyHitSFX()
    {
        PlaySFX(enemyHitSFX);
    }

    // Function to play the enemy shoot sound effect
    public void PlayEnemyShootSFX()
    {
        PlaySFX(enemyShootSFX);
    }

    // Generic function to play a sound effect
    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("AudioClip is not assigned!");
        }
    }
}
