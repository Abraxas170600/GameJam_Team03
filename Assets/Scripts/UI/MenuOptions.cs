using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public AudioClip Music;

    AudioManager audioManager;
    [SerializeField] AudioClip clip;

    private void Start() 
    {
        AudioManager.Instance.MusicPlay(Music);    
        audioManager = AudioManager.Instance;
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void PlaySFX()
    {
        audioManager.SFXPlay(clip);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
