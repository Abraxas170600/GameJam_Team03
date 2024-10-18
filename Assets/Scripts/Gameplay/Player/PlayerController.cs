using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private KeyCode currentKey;
    private bool canPress;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private ScoreManager scoreManager;


    // Update is called once per frame
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
            Debug.Log("Correcto");
            canPress = false;
            return;
        }
        else{
            scoreManager.SubtractScore(Random.Range(20, 60));
            Debug.Log("Incorrecto");
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
