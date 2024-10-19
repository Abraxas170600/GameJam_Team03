using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private KeyCode currentKey;
    private bool canPress;
    [SerializeField] private LifeManager lifeManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private ScoreManager scoreManager;
    void Update()
    {
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
            lifeManager.UpdateLife(true);
            canPress = false;
            return;
        }
        else{
            scoreManager.SubtractScore(Random.Range(20, 60));
            lifeManager.UpdateLife(false);
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
