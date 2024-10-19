using System.Collections;
using System.Collections.Generic;
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

    private float timeAmount = 100f;
    private bool isCounting = true;
    [SerializeField] private Image timeBar;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        timeAmount -= 30 * Time.deltaTime;
        timeBar.fillAmount = timeAmount / 100f;

        if (timeAmount <= 0f && isCounting)
        {
            isCounting = false;
            feedbackManager.Fail();
        }

        if (Input.anyKeyDown && canPress){
            PressCurrentKey(currentKey);
        }
    }
    private void PressCurrentKey(KeyCode key)
    {
        if (Input.GetKeyDown(key)){
            spawnManager.ReturnKeyBox();
            spawnManager.GetCurrentKeyBox();
            scoreManager.AddScore(Random.Range(100, 200));
            lifeManager.UpdateLife(true, feedbackManager);
            canPress = false;
            timeAmount = 100f;
            return;
        }
        else{
            playerAnimator.Play("Fail");
            scoreManager.SubtractScore(Random.Range(20, 60));
            lifeManager.UpdateLife(false, feedbackManager);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KeyBox")){
            currentKey = collision.gameObject.GetComponent<KeyBox>().CurrentKey;
            canPress = true;
        }
    }
}
