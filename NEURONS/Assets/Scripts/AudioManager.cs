using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source References")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips Arrays")]
    public AudioClip[] musicList;
    public AudioClip[] sfxList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

    public void PlayMusic(int musicIndex)
    {
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();
    }

    // Update is called once per frame
    public void PlaySFX(int sfxIndex)
    {
        sfxSource.PlayOneShot(sfxList[sfxIndex]);
    }
}
