using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private AudioClip Music;
    [SerializeField] private AudioClip clip;

    [SerializeField] private TMP_Text highScoreText;

    private void Start() 
    {
        AudioManager.Instance.MusicPlay(Music);
        highScoreText.text = $"High Score : {PlayerPrefs.GetInt("RecordScore")}";
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void PlaySFX()
    {
        AudioManager.Instance.SFXPlay(clip);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
