using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector2 boundsMin = new Vector2(float.NegativeInfinity, float.NegativeInfinity);
    public Vector2 boundsMax = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
    
    void LateUpdate ()
    {
        float newX = Mathf.Clamp(player.position.x + offset.x, boundsMin.x, boundsMax.x);
        float newY = Mathf.Clamp(player.position.y + offset.y, boundsMin.y, boundsMax.y);
        float newZ = offset.z;

        this.transform.position = new Vector3(newX, newY, newZ);
    }
}
