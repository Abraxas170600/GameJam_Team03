using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public GameObject[] lifes;
    public void UpdateLife(int index, bool state)
    {
        lifes[index].SetActive(state);
    }
}
