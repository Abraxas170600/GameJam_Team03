using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    public void Fail()
    {
        failPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
