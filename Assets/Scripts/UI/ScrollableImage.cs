using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableImage : MonoBehaviour
{
    [SerializeField] private RawImage scrollableImage;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float scrollDirection;

    private Rect rect;
    private void Start()
    {
        rect = scrollableImage.uvRect;
    }
    private void Update()
    {
        rect.y += scrollDirection * scrollSpeed * Time.deltaTime;
        scrollableImage.uvRect = rect;
    }
}
