using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThorn2 : MonoBehaviour
{
    public Thorn_2 thorn_2;
    [SerializeField] private float maxTime;
    [SerializeField] private float height;
    private float timer;

    private void Start()
    {
        timer = maxTime;
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            Thorn_2 tmp = Instantiate(thorn_2, new Vector3(transform.position.x, transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);

            Destroy(tmp, 10f);

            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
