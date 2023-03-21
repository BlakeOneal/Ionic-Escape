using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMagnet : MonoBehaviour
{
    public bool _north;
    public GameObject player;
    public PointEffector2D magnet;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        bool pNorth = PlayerMovement.north;
        // if _north is true, we want to repel
        // if _north is false, we want to attract
        if (pNorth){
            if(_north){
                magnet.forceMagnitude = 100;
            }
            else{
                magnet.forceMagnitude = -100;
            }
        }

        else{
            if(_north){
                magnet.forceMagnitude = -100;
            }
            else{
                magnet.forceMagnitude = 100;
            }
        }
        
    }
}
