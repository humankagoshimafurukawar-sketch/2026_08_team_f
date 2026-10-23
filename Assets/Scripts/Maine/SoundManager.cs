using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioClip bgmClip;

    [Header("SE")]
    public AudioClip se_Explosion;

    public AudioClip se_Change;

    AudioSource bgmSource;
    AudioSource seSource;

    //======================================================================================================================
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();

        bgmSource =
           sources.Length > 0 ?
           sources[0] : gameObject.AddComponent<AudioSource>();

        seSource =
            sources.Length > 1 ?
            sources[1] : gameObject.AddComponent<AudioSource>();

        bgmSource.loop = true;

        PlayBGM();
    }

    //======================================================================================================================
    void Update()
    {
        
    }

    //======================================================================================================================
    public void PlayBGM()
    {
        if (bgmClip == null) { return; }

        bgmSource.clip = bgmClip;

        bgmSource.Play();
    }

    //======================================================================================================================
    public void PlaySE(AudioClip clip)
    {
        if (clip == null) { return; }

        seSource.PlayOneShot(clip);
    }
}
