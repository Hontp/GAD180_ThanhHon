using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField]
    private float lifetime;
    [SerializeField]
    private float lifeStart;

    [SerializeField]
    private Vector2 startVelocity;
    [SerializeField]
    private float rotationVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startVelocity,ForceMode2D.Impulse);
        rb.AddTorque(rotationVelocity,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
