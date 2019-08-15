using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]

public class SubmarineMovement : MonoBehaviour
{

    public string sceneName;

    public float worldWidth;
    
    public Rigidbody2D rb;
    private SubmarineFire sf;
    private Player player;
    private Submarine s;


    [Header("These will be modified by StatMultiplier")]
    public float speed;
    public float torque;
    public float maxAngularVelocity;
    public float maxSpeed;

    [Header("Not these though yet")]
    // Between 0-1f
    public float torqueDampen;
    public float turnDampening;

    [Header("Stat Multipliers")]
    public float maxSpeedStatMultiplier;
    public float speedStatMultiplier;
    public float maxAngularVelocityStatMultiplier;
    public float torqueStatMultiplier;

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

        Debug.DrawLine(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)), Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 0)));
        //Debug.DrawLine(new Vector2(Screen.safeArea.xMin, Screen.safeArea.yMax), new Vector2(Screen.safeArea.xMax, Screen.safeArea.yMin));


        if (player.GetButtonLongPressDown("Reset"))
        {
            SceneManager.LoadScene(sceneName);
        }

        //TODO: previousVelocity = rb.velocity;
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
            rb.angularVelocity *= 0.5f - torqueDampen/turnDampening;
            
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

    public void setSpeed(int speedIn)
    {
        //adding 2 because the speedIn value can be negative (thanks sam)
        maxSpeed = maxSpeedStatMultiplier * (speedIn + 5);
        speed = speedStatMultiplier * (speedIn + 5);
    }

    public void setHandling(int handlingIn)
    {
        maxAngularVelocity = maxAngularVelocityStatMultiplier * (handlingIn + 5);
        torque = torqueStatMultiplier * (handlingIn + 5);
        torqueDampen = ((torqueDampen + (handlingIn+5) * 0.1f) < 2f) ? torqueDampen + (handlingIn + 5) * 0.1f : 2;
        turnDampening = ((torqueDampen + (handlingIn + 5) * 0.1f) < 3f) ? torqueDampen + (handlingIn + 5) * 0.1f : 3;
        // should I change torque dampen here? TODO: check gamefeel
        // torqueDampen ????
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
        
        
        if(c.transform.tag != "Untagged")
        {
            Collider2D[] colList = Physics2D.OverlapBoxAll( Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4, Screen.height / 4)) , Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)), 0f);
            //Debug.DrawLine(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)), Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)));
           // Debug.DrawLine((Vector2)Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.xMin, Screen.safeArea.yMax)), (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.xMax, Screen.safeArea.yMin)));

            if (c.transform.tag == "ScreenWrapperR")
            {
                foreach(Collider2D col in colList)
                {
                    //Screenwrappable mask is number 8
                    if (col.gameObject.layer == 8)
                    {
                        col.GetComponent<ScreenWrapper>().parentToPlayer(transform);
                    }
                }
                transform.position = new Vector3(transform.position.x - worldWidth, transform.position.y, transform.position.z);
                foreach (Collider2D col in colList)
                {
                    if (col.gameObject.layer == LayerMask.NameToLayer("Screenwrappable"))
                    {
                        col.GetComponent<ScreenWrapper>().unParentToplayer();
                    }
                }
            }


            if (c.transform.tag == "ScreenWrapperL")
            {
                foreach (Collider2D col in colList)
                {
                    //Screenwrappable mask is number 8
                    if (col.gameObject.layer == 8)
                    {
                        col.GetComponent<ScreenWrapper>().parentToPlayer(transform);
                    }
                }
                transform.position = new Vector3(transform.position.x - worldWidth, transform.position.y, transform.position.z);
                foreach (Collider2D col in colList)
                {
                    if (col.gameObject.layer == LayerMask.NameToLayer("Screenwrappable"))
                    {
                        col.GetComponent<ScreenWrapper>().unParentToplayer();
                    }
                }
            }
        }
    }

}
