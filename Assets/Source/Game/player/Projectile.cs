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
    public GameObject ps;
    
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

    public virtual void projectileDestroy()
    {
        ps.transform.parent = null;
        ps.GetComponent<ParticleSystem>().Stop();
        Destroy(gameObject);
        parent.reduceProjCount();

    }

    protected virtual void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.transform.CompareTag("Player"))
        {
            //TODO: decrease the health of the player
            projectileDestroy();
        }

        
    }

}
