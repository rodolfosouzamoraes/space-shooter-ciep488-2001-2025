using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioLaser;
    public AudioClip audioExplosao;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarAudioLaser()
    {
        //Emitir um audio
        audioSource.PlayOneShot(audioLaser);
    }

    public void TocarAudioExplosao()
    {
        audioSource.PlayOneShot(audioExplosao);
    }
}
