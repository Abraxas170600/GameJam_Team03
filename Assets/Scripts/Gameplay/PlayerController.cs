using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private KeyCode currentKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PressCurrentKey(currentKey);
    }
    private void PressCurrentKey(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("Correcto");
            return;
        }
        else
        {
            Debug.Log("Incorrecto");
        }
    }
}
