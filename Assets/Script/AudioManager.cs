using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Background Music")]
    public AudioClip BackgroundMusic;

    [Header("SFX Sound")]
    public AudioClip ball;
    public AudioClip win;
    public AudioClip button;
    public AudioClip start;

    private void Start()
    {
        musicSource.clip = BackgroundMusic;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}