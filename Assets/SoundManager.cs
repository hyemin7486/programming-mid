using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip clipBGM;
    public AudioClip clipFx;

    AudioSource audioSourceFx;
    AudioSource audioSourceBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;

        audioSourceFx = gameObject.AddComponent<AudioSource>();
        audioSourceBGM = gameObject.AddComponent<AudioSource>();

        PlayBGM();
    }

    public void PlaySoundFx()
    {
        audioSourceFx.PlayOneShot(clipFx);
    }
    public void PlayBGM()
    {
        audioSourceBGM.clip = clipBGM;
        audioSourceBGM.loop = true;
        audioSourceBGM.Play();
    }
}
