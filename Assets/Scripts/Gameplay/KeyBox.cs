using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBox : MonoBehaviour
{
    [SerializeField] private KeyBoxSO keyBoxes;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private KeyCode currentKey;

    public KeyCode CurrentKey { get => currentKey; set => currentKey = value; }

    // Start is called before the first frame update
    void Start()
    {
        KeyBoxData keyBoxData = keyBoxes.RandomKeyBox();
        Set(keyBoxData);
    }
    private void Set(KeyBoxData keyBoxData)
    {
        spriteRenderer.sprite = keyBoxData.keyImage;
        CurrentKey = keyBoxData.key;
    }
}
