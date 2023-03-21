using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public static bool north = true;
    public float moveSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    Rigidbody2D rb;
    Renderer rend;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        rend = player.GetComponent<Renderer>();
        rend.material.color = Color.red;
    }
    // Update is called once per frame
    void Update()
    {
        int vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        int horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        switch(horizontal)
        {
            case 1:
                rb.velocity = new Vector2(5 * moveSpeed, rb.velocity.y);
                break;
            case -1:
                rb.velocity = new Vector2(-5 * moveSpeed, rb.velocity.y);
                break;
            default:
                rb.velocity = new Vector2(0, rb.velocity.y);
                break;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(north)
            {
                rend.material.color = Color.blue;
            }
            else
            {
                rend.material.color = Color.red;
            }
            north = !north;
        }
    }
}
