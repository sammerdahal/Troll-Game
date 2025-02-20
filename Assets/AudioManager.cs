using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Background;
    public AudioClip Death;
    public AudioClip Jump;
    public AudioClip Checkpoint;

    private void Awake()
    {
        // Ensure the AudioManager doesn't get destroyed when loading a new scene
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // Play the background music if set
        PlayMusic();

        // Subscribe to scene loaded event to manage music playback across scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play the music when a new scene is loaded
        PlayMusic();
    }

    private void PlayMusic()
    {
        if (musicSource != null && Background != null)
        {
            // Only play if not already playing
            if (!musicSource.isPlaying)
            {
                musicSource.clip = Background;
                musicSource.Play();
            }
        }
        else
        {
            Debug.LogError("AudioSource or Background clip is not assigned!");
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("SFXSource or AudioClip is not assigned!");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
