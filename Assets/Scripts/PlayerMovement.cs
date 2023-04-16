using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public static bool north = true;
    public Animator animator;

    public bool isWalking = false;
    public bool isRunning = false;
    public float moveSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    int platformLayer = 1 << 3;
    int numJumps = 0;
    Rigidbody2D rb;
    Renderer rend;
    Vector3 dimensions;
    string feetFacing = "up";
    string jumpDirection = "up";
    [SerializeField] private AudioSource jumpSoundEffect;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        rend = player.GetComponent<Renderer>();
        rend.material.color = Color.red;
        dimensions = player.GetComponent<BoxCollider2D>().bounds.size;
        animator = GetComponent<Animator>();
    }

   void OnTriggerStay2D(Collider2D collision)
    {
            numJumps = 0;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && numJumps <= 1)
        {
            jumpSoundEffect.Play();
            //Play the animationm before jumping
            animator.SetBool("isJumping", true);
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
        //Check if player is rising or falling
        if(rb.velocity.y > 0){
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
        else if(rb.velocity.y < 0){
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else{
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        //Check if player is walking or running
        if(rb.velocity.x != 0){
            if(rb.velocity.x > 0){
                transform.localScale = new Vector3(1, 1, 1);
            }
            else{
                transform.localScale = new Vector3(-1, 1, 1);
            }
            animator.SetBool("isWalking", true);
            isWalking = true;
            if(Input.GetKey(KeyCode.LeftShift)){
                animator.SetBool("isRunning", true);
                isRunning = true;
            }
            else{
                animator.SetBool("isRunning", false);
                isRunning = false;
            }
        }
        else{
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            isWalking = false;
            isRunning = false;
        }

        if(isWalking){
            if(isRunning){
                moveSpeed = 2.0f;
            }
            else{
                moveSpeed = 1.0f;
            }
        }
        else{
            moveSpeed = 1.0f;
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

        //Use all of these to tell when to begin rotating the player towards the platform if detected
        RaycastHit2D[] hitUp = RaycastCheck(3, "up", 2.5f);
        RaycastHit2D[] hitDown = RaycastCheck(3, "down", 2.5f);
        RaycastHit2D[] hitLeft = RaycastCheck(5, "left", 2f);
        RaycastHit2D[] hitRight = RaycastCheck(5, "right", 2f);
        RaycastHit2D hitUpLeft = RaycastCheck(1, "up-left", 2.5f)[0];
        RaycastHit2D hitUpRight = RaycastCheck(1, "up-right", 2.5f)[0];
        RaycastHit2D hitDownLeft = RaycastCheck(1, "down-left", 2.5f)[0];
        RaycastHit2D hitDownRight = RaycastCheck(1, "down-right", 2.5f)[0];

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

       // Debug.Log("Jump Direction: " + jumpDirection); 

        //Print the states of waling, running, jumping, and falling
       
     
    }


    public RaycastHit2D[] RaycastCheck(int numOfRays, string rayDirection, float rayLength = 0.1f)
    {
        // Create an array of raycast hits
        RaycastHit2D[] hits = new RaycastHit2D[numOfRays];

        // Get the position of the player
        Vector3 position = player.transform.position;

        // Get the distance between each ray
        float distanceX = dimensions.x / (numOfRays - 1);
        float distanceY = dimensions.y / (numOfRays - 1);

        //If if up or down, move along x axis, if left or right, move along y axis
        if (rayDirection == "up" || rayDirection == "down")
        {
            // Loop through each ray
            for (int i = 0; i < numOfRays; i++)
            {
                // Create a ray
                Ray2D ray = new Ray2D();

                // Set the origin of the ray
                ray.origin = new Vector2(position.x - dimensions.x / 2 + distanceX * i, position.y + 0.1714022f);

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
                hits[i] = Physics2D.Raycast(ray.origin, ray.direction, rayLength, platformLayer);
                Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
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
                ray.origin = new Vector2(position.x, position.y - dimensions.y / 2 + distanceY * i + 0.1714022f);

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
                hits[i] = Physics2D.Raycast(ray.origin, ray.direction, rayLength, platformLayer);
                Debug.DrawRay(ray.origin, ray.direction * rayLength,  Color.red);
            }
        }

        //If up-left, up-right, down-left, down-right, check for corners
        else if(rayDirection == "up-right"){
            Ray2D ray = new Ray2D();
            ray.origin = new Vector2(position.x, position.y + 0.1714022f);
            ray.direction = new Vector2(1, 1);
            hits[0] = Physics2D.Raycast(ray.origin, ray.direction, rayLength, platformLayer);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            
        }
        else if(rayDirection == "up-left"){
            Ray2D ray = new Ray2D();
            ray.origin = new Vector2(position.x, position.y + 0.1714022f);
            ray.direction = new Vector2(-1, 1);
            hits[0] = Physics2D.Raycast(ray.origin, ray.direction, rayLength, platformLayer);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        }
        else if(rayDirection == "down-left"){
            Ray2D ray = new Ray2D();
            ray.origin = new Vector2(position.x, position.y + 0.1714022f);
            ray.direction = new Vector2(-1, -1);
            hits[0] = Physics2D.Raycast(ray.origin, ray.direction, rayLength, platformLayer);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        }
        else if(rayDirection == "down-right"){
            Ray2D ray = new Ray2D();
            ray.origin = new Vector2(position.x, position.y + 0.1714022f);
            ray.direction = new Vector2(1, -1);
            hits[0] = Physics2D.Raycast(ray.origin, ray.direction, rayLength, platformLayer);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        }



        #region Raycast
        // Return the array of raycast hits
        #endregion
        return hits;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dialogue" && !LoadDialogue.display)
        {
            LoadDialogue.display = true;
            Debug.Log("HERE");
            DestroyObject(collision.gameObject);
        }
    }

}