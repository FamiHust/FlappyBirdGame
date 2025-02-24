using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float timer;
    public Pipe pipe;

    [SerializeField] private float maxTime;
    [SerializeField] private float height;

    private void Start()
    {
        timer = maxTime;
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            Pipe tmp = Instantiate(pipe, new Vector3(transform.position.x, transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);

            Destroy(tmp, 10f);

            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
