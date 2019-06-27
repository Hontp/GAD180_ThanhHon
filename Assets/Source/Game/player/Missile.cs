using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{  
    public float speed;
    protected override void Start()
    {
        base.Start();
        transform.parent = null;
        rb.velocity = playerVelocity;

    }

    protected override void Update()
    {
        base.Update();
        rb.AddForce(transform.right * -speed, ForceMode2D.Force);

        if(Vector2.Distance(transform.position,startPosition) > distance)
        {
            projectileDestroy();
        }

    }

    // Missiles are right aligned
    protected override void projectileDestroy()
    {
        base.projectileDestroy();
    }


}