using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody2D))]

public class SubmarineMovement : MonoBehaviour
{
    public float speed;
    public float torque;
    public float maxAngularVelocity;
    public float maxSpeed;
    // Between 0-1f
    public float torqueDampen;
    public float turnDampening;

    public float worldWidth;
    
    public Rigidbody2D rb;
    private SubmarineFire sf;
    private Player player;
    private Submarine s;
    [Header("Particle Effects")]
    private ParticleSystem ps;
    private float emissionCount;


    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        emissionCount = ps.emissionRate;
        s = GetComponent<Submarine>();
        sf = GetComponent<SubmarineFire>();
        rb = GetComponent<Rigidbody2D>();

        player = Rewired.ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }

    private void Movement()
    {
        float deadZone = 0.05f;

        float thrust = player.GetAxis("Thrust");
        float horizontal = player.GetAxis("Horizontal");
       // Debug.Log( "Thrust= " + thrust.ToString() + " Horizontal = " + horizontal.ToString()); 
        
        // Forward Movement
        if ( (thrust > deadZone) && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(speed * transform.right * thrust,ForceMode2D.Force);
            // Dampen the rotation when not moving
            rb.angularVelocity *= 1 - torqueDampen;
            var e = ps.emission;
            e.rateOverTime = ( emissionCount * thrust);
        }
        else if( Mathf.Abs(horizontal) < deadZone )
        {
            // HARDCODED
            rb.angularVelocity *= 1 - torqueDampen/turnDampening;
        }
        // Rotation Left
        if(horizontal < -deadZone && rb.angularVelocity < maxAngularVelocity)
        {
            rb.AddTorque(-torque * horizontal,ForceMode2D.Impulse);
        }
        
        // Rotation Right
        if(horizontal > deadZone && rb.angularVelocity > -maxAngularVelocity)
        {
            rb.AddTorque(-torque * horizontal ,ForceMode2D.Impulse);
        }

    }

    private void Fire()
    {
        if(player.GetButtonDown("Fire"))
        {
            sf.fireProjectile(rb.velocity);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.transform.tag);
        if(c.transform.tag == "ScreenWrapperR")
        {
            Debug.Log("A");
            transform.position = new Vector3(transform.position.x - worldWidth,transform.position.y,transform.position.z );
            Debug.Log(transform.position.ToString());
        }
        if(c.transform.tag == "ScreenWrapperL")
        {
            Debug.Log("B");
            transform.position = new Vector3(transform.position.x + worldWidth,transform.position.y,transform.position.z );
        }
    }

}
