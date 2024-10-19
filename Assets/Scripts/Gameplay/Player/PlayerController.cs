using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private KeyCode currentKey;
    private bool canPress;

    private Animator playerAnimator;

    [SerializeField] private LifeManager lifeManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private FeedbackManager feedbackManager;

    [SerializeField] private AudioClip goodSound;
    [SerializeField] private AudioClip badSound;

    private float timeAmount = 100f;
    private float timeSpeed = 30f;
    private bool isCounting = true;

    [SerializeField] private Image timeBar;

    [SerializeField] private TMP_Text feedbackScoreText;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        timeAmount -= timeSpeed * Time.deltaTime;
        timeBar.fillAmount = timeAmount / 100f;

        if (timeAmount <= 0f && isCounting)
        {
            isCounting = false;
            feedbackManager.Fail();
        }

        if (Input.anyKeyDown && canPress && !IsMouseButtonPressed() && Time.timeScale == 1)
        {
            PressCurrentKey(currentKey);
        }
    }
    private void PressCurrentKey(KeyCode key)
    {
        if (Input.GetKeyDown(key)){
            PressCorrectKey();
        }
        else{
            PressIncorrectKey();
        }
    }
    private void PressCorrectKey()
    {
        int RandomScore = Random.Range(50, 100);
        feedbackScoreText.gameObject.SetActive(true);
        feedbackScoreText.GetComponent<DOTweenAnimator>().Animate();
        feedbackScoreText.text = $"+{RandomScore}";
        feedbackScoreText.color = Color.yellow;

        StartCoroutine(spawnManager.ReturnKeyBox());
        scoreManager.AddScore(RandomScore);
        lifeManager.UpdateLife(true, feedbackManager);
        AudioManager.Instance.SFXPlay(goodSound);
        canPress = false;
        timeAmount = 100f;
        timeSpeed += 0.4f;
        return;
    }
    private void PressIncorrectKey()
    {
        int RandomScore = Random.Range(20, 40);
        feedbackScoreText.gameObject.SetActive(true);
        feedbackScoreText.GetComponent<DOTweenAnimator>().Animate();
        feedbackScoreText.text = $"-{RandomScore}";
        feedbackScoreText.color = Color.red;

        playerAnimator.Play("Fail");
        scoreManager.SubtractScore(RandomScore);
        lifeManager.UpdateLife(false, feedbackManager);
        timeSpeed -= 0.4f;
        AudioManager.Instance.SFXPlay(badSound);
    }
    private bool IsMouseButtonPressed()
    {
        return Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KeyBox")){
            currentKey = collision.gameObject.GetComponent<KeyBox>().CurrentKey;
            canPress = true;
        }
    }
}
