using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 1.0f;
    public bool moveUp = true;
    private Vector3 startPosition;
    private int direction = 1;

    private void Start()
    {
        startPosition = transform.position;
        if (!moveUp) direction = -1;
    }

    private void Update()
    {
        float newY = Mathf.PingPong(Time.time * speed, distance) * direction + startPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
