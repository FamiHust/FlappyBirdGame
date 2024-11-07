using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBase : MonoBehaviour
{
    public Base bases;
    [SerializeField] private float maxTime;
    private float timer;

    private void Start()
    {
        timer = maxTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            Base tmp = Instantiate(bases, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

            Destroy(tmp, 10f);

            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
