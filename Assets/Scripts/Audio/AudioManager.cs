using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource MusicSource, SFXSource;
    private void Awake() {

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void MusicPlay(AudioClip music)
    {
        MusicSource.Stop();
        MusicSource.clip = music;
        MusicSource.Play();
        MusicSource.loop = true;
    }

    public void SFXPlay(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
