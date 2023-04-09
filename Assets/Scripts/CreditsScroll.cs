using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsScroll : MonoBehaviour {

    public float speed = 50f; // The speed at which the text box moves
    public float waitTime = 2f; // The amount of time to wait before moving the text box again

    private RectTransform rectTransform;

    void Start () {
        rectTransform = GetComponent<RectTransform>(); // Get the rect transform component of the text box
        StartCoroutine(Move()); // Start the coroutine to move the text box
    }

    IEnumerator Move () {
        while (true) { // Repeat indefinitely
            float startY = rectTransform.anchoredPosition.y; // Get the starting Y position of the text box
            float targetY = startY + Screen.height + rectTransform.rect.height; // Calculate the target Y position of the text box

            while (rectTransform.anchoredPosition.y < targetY) { // Move the text box until it reaches the target Y position
                rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
                yield return null;
            }

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, startY); // Set the text box back to the starting position
            yield return new WaitForSeconds(waitTime); // Wait for the specified amount of time before moving the text box again
        }
    }
}
