using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMagnetNorth : MonoBehaviour
{
    bool _north;
    public GameObject player;
    public PointEffector2D north;
    public PointEffector2D south;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        _north = PlayerMovement.north;
        // if _north is true, we want to repel
        // if _north is false, we want to attract
        if (!_north)
        {
            north.enabled = false;
            south.enabled = true;

        }
        else
        {
            south.enabled = false;
            north.enabled = true;
        }
        
    }
}
