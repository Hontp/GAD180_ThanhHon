using UnityEngine;

public class Bullet : Projectile
{
    public float speed;
    protected override void Start()
    {
        base.Start();
        transform.parent = null;
        rb.velocity = playerVelocity;

        rb.AddForce(transform.right * -speed,ForceMode2D.Impulse);

    }

    protected override void Update()
    {
        base.Update();
        

        if (Vector2.Distance(transform.position, startPosition) > distance)
        {
            projectileDestroy();
        }

    }

    // Missiles are right aligned
    public override void projectileDestroy()
    {
        base.projectileDestroy();
    }


}