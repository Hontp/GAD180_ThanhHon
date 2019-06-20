using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{  
    public float speed;
    protected override void Start()
    {
        base.Start();
        base.damage = 1f;
    }

    protected override void Update()
    {
        base.Update();
        base.rb.AddForce(Vector2.right * speed, ForceMode2D.Force);

    }

    // Missiles are right aligned
    protected override void projectileDestroy()
    {
        base.projectileDestroy();
    }


}