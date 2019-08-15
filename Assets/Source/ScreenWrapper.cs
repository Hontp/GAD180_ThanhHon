using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    public int worldWidth = 50;
    private Rigidbody2D rb;
    private Vector2 velocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void parentToPlayer(Transform player)
    {
        velocity = rb.velocity;
        rb.isKinematic = false;
        rb.bodyType = RigidbodyType2D.Static;

        //rb.MovePosition(player.position + Vector3.right * -worldWidth);
        //transform.position += Vector3.right * -50f;
        transform.parent = player;
    }

    public void unParentToplayer()
    {
        transform.parent = null;
        rb.isKinematic = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = velocity;
        rb.WakeUp();
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
    }
}
