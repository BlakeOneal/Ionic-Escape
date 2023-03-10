using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousScroll : MonoBehaviour
{
    private SpriteRenderer[] sprites;
    public enum directionEnum {left, right};

    [SerializeField] private directionEnum direction;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private GameObject scrollerObject;

    private void Start()
    {
        sprites = scrollerObject.GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (scrollerObject == null)
            return;

        foreach (SpriteRenderer sprite in sprites)
        {
            Vector3 position = sprite.transform.position;

            if (direction == directionEnum.left){
                position.x -= speed * Time.deltaTime;
                if (position.x < -sprite.bounds.size.x * 2)
                {
                    position.x += 4 * sprite.bounds.size.x;
                }
            }
            else if (direction == directionEnum.right){
                position.x += speed * Time.deltaTime;
                if (position.x > sprite.bounds.size.x * 2)
                {
                    position.x -= 4 * sprite.bounds.size.x;
                }
            }

            sprite.transform.position = position;
        }
    }
}