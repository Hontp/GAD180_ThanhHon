using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        sf = GetComponent<SubmarineFire>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }

    private void Movement()
    {
        // Forward Movement
        if(Input.GetKey(KeyCode.W) && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(speed * transform.right,ForceMode2D.Force);
            // Dampen the rotation when not moving
            rb.angularVelocity *= 1 - torqueDampen;
        }
        else if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            // HARDCODED
            rb.angularVelocity *= 1 - torqueDampen/turnDampening;
        }
        // Rotation Left
        if(Input.GetKey(KeyCode.A) && rb.angularVelocity < maxAngularVelocity)
        {
            rb.AddTorque(torque,ForceMode2D.Impulse);
        }
        
        // Rotation Right
        if(Input.GetKey(KeyCode.D) && rb.angularVelocity > -maxAngularVelocity)
        {
            rb.AddTorque(-torque,ForceMode2D.Impulse);
        }

    }

    private void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
