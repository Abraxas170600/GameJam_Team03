using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private KeyBox keyBox;
    [SerializeField] private GameObject keyBoxStorage;
    [SerializeField] private GameObject keyBoxTarget;
    [SerializeField] private int keyBoxAmount;

    private List<KeyBox> keyBoxeList = new();
    private KeyBox currentKeyBox;
    private int keyBoxIndex;

    private float posY;
    private void Start()
    {
        posY = 0f;

        for (int i = 0; i < keyBoxAmount; i++)
        {
            KeyBox currentKeyBox = Instantiate(keyBox, keyBoxStorage.transform);
            currentKeyBox.gameObject.SetActive(false);
            keyBoxeList.Add(currentKeyBox);
        }

        GetCurrentKeyBox();
    }

    public void GetCurrentKeyBox()
    {
        currentKeyBox = keyBoxeList[keyBoxIndex];

        keyBoxIndex = (keyBoxIndex + 1) % keyBoxeList.Count;
        currentKeyBox.gameObject.SetActive(true);

        currentKeyBox.gameObject.transform.SetParent(keyBoxTarget.transform);
        currentKeyBox.transform.position = new Vector2(keyBoxTarget.transform.position.x, keyBoxTarget.transform.position.y + posY);

        posY -= 3f;
    }
    public void ReturnKeyBox()
    {
        currentKeyBox.gameObject.SetActive(false);
        currentKeyBox.gameObject.transform.SetParent(keyBoxStorage.transform);
        currentKeyBox.transform.position = new Vector2(keyBoxStorage.transform.position.x, keyBoxStorage.transform.position.y);
    }
}
