using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.tag == "Player")
        {
            Controller.numCoin++;
            PlayerPrefs.SetInt("NumCoin", Controller.numCoin);
            Destroy(gameObject, 0.1f);
        }
    }
}
