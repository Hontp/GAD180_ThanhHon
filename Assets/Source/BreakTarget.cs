using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float lifetime;
    public float lifeStart;

    [SerializeField]
    private Vector2 startVelocity;
    [SerializeField]
    private float rotationVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startVelocity,ForceMode2D.Impulse);
        rb.AddTorque(rotationVelocity,ForceMode2D.Impulse);
        lifeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float normalizedLife = (Time.time  - lifeStart) / (lifetime);
        //shrinking effect
        float scale = 1f - normalizedLife;
        if( scale < 0 )
        {
            Destroy(gameObject);
        }
        transform.localScale = new Vector3(scale,scale,0.1f); 
    }
}
