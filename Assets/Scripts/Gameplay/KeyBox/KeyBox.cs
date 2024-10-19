using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

public class KeyBox : MonoBehaviour
{
    [SerializeField] private KeyBoxSO keyBoxes;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private KeyCode currentKey;
    private UltEvent finishEvent;

    public KeyCode CurrentKey { get => currentKey; set => currentKey = value; }
    public UltEvent FinishEvent { get => finishEvent; set => finishEvent = value; }

    // Start is called before the first frame update
    void OnEnable()
    {
        KeyBoxData keyBoxData = keyBoxes.RandomKeyBox();
        Set(keyBoxData);
    }
    public void Set(KeyBoxData keyBoxData)
    {
        spriteRenderer.sprite = keyBoxData.keyImage;
        CurrentKey = keyBoxData.key;
    }
    public void Finish()
    {
        FinishEvent.Invoke();
    }
}
