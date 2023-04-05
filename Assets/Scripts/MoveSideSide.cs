// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MoveSideSide : MonoBehaviour
// {
//     public float speed = 1.0f;
//     public float distance = 1.0f;
//     public bool moveRight = true;
//     private Vector3 startPosition;
//     private int direction = 1;

//     private void Start()
//     {
//         startPosition = transform.position;
//         if (!moveRight) direction = -1;
//     }

//     private void Update()
//     {
//         float newX = Mathf.PingPong(Time.time * speed, distance) * 2 - distance + startPosition.x;
//         transform.position = new Vector3(newX, transform.position.y, transform.position.z);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideSide : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 1.0f;
    public bool moveRight = true;
    private Vector3 startPosition;
    private int direction = 1;

    private void Start()
    {
        startPosition = transform.position;
        if (!moveRight) direction = -1;
    }

    private void Update()
    {
        float newX = Mathf.PingPong(Time.time * speed, distance) * direction + startPosition.x;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
