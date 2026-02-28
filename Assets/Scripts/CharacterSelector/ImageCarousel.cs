using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageCarousel : MonoBehaviour
{
    public RectTransform contentPanel;
    public List<Sprite> images;
    public GameObject imagePrefab;
    public Button leftButton;
    public Button rightButton;
    public float transitionSpeed = 10f;

    private List<GameObject> imageObjects = new List<GameObject>();
    private int currentIndex = 0;
    private Vector2 targetPosition;
    private float imageWidth;

    void Start()
    {
        imageWidth = contentPanel.rect.width;

        for (int i = 0; i < images.Count; i++)
        {
            GameObject imageObject = Instantiate(imagePrefab, contentPanel);
            imageObject.GetComponent<Image>().sprite = images[i];
            RectTransform rt = imageObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * imageWidth, 0);
            imageObjects.Add(imageObject);
        }

        leftButton.onClick.AddListener(() => MoveCarousel(-1));
        rightButton.onClick.AddListener(() => MoveCarousel(1));
    }

    void MoveCarousel(int direction)
    {
        StopAllCoroutines();
        currentIndex = (currentIndex + direction) % images.Count;
        if (currentIndex < 0)
        {
            currentIndex += images.Count;
        }

        targetPosition = new Vector2(-currentIndex * imageWidth, contentPanel.anchoredPosition.y);
        StartCoroutine(SmoothScrollTo(targetPosition));
    }

    IEnumerator SmoothScrollTo(Vector2 target)
    {
        while (Vector2.Distance(contentPanel.anchoredPosition, target) > 0.1f)
        {
            contentPanel.anchoredPosition = Vector2.Lerp(contentPanel.anchoredPosition, target, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        contentPanel.anchoredPosition = target;
    }
}
