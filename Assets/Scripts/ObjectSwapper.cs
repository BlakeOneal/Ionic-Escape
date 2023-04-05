using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwapper : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public float swapInterval = 1.0f;

    private bool isSwapping = false;

    void Start()
    {
        StartCoroutine(SwapObjects());
    }

    IEnumerator SwapObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(swapInterval);

            if (isSwapping)
            {
                object1.SetActive(true);
                object2.SetActive(false);
                isSwapping = false;
            }
            else
            {
                object1.SetActive(false);
                object2.SetActive(true);
                isSwapping = true;
            }
        }
    }
}