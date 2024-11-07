using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn_2 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
