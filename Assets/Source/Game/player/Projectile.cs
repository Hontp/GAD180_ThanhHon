using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour
{

    public Rigidbody2D rb;
    SubmarineFire parent;
    private float timer;
    private float timeShot;
    public float lifetime;
    public float damage;
    protected Vector2 playerVelocity;
    
    public float distance;

    public Vector2 startPosition;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        startPosition = (Vector2) transform.position; 
        rb = GetComponent<Rigidbody2D>();
        timeShot = Time.time;
    }

    public void setParent(SubmarineFire parent)
    {
        this.parent = parent; 
    }

    public void setPlayerVelocity(Vector2 playerVel)
    {
        playerVelocity = playerVel;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer = Time.time - timeShot;
        if(timer > lifetime)
        {
            projectileDestroy();
        }
    }

    protected virtual void projectileDestroy()
    {
        Destroy(gameObject);
        parent.reduceProjCount();
    }
}
