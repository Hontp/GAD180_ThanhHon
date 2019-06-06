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
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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

}
