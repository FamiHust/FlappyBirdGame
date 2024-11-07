using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tai_Beo: Character
{
    public Tai_Beo(GameObject gameObject): base(gameObject)
    {
        speed = 6.5f;
        rotationSpeed = 1.5f;
    }

    protected override void InputHandle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * speed;
        }   
    }

    
}