using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteEnvironment : MonoBehaviour
{
    [SerializeField] private float posY;
    [SerializeField] private GameObject obj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            obj.transform.localPosition = new Vector2(0, transform.localPosition.y - posY);
        }
    }
}
