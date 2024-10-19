using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public AudioClip Music;
    private void Start() 
    {
        AudioManager.Instance.MusicPlay(Music);    
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
