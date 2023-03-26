using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public static bool north = true;
    public float moveSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    int platformLayer = 1 << 3;
    int numJumps = 0;
    Rigidbody2D rb;
    Renderer rend;
    string feetFacing = "up";
    string jumpDirection = "up";

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        rend = player.GetComponent<Renderer>();
        rend.material.color = Color.red;
    }

   void OnTriggerStay2D(Collider2D collision)
    {
            numJumps = 0;
    }

    void Update(){
        Debug.Log(numJumps);
        if (Input.GetKeyDown(KeyCode.Space) && numJumps <= 2)
        {
            switch (jumpDirection)
            {
                case "up":
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    numJumps++;
                    break;
                case "down":
                    rb.AddForce(Vector2.down * jumpHeight, ForceMode2D.Impulse);
                    numJumps++;
                    break;
                case "left":
                    rb.AddForce(Vector2.left * jumpHeight, ForceMode2D.Impulse);
                    numJumps++;
                    break;
                case "right":
                    rb.AddForce(Vector2.right * jumpHeight, ForceMode2D.Impulse);
                    numJumps++;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (north)
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

    void FixedUpdate()
    {
        int vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        int horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));

        RaycastHit2D[] hitUp = RaycastCheck(3, "up");
        RaycastHit2D[] hitDown = RaycastCheck(3, "down");
        RaycastHit2D[] hitLeft = RaycastCheck(3, "left");
        RaycastHit2D[] hitRight = RaycastCheck(3, "right");

        //Check each raycast for a hit, and if any of them hit, change the jump direction
        foreach (RaycastHit2D hit in hitUp)
        {
            if (hit.collider != null)
            {
                feetFacing = "up";

            }
        }
        foreach (RaycastHit2D hit in hitDown)
        {
            if (hit.collider != null)
            {
                feetFacing = "down";

            }
        }
        foreach (RaycastHit2D hit in hitLeft)
        {
            if (hit.collider != null)
            {
                feetFacing = "left";

            }
        }
        foreach (RaycastHit2D hit in hitRight)
        {
            if (hit.collider != null)
            {
                feetFacing = "right";
 
            }
        }

        //If the player is standing on a platform, change the jump direction to the opposite of the platform
        switch (feetFacing)
        {
            case "up":
                jumpDirection = "down";
                break;
            case "down":
                jumpDirection = "up";
                break;
            case "left":
                jumpDirection = "right";
                break;
            case "right":
                jumpDirection = "left";
                break;
        }

        if(feetFacing == "up" || feetFacing == "down"){
            switch (horizontal)
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
        }
        else if(feetFacing == "left" || feetFacing == "right"){
            switch(vertical){
                case 1:
                    rb.velocity = new Vector2(rb.velocity.x, 5 * moveSpeed);
                    break;
                case -1:
                    rb.velocity = new Vector2(rb.velocity.x, -5 * moveSpeed);
                    break;
                default:
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    break;
            }
        }

        //Reset feetFacing to down for default
        feetFacing = "down";

        Debug.Log("Jump Direction: " + jumpDirection); 


     
    }


    public RaycastHit2D[] RaycastCheck(int numOfRays, string rayDirection)
    {
        // Create an array of raycast hits
        RaycastHit2D[] hits = new RaycastHit2D[numOfRays];

        // Get the size of the player
        Vector3 size = player.GetComponent<Renderer>().bounds.size;

        // Get the position of the player
        Vector3 position = player.transform.position;

        // Get the distance between each ray
        float distance = size.x / (numOfRays - 1);

        //If if up or down, move along x axis, if left or right, move along y axis
        if (rayDirection == "up" || rayDirection == "down")
        {
            // Loop through each ray
            for (int i = 0; i < numOfRays; i++)
            {
                // Create a ray
                Ray2D ray = new Ray2D();

                // Set the origin of the ray
                ray.origin = new Vector2(position.x - size.x / 2 + distance * i, position.y);

                // Set the direction of the ray
                switch (rayDirection)
                {
                    case "up":
                        ray.direction = Vector2.up;
                        break;
                    case "down":
                        ray.direction = Vector2.down;
                        break;
                }

                // Cast the ray
                hits[i] = Physics2D.Raycast(ray.origin, ray.direction,0.8f, platformLayer);
            }
        }
        else if (rayDirection == "left" || rayDirection == "right")
        {
            // Loop through each ray
            for (int i = 0; i < numOfRays; i++)
            {
                // Create a ray
                Ray2D ray = new Ray2D();

                // Set the origin of the ray
                ray.origin = new Vector2(position.x, position.y - size.y / 2 + distance * i);

                // Set the direction of the ray
                switch (rayDirection)
                {
                    case "left":
                        ray.direction = Vector2.left;
                        break;
                    case "right":
                        ray.direction = Vector2.right;
                        break;
                }

                // Cast the ray
                hits[i] = Physics2D.Raycast(ray.origin, ray.direction, 0.8f, platformLayer);
            }
        }

        // Return the array of raycast hits
        return hits;
    }
}
