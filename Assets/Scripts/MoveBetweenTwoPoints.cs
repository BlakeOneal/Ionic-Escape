using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition.position, endPosition.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, Mathf.PingPong(fracJourney, 1));
    }
}