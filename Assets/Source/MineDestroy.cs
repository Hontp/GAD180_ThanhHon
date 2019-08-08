using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDestroy : MonoBehaviour
{

    private AudioSource _as;
    private float timeToDestroy;
    private bool destoyed;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        timeToDestroy = _as.clip.length;

        destoyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !destoyed)
        {
            collision.transform.parent.GetComponent<Submarine>().ShipsHealth -= 25;
            Destroy(gameObject,timeToDestroy);
            destoyed = true;
        }
    }

}
