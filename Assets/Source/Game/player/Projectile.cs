using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour
{

    protected Rigidbody2D rb;
    SubmarineFire parent;
    private float timer;
    private float timeShot;
    private float lifetime;
    protected float damage;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeShot = Time.time;
    }

    public void setParent(SubmarineFire parent)
    {
        this.parent = parent; 
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
