using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacles")
        {
            //Time.timeScale = 0;
            Controller.isGameOver = true;
            gameObject.SetActive(false);

            Controller.GetInstance().GameOver();
        }
    }
}
