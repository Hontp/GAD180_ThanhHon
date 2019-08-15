using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject mineExplode;
    private SoundManager _soundManager;

    // Start is called before the first frame update
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
            Projectile p = other.GetComponent<Projectile>();
            if(p != null && !p.name.Contains("Laser"))
            {
                p.projectileDestroy();
            }
            Camera.main.gameObject.GetComponent<CameraManager>().setTrauma(0.25f);
            Destroy(gameObject);
            Instantiate(mineExplode, transform.position, Quaternion.identity);

            //Sound Stuff
            _soundManager._enemyCollision = 2;
            _soundManager._enemyCollide = true;
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Utilities.Instance.GetCollection["player"].GetComponent<Submarine>().ShipsHealth -= 25f;
            Instantiate(mineExplode, transform.position, Quaternion.identity);

            //Sound Stuff
            _soundManager._enemyCollision = 2;
            _soundManager._enemyCollide = true;
        }
        
    }
}
