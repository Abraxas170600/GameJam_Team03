using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyBox", menuName = "ScriptableObjects/KeyBox")]
public class KeyBoxSO : ScriptableObject
{
    public KeyBoxData[] keyBoxData;
    public KeyBoxData RandomKeyBox()
    {
        return keyBoxData[Random.Range(0, keyBoxData.Length)];
    }
}

[System.Serializable]
public class KeyBoxData
{
    public KeyCode key;
    public Sprite keyImage;
}
