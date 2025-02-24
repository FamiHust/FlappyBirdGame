using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Character
{
    protected float speed {get; set;}
    protected float rotationSpeed {get; set;}
    protected AudioManager audioManager {get; set;}


    protected Rigidbody2D rb {get; set;}
    protected Animator animator {get; set;}
    protected BoxCollider2D boxCollider2D {get; set;}
    protected Transform transform {get; set;}

    public Character(GameObject gameObject)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        transform = gameObject.transform;
    }

    internal void Update()
    {
        InputHandle();
        FixedUpdate();
    }

    protected abstract void InputHandle();

    protected void FixedUpdate() 
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);    
    }
}