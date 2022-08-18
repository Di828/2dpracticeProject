using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    private float speed = 5f;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void SetSpeed (float speed)
    {
        this.speed = speed;
    }
}
