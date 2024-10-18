using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int scoreAmount;
    private void Start()
    {
        scoreAmount = 0;
    }
    public void AddScore(int newScore)
    {
        scoreAmount += newScore;
        scoreText.text = scoreAmount.ToString();
    }
    public void SubtractScore(int newScore)
    {
        scoreAmount -= newScore;
        scoreText.text = scoreAmount.ToString();
    }
}
