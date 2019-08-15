using UnityEngine;

public class Laser : Projectile
{
    public float speed;
    public float startTime;
    private GameObject firingPoint;
    protected override void Start()
    {
        speed = 0;
        lifetime = 0.5f;
        base.Start();
        transform.parent = null;
        rb.velocity = playerVelocity;
        transform.parent = Utilities.Instance.GetCollection["player"].transform;
        firingPoint = GameObject.Find("FiringPoint");
        // if(GameObject.FindObjectsOfType<Laser>().Length > 1)
        {
        //    Destroy(gameObject);
        }
        startTime = Time.time;

    }

    protected override void Update()
    {
        transform.position = firingPoint.transform.position;
        base.Update();
        //rb.AddForce(transform.right * -speed, ForceMode2D.Force);

    }

    // Missiles are right aligned
    public override void projectileDestroy()
    {
        base.projectileDestroy();
    }


}